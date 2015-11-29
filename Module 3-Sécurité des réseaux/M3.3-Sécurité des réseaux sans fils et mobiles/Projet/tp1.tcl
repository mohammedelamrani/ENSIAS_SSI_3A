#nouveau simulateur
set ns [new Simulator]

#edition d'un fichier nam
set nf [open out.nam w]
$ns trace-all [open out.tr w]
$ns namtrace-all $nf

#la procedure finish
proc finish {} {
	global ns nf
	$ns flush-trace
	close $nf
	exec nam out.nam &
	exec gedit out.tr &
	exit 0
		}

#création de noeud
set n1 [$ns node]
set n2 [$ns node]
set n3 [$ns node]
set n4 [$ns node]
set r1 [$ns node]
set r2 [$ns node]

#création des liens
$ns duplex-link $n1 $r1 10Mb 15ms DropTail
$ns duplex-link $n2 $r1 10Mb 15ms DropTail
$ns duplex-link $n3 $r2 10Mb 15ms DropTail
$ns duplex-link $n4 $r2 10Mb 15ms DropTail
$ns duplex-link $r1 $r2 5Mb 40ms DropTail

#création des files d'attentes
$ns queue-limit $r1 $r2 50

#gestion du layout de la topologie
$ns duplex-link-op $n1 $r1 orient right-down
$ns duplex-link-op $n2 $r1 orient right-up
$ns duplex-link-op $r1 $r2 orient right
$ns duplex-link-op $r2 $n3 orient right-up
$ns duplex-link-op $r2 $n4 orient right-down

#creation des flux:

# f1: de n1 vers n4
set udp1 [new Agent/UDP]
set null4 [new Agent/Null]

$ns attach-agent $n1 $udp1
$ns attach-agent $n4 $null4
$ns connect $udp1 $null4

set cbr1 [new Application/Traffic/CBR]

$cbr1 set packetSize_ 1500
$cbr1 set interval_ 0.005
$cbr1 attach-agent $udp1

# f2: de n3 vers n1
set tcp1 [new Agent/TCP]
set tcp3 [new Agent/TCP]

$ns attach-agent $n1 $tcp1
$tcp1 set packetSize_ 1500
$ns attach-agent $n3 $tcp3
$tcp3 set packetSize_ 1500

$ns connect $tcp1 $tcp3

set ftp1 [new Application/FTP]
$ftp1 attach-agent $tcp1
set ftp3 [new Application/FTP]
$ftp3 attach-agent $tcp3

#f3 : de n4 vers n2
set tcp4 [new Agent/TCP]
set sink [new Agent/TCPSink]

$ns attach-agent $n4 $tcp4
$tcp4 set packetSize_ 1500
$ns attach-agent $n2 $sink

$ns connect $tcp4 $sink

set exp [new Application/Traffic/Exponential]
$exp attach-agent $tcp4

#Scénario des flux de simulation
$ns at 0.0 "$cbr1 start"
$ns at 0.2 "$ftp1 start"
$ns at 0.2 "$ftp3 start"
$ns at 3.1 "$exp start"

$ns at 6.0 "$cbr1 stop"
$ns at 2.9 "$ftp1 stop"
$ns at 2.9 "$ftp3 stop"
$ns at 5.8 "$exp stop"

$ns at 6.0 "finish"

$ns run

