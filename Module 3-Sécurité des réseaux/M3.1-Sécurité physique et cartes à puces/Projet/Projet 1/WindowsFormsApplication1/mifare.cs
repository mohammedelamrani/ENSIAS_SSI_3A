using System;
using System.IO.Ports;
using sm_mifare_lib;

/// <summary>
/// Summary description for sm_mifare_lib
/// V1.0 First Release
/// /// </summary>
namespace sm_mifare_lib
{

    
    public enum ASource
    {
        KeyTypeA = 0xAA,
        KeyTypeB = 0xBB,
        KeyMifareDefault = 0xFF
    }
     
  

    public class mifare
    {
        public static readonly byte[] E2promKeyA = new byte[16] {0x10,0x11,0x12,0x13,0x14,0x15,0x16,0x17,0x18,0x19,0x1A,0x1B,0x1C,0x1D,0x1E,0x1F};
        public static readonly byte[] E2promKeyB = new byte[16] { 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F };
            
 
        
         
        public static SerialPort port = new SerialPort();       //"Static" must be used otherwise, port is created each time so can not access actual port.
        public static MainForm.Form2 frm1 = new MainForm.Form2();

        /* REMOVED CODE
         * public void OnReceive_Event(byte Response_Type,byte TagType,byte[] TagSerial,string Firmware)
        {
            frm1.OnReceive_Event(Response_Type, TagType, TagSerial, Firmware);
        }
        
        public void InitPort()
        {
            
         port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived); //This will intialize to raise event so that when data comes unexpectedly will be directed to port_DataReceived function.

        }
        */
        private bool get_response(out byte[] MyBuffer, out byte Count)
        {
            MyBuffer = new byte[24];
            int i;
            Count = 0;

            //Get First 4 byte from the device, this includes command and length information of data.
            for (i = 0; i < 4; i++)
            {

                try
                {
                    MyBuffer[i] = (byte)port.ReadByte();
                }
                catch (Exception)  //catch (Exception ee)
                {
                    return false;
                } // //Exception_Text = ee.ToString();  

            }

            if (MyBuffer[2] > 20) //Mybuffer[2] represents length of data+checksum. This can not be greater than 20.
                return false;

            //Get Remaining data
            for (i = 0; i < MyBuffer[2]; i++)
            {
                try
                {
                    MyBuffer[i + 4] = (byte)port.ReadByte();
                }
                catch (Exception)  //catch (Exception ee)
                {
                    return false;
                }
            }
            Count = MyBuffer[2];
            Count += 4;

            return true;

        }

        public void get_data(ref byte[] Response, ref byte Count) //This will filter only data partion of the whole incoming data(Remove Header,Command,Length,Checksum)
        {
            //Response = new int[24];
            int i;
            byte y;

            y = 0;

            if (Count >= 4) //If Count<4 then this is not a valid packet.
            {

                Count--; //We wont use final byte that is Checksum

                for (i = 4; i < Count; i++)
                {
                    Response[y] = Response[i];
                    y++;
                }

            }

            Count = y;
        }

        public void send_command(byte Command, byte[] DataBuffer, byte DataCount)
        {
            byte[] TxFrame = new byte[24];
            int i;
            byte checksum;

            DataCount++; //Length information will include checksum byte.
            checksum = 0;
            TxFrame[0] = 0xFF;
            TxFrame[1] = 0x00;
            TxFrame[2] = DataCount;
            TxFrame[3] = Command;

            checksum = TxFrame[1];
            checksum += TxFrame[2];
            checksum += TxFrame[3];


            for (i = 0; i < DataCount; i++)
            {
                TxFrame[i + 4] = DataBuffer[i];
                checksum += DataBuffer[i];
            }

            TxFrame[DataCount + 3] = checksum;
            port.Write(TxFrame, 0, DataCount + 4);

        }


