set val(chan)           Channel/WirelessChannel    ;#Channel Type
set val(prop)           Propagation/TwoRayGround   ;# radio-propagation model
set val(netif)          Phy/WirelessPhy            ;# network interface type
set val(mac)            Mac/802_11                 ;# MAC type
set val(ifq)            Queue/DropTail/PriQueue    ;# interface queue type
set val(ll)             LL                         ;# link layer type
set val(ant)            Antenna/OmniAntenna        ;# antenna model
set val(ifqlen)         50                         ;# max packet in ifq
set val(nn)             0                        ;# number of mobilenodes
set val(rp)             DSDV                       ;# routing protocol
#set val(rp)             DSR                       ;# routing protocol
#espace de travail
set val(x)		1000
set val(y)		1000

# déclaration d'un simulateur
set ns_		[new Simulator]
#ouverture du fichier trace
set tracefd     [open tp_2.tr w]
$ns_ trace-all $tracefd
#ouverture du fichier nam
set namtrace [open tp_2.nam w]
$ns_ namtrace-all-wireless $namtrace $val(x) $val(y)

# set up topography object
set topo       [new Topography]

$topo load_flatgrid $val(x) $val(y)
# Create God
create-god $val(nn)
# New API to config node: 
# 1. Create channel (or multiple-channels);
# 2. Specify channel in node-config (instead of channelType);
# 3. Create nodes for simulations.

# Create channel #1 and #2
set chan_1_ [new $val(chan)]

# Create node(0) "attached" to channel #1

# configure node, please note the change below.
$ns_ node-config -adhocRouting $val(rp) \
		-llType $val(ll) \
		-macType $val(mac) \
		-ifqType $val(ifq) \
		-ifqLen $val(ifqlen) \
		-antType $val(ant) \
		-propType $val(prop) \
		-phyType $val(netif) \
		-topoInstance $topo \
		-agentTrace ON \
		-routerTrace ON \
		-macTrace ON \
		-movementTrace OFF \
		-channel $chan_1_ 

set node_(0) [$ns_ node]
set node_(1) [$ns_ node]
set node_(2) [$ns_ node]
set node_(3) [$ns_ node]
set node_(4) [$ns_ node]
set node_(5) [$ns_ node]
set node_(6) [$ns_ node]
$node_(0) random-motion 0
$node_(1) random-motion 0
$node_(2) random-motion 0
$node_(3) random-motion 0
$node_(4) random-motion 0
$node_(5) random-motion 0
$node_(6) random-motion 0
for {set i 0} {$i < $val(nn)} {incr i} {
	$ns_ initial_node_pos $node_($i) 20
}

#
# Provide initial (X,Y, for now Z=0) co-ordinates for mobilenodes
#
$node_(0) set X_ 5.0
$node_(0) set Y_ 2.0
$node_(0) set Z_ 0.0

$node_(1) set X_ 5.0
$node_(1) set Y_ 400.0
$node_(1) set Z_ 0.0

$node_(2) set X_ 50.0
$node_(2) set Y_ 200.0
$node_(2) set Z_ 0.0

$node_(3) set X_ 190.0
$node_(3) set Y_ 200.0
$node_(3) set Z_ 0.0

$node_(4) set Y_ 200.0
$node_(4) set X_ 320.0
$node_(4) set Z_ 0.0

$node_(5) set Y_ 2.0
$node_(5) set X_ 450.0
$node_(5) set Z_ 0.0

$node_(6) set Y_ 400.0
$node_(6) set X_ 450.0
$node_(6) set Z_ 0.0
# Now produce some simple node movements
# Node_(1) starts to move towards node_(0)
#%
$ns_ at 1.0 "$node_(0) setdest 5.0 2.0 0.0"
$ns_ at 1.0 "$node_(1) setdest 5.0 400.0 5.0"
$ns_ at 1.0 "$node_(2) setdest 50.0 200.0 25.0"
$ns_ at 1.0 "$node_(3) setdest 190.0 200.0 5.0"
$ns_ at 1.0 "$node_(4) setdest 320.0 200.0 5.0"
$ns_ at 1.0 "$node_(5) setdest 450.0 2.0 25.0"
$ns_ at 1.0 "$node_(6) setdest 450.0 400.0 5.0"

# Setup traffic flow between nodes


#create TCP/Reno agent
set tcp1 [new Agent/TCP/Reno]
#create TCP/Vegas agent
set tcp2 [new Agent/TCP/Vegas]
#attacher l'agent au noeud0
$ns_ attach-agent $node_(0) $tcp1
#create TCPSink agent ( traffic sink)
set sink1 [new Agent/TCPSink]
#attacher l'agent au noeud5
$ns_ attach-agent $node_(5) $sink1
#connect the trafic source with the trafic sink
$ns_ connect $tcp1 $sink1
#attacher l'agent au noeud1
$ns_ attach-agent $node_(1) $tcp2
#create TCPSink agent ( traffic sink)
set sink2 [new Agent/TCPSink]
#attacher l'agent au noeud6
$ns_ attach-agent $node_(6) $sink2
#connect the trafic source with the trafic sink
$ns_ connect $tcp2 $sink2

set ftp1 [new Application/FTP]
$ftp1 attach-agent $tcp1
$ns_ at 2.0 "$ftp1 start" 
$ns_ at 300.0 "$ftp1 stop" 
set ftp2 [new Application/FTP]
$ftp2 attach-agent $tcp2
$ns_ at 3.0 "$ftp2 start" 
$ns_ at 400.0 "$ftp1 stop" 
 
#
# Tell nodes when the simulation ends
#
for {set i 0} {$i < $val(nn) } {incr i} {
    $ns_ at 400.0 "$node_($i) reset";
}
$ns_ at 400.0 "stop"
$ns_ at 400.01 "puts \"NS EXITING...\" ; $ns_ halt"
proc stop {} {
    global ns_ tracefd
    $ns_ flush-trace
    close $tracefd
    exec nam  tp_2.nam
    exit 0
}

puts "Starting Simulation..."
$ns_ run