        public void ParseIncoming(out byte Response_Type, out byte TagType, out byte[] TagSerial, out string Firmware)
        {
            byte[] Response = new byte[24];
            byte Count = 0;
            byte i = 0;
            
            TagSerial = new byte[4];
            Firmware = "";
            Response_Type = 0;
            TagType = 0;



            if (get_response(out Response, out Count))
            {
                if (Response[3] == 0x81)  //Is this Firmware Version?
                {
                    get_data(ref Response, ref Count);          //This will filter only data partion of the whole incoming data(Remove Header,Command,Length,Checksum)
                    //Create Firmware String
                    for (i = 0; i < Count; i++)
                        Firmware += Convert.ToChar(Response[i]);

                    Response_Type = 1;
                    
                }
                else if (Response[3] == 0x82)// Is this Tag type and Serial?
                {
                    get_data(ref Response, ref Count);          //This will filter only data partion of the whole incoming data(Remove Header,Command,Length,Checksum)
                    
                    TagType = Response[0];                           //Tag Type. i.e 0x01 = Mifare 1K, 0x02 = Mifare 4K
                    TagSerial[0] = Response[4];     //Serial number comes LSB first
                    TagSerial[1] = Response[3];
                    TagSerial[2] = Response[2];
                    TagSerial[3] = Response[1];

                    Response_Type = 2;
                   
                }

            }



        }

     
        public bool OpenPort(string PortName,int BaudRate)
        {
            //Open port if not opened previously.
            if (port.IsOpen)
                port.Close();

            if (!port.IsOpen)
            {
                port.PortName=PortName;
                port.BaudRate=BaudRate;
                port.ReadTimeout = 1000; 
                port.WriteTimeout = 500;
                port.DtrEnable = true;
                try
                {
                    port.Open();
                }
                catch (Exception)  //catch (Exception ee)
                {
                    return false;
                }

                port.ReadExisting(); //Just to clear Buffer;
   
            }

            return true;

        }

        public void ClosePort()
        {
                     
            //Open port if not opened previously.
            if (port.IsOpen)
            {
                port.Close();
            }
   
        }

               
        public bool CMD_ResetDevice(out string Firmware)
        {
            
            byte[] Response = new byte[24];
            byte[] DataBuffer = new byte[20];
            int i;
            byte Count = 0;
            Firmware = "";

                        
            port.ReadExisting(); //Just to clear Buffer;
            send_command(0x80, DataBuffer, 0);
   
            //We wait reset_response after a reset. 
            //That is the firmware version of the module

            if (get_response(out Response,out Count))
            {
                get_data(ref Response, ref Count); //This will filter only data partion of the whole incoming data(Remove Header,Command,Length,Checksum)

                //Create Firmware String
                for (i = 0; i < Count; i++)
                Firmware += Convert.ToChar(Response[i]);

                return true;
            }
            else
                return false;

        }

        public bool CMD_SelectTag(out byte TagType,out byte[] TagSerial,out byte ReturnCode)
        {

            byte[] Response = new byte[24];
            byte[] DataBuffer = new byte[20];
            TagSerial = new byte[4];
            byte Count = 0;
            TagType = 0;

            ReturnCode = 0;  // 0 Communication Error

            port.ReadExisting(); //Just to clear Buffer;
            send_command(0x83, DataBuffer, 0); // 0x83 = SELECT_TAG

            //Wait response of the operation
            
            if (get_response(out Response, out Count))
            {
                get_data(ref Response, ref Count);          //This will filter only data partion of the whole incoming data(Remove Header,Command,Length,Checksum)

                if (Count > 1)
                {

                    TagType = Response[0];                           //Tag Type. i.e 0x01 = Mifare 1K, 0x02 = Mifare 4K
                    TagSerial[0] = Response[4];     //Serial number comes LSB first
                    TagSerial[1] = Response[3];
                    TagSerial[2] = Response[2];
                    TagSerial[3] = Response[1];
                    return true; //1-> Success
                }
                else
                {
                    ReturnCode = Response[0];
                    return false;

                }


            }
            else
                return false;
        }


        public bool CMD_SeekForTag(out byte ReturnCode)
        {

            byte[] Response = new byte[24];
            byte[] DataBuffer = new byte[20];
            byte Count = 0;
            ReturnCode = 0;
            
            port.ReadExisting(); //Just to clear Buffer;
            send_command(0x82, DataBuffer, 0); // 0x83 = SELECT_TAG

            //Wait response of the operation

            if (get_response(out Response, out Count))
            {
                get_data(ref Response, ref Count);          //This will filter only data partion of the whole incoming data(Remove Header,Command,Length,Checksum)

                    if (Response[0]==0x4C)
                    return true;
                    else
                    {
                    ReturnCode = Response[0];
                    return false;
                    }


            }
            else
                return false;
        }

        public bool CMD_Authenticate(byte AuthSource, byte[] Key, byte BlockNo,out byte ReturnCode)
        {
            byte[] Response = new byte[24];
            byte[] DataBuffer = new byte[20];
            byte i = 0;
            byte Count = 0;
            ReturnCode = 0;

            
            

            DataBuffer[0] = BlockNo;
            DataBuffer[1] = AuthSource;
            if ((AuthSource == (byte)ASource.KeyTypeA) || (AuthSource == (byte)ASource.KeyTypeB))
            {

                for (i = 0; i < 6; i++) 
                DataBuffer[2 + i] = Key[i];
                send_command(0x85, DataBuffer, 8);
            }
            else
                send_command(0x85, DataBuffer, 2);

                        
            

            if (get_response(out Response, out Count))
            {
                get_data(ref Response, ref Count);          //This will filter only data partion of the whole incoming data(Remove Header,Command,Length,Checksum)

                if (Response[0] == 0x4C)
                    return true;
                else
                {
                    ReturnCode = Response[0];
                    return false;
                }


            }
            else
                return false;

         

        }


        public bool CMD_Halt(out byte ReturnCode)
        {

            byte[] Response = new byte[24];
            byte[] DataBuffer = new byte[20];
            byte Count = 0;
            ReturnCode = 0;

            port.ReadExisting(); //Just to clear Buffer;
            send_command(0x93, DataBuffer, 0); // 0x83 = SELECT_TAG

            //Wait response of the operation

            if (get_response(out Response, out Count))
            {
                get_data(ref Response, ref Count);          //This will filter only data partion of the whole incoming data(Remove Header,Command,Length,Checksum)

                if (Response[0] == 0x4C)
                    return true;
                else
                {
                    ReturnCode = Response[0];
                    return false;
                }


            }
            else
                return false;
        }


        public bool CMD_ReadBlock(byte BlockNo, out byte[] BlockData, out byte ReturnCode)
        {

            byte[] Response = new byte[24];
            byte[] DataBuffer = new byte[20];
            BlockData = new byte[16];
            byte Count = 0;
            byte i = 0;
            
            
            ReturnCode = 0;  // 0 Communication Error

            DataBuffer[0] = BlockNo;

            port.ReadExisting(); //Just to clear Buffer;
            send_command(0x86, DataBuffer, 1); // 0x86 = Read Block

            //Wait response of the operation

            if (get_response(out Response, out Count))
            {
                get_data(ref Response, ref Count);          //This will filter only data partion of the whole incoming data(Remove Header,Command,Length,Checksum)

                if (Count <= 1) //Means Error
                {

                    ReturnCode = Response[0];
                    return false;

                }
                else
                {
                    for (i = 0; i < 16; i++)
                    {
                        BlockData[i] = Response[i + 1];

                        ReturnCode = Response[0];
                     
                    }
                    return true;
                }


            }
            else
                return false;
        }


        private bool check_if_sector_trailer(byte BlockNo)
        {
            
            int remain = 0;
            int temp = 0;

            if (BlockNo <= 128)
            {
                temp = BlockNo;
                temp++;
                remain = temp % 4;

                if (remain == 0)
                {
                    return false;

                }
            }
            else
            {
                temp = BlockNo;
                temp++;
                remain = temp % 16;

                if (remain == 0)
                {
                    return false;

                }
            
            }

            return true;

        
        }


        public bool CMD_WriteBlock(byte BlockNo,byte[] BlockData, out byte ReturnCode)
        {

            byte[] Response = new byte[24];
            byte[] DataBuffer = new byte[20];
            byte Count = 0;
            byte i = 0;


            ReturnCode = 0;  // 0 Communication Error

            if (!check_if_sector_trailer(BlockNo))
            {
                ReturnCode = 1; //This is Sector Trailer block. Write to Sector Trailer block is not allowed with this function
                return false;

            }




            DataBuffer[0] = BlockNo;

            for(i=0;i<16;i++)
            DataBuffer[i+1] = BlockData[i];

            port.ReadExisting(); //Just to clear Buffer;
            send_command(0x89, DataBuffer, 17); // 0x89 = Write Block

            //Wait response of the operation

            if (get_response(out Response, out Count))
            {
                get_data(ref Response, ref Count);          //This will filter only data partion of the whole incoming data(Remove Header,Command,Length,Checksum)

                if (Count <= 1) //Means Error
                {

                    ReturnCode = Response[0];
                    return false;

                }
                else
                {
                    //Here we have 16 bytes of written data. But we wont process it.
                    //No need to send back, what data is written tag. Module already writeten and confirmeds written data with read operation

                    return true;
                }


            }
            else
                return false;
        }


        public bool CMD_ReadValue(byte BlockNo, out long Value, out byte ReturnCode)
        {

            byte[] Response = new byte[24];
            byte[] DataBuffer = new byte[20];
            byte Count = 0;
            
            Value = 0;
            ReturnCode = 0;  // 0 Communication Error

            DataBuffer[0] = BlockNo;

            port.ReadExisting(); //Just to clear Buffer;
            send_command(0x87, DataBuffer, 1); // 0x86 = Read Block

            //Wait response of the operation

            if (get_response(out Response, out Count))
            {
                get_data(ref Response, ref Count);          //This will filter only data partion of the whole incoming data(Remove Header,Command,Length,Checksum)

                if (Count < 5) //Means Error
                {

                    ReturnCode = Response[0];
                    return false;

                }
                else
                {
                    Value = BitConverter.ToInt32(Response,1);
                    return true;

                }


            }
            else
                return false;
        }


        public bool CMD_WriteValue(byte BlockNo,long Value, out byte ReturnCode)
        {

            byte[] Response = new byte[24];
            byte[] DataBuffer = new byte[20];
            byte[] ValueArray = new byte[8];
            byte Count = 0;
            byte i=0;

            ReturnCode = 0;  // 0 Communication Error


           if (!check_if_sector_trailer(BlockNo))
            {
                ReturnCode = 1; //This is Sector Trailer block. Sector Trailer block can not be Value Block
                return false;

            }


            DataBuffer[0] = BlockNo;
            ValueArray = BitConverter.GetBytes(Value);

            for (i = 0; i < 4; i++)
                DataBuffer[i + 1] = ValueArray[i];

            port.ReadExisting(); //Just to clear Buffer;
            send_command(0x8A, DataBuffer, 5); // 0x8A = Write Value

            //Wait response of the operation

            if (get_response(out Response, out Count))
            {
                get_data(ref Response, ref Count);          //This will filter only data partion of the whole incoming data(Remove Header,Command,Length,Checksum)

                if (Count < 5) //Means Error
                {

                    ReturnCode = Response[0];
                    return false;

                }
                else
                {
                    //No need to send back the read value, as module already compared it with written value.
                    return true;

                }


            }
            else
                return false;
        }



        public bool CMD_IncrementValue(byte BlockNo, long IncValue,out long NewValue, out byte ReturnCode)
        {

            byte[] Response = new byte[24];
            byte[] DataBuffer = new byte[20];
            byte[] ValueArray = new byte[8];
            byte Count = 0;
            byte i = 0;

            NewValue = 0;
            ReturnCode = 0;  // 0 Communication Error

            DataBuffer[0] = BlockNo;
            ValueArray = BitConverter.GetBytes(IncValue);

            for (i = 0; i < 4; i++)
            DataBuffer[i + 1] = ValueArray[i];

            port.ReadExisting(); //Just to clear Buffer;
            send_command(0x8D, DataBuffer, 5); // 0x8D = Increment Value

            //Wait response of the operation

            if (get_response(out Response, out Count))
            {
                get_data(ref Response, ref Count);          //This will filter only data partion of the whole incoming data(Remove Header,Command,Length,Checksum)

                if (Count < 5) //Means Error
                {

                    ReturnCode = Response[0];
                    return false;

                }
                else
                {
                    NewValue = BitConverter.ToInt32(Response, 1);
                    return true;
                }


            }
            else
                return false;
        }


        public bool CMD_DecrementValue(byte BlockNo, long DecValue, out long NewValue, out byte ReturnCode)
        {

            byte[] Response = new byte[24];
            byte[] DataBuffer = new byte[20];
            byte[] ValueArray = new byte[8];
            byte Count = 0;
            byte i = 0;

            NewValue = 0;
            ReturnCode = 0;  // 0 Communication Error

            DataBuffer[0] = BlockNo;
            ValueArray = BitConverter.GetBytes(DecValue);

            for (i = 0; i < 4; i++)
                DataBuffer[i + 1] = ValueArray[i];

            port.ReadExisting(); //Just to clear Buffer;
            send_command(0x8E, DataBuffer, 5); // 0x8E = Decrement Value

            //Wait response of the operation

            if (get_response(out Response, out Count))
            {
                get_data(ref Response, ref Count);          //This will filter only data partion of the whole incoming data(Remove Header,Command,Length,Checksum)

                if (Count < 5) //Means Error
                {

                    ReturnCode = Response[0];
                    return false;

                }
                else
                {
                    NewValue = BitConverter.ToInt32(Response, 1);
                    return true;
                }


            }
            else
                return false;
        }



        public bool CMD_SwitchRF(bool OnOffState, out byte ReturnCode)
        {

            byte[] Response = new byte[24];
            byte[] DataBuffer = new byte[20];
            byte Count = 0;
            
            ReturnCode = 0;  // 0 Communication Error

            if (OnOffState)
                DataBuffer[0] = 0xFF;
            else
                DataBuffer[0] = 0;
            
            port.ReadExisting(); //Just to clear Buffer;
            send_command(0x90, DataBuffer, 1); // 0x90 = Switc RF ON/OFF Command

            //Wait response of the operation

            if (get_response(out Response, out Count))
            {
                get_data(ref Response, ref Count);          //This will filter only data partion of the whole incoming data(Remove Header,Command,Length,Checksum)

                if (Count == 1) //Success
                {
                    if ((Response[0]==0) || (Response[0]==1))
                    return true;
                    else
                    {
                        ReturnCode = Response[0];
                        return false;
                    }


                                       
                }
                else
                {
                    ReturnCode = Response[0];
                    return false;

                }


            }
            else
                return false;
        }


       
    }
}
