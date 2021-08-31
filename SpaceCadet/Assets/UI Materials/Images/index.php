<?php

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 VARIABLES FROM THE USER'S FORM INPUT
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

$number01 = $_POST["number01"];
$number02 = $_POST["number02"];
$guess = $_POST["guess"];
$controlMsgCount = $_POST["controlMsgCount"];
$status = $_POST["status"];
$hpShields = $_POST["hpShields"];
$hpEngines = $_POST["hpEnergy"];
$stage = $_POST["stage"];

$Pct = "%";
$Comma = ",";
$Apst = "'";
$deg = "deg";
$px = "px";

/* position randomizers */

#theship {width: 240px; position: absolute; top: 220px; left: 200px; transform: rotate(15deg); z-index: -3;}

$spaceBattle = "";

$shipTop = "150";
$shipLeft = "100";
$shipRotation = "0";

$enemy01shipTop = mt_rand(10,500); $enemy01shipLeft = mt_rand(50,400); $enemy01shipRotation = mt_rand(1,360); $enemy01shipSize = mt_rand(60,100);
$enemy02shipTop = mt_rand(10,500); $enemy02shipLeft = mt_rand(50,400); $enemy02shipRotation = mt_rand(1,360); $enemy02shipSize = mt_rand(60,100);
$enemy03shipTop = mt_rand(10,500); $enemy03shipLeft = mt_rand(50,400); $enemy03shipRotation = mt_rand(1,360); $enemy03shipSize = mt_rand(60,100);
$enemy04shipTop = mt_rand(10,500); $enemy04shipLeft = mt_rand(50,400); $enemy04shipRotation = mt_rand(1,360); $enemy04shipSize = mt_rand(60,100);
$enemy05shipTop = mt_rand(10,500); $enemy05shipLeft = mt_rand(50,400); $enemy05shipRotation = mt_rand(1,360); $enemy05shipSize = mt_rand(60,100);
$enemy06shipTop = mt_rand(10,500); $enemy06shipLeft = mt_rand(50,400); $enemy06shipRotation = mt_rand(1,360); $enemy06shipSize = mt_rand(60,100);
$enemy07shipTop = mt_rand(10,500); $enemy07shipLeft = mt_rand(50,400); $enemy07shipRotation = mt_rand(1,360); $enemy07shipSize = mt_rand(60,100);
$enemy08shipTop = mt_rand(10,500); $enemy08shipLeft = mt_rand(50,400); $enemy08shipRotation = mt_rand(1,360); $enemy08shipSize = mt_rand(60,100);
$enemy09shipTop = mt_rand(10,500); $enemy09shipLeft = mt_rand(50,400); $enemy09shipRotation = mt_rand(1,360); $enemy09shipSize = mt_rand(60,100);
$enemy10shipTop = mt_rand(10,500); $enemy10shipLeft = mt_rand(50,400); $enemy10shipRotation = mt_rand(1,360); $enemy10shipSize = mt_rand(60,100);
$enemy11shipTop = mt_rand(10,500); $enemy11shipLeft = mt_rand(50,400); $enemy11shipRotation = mt_rand(1,360); $enemy11shipSize = mt_rand(60,100);
$enemy12shipTop = mt_rand(10,500); $enemy12shipLeft = mt_rand(50,400); $enemy12shipRotation = mt_rand(1,360); $enemy12shipSize = mt_rand(60,100);

$missile001Top = mt_rand(50,500); $missile001Left = mt_rand(100,300); $missle001Rotation = mt_rand(1,360);
$missile002Top = mt_rand(50,500); $missile002Left = mt_rand(100,300); $missle002Rotation = mt_rand(1,360);
$missile003Top = mt_rand(50,500); $missile003Left = mt_rand(100,300); $missle003Rotation = mt_rand(1,360);
$missile004Top = mt_rand(50,500); $missile004Left = mt_rand(100,300); $missle004Rotation = mt_rand(1,360);
$missile005Top = mt_rand(50,500); $missile005Left = mt_rand(100,300); $missle005Rotation = mt_rand(1,360);
$missile006Top = mt_rand(50,500); $missile006Left = mt_rand(100,300); $missle006Rotation = mt_rand(1,360);
$missile007Top = mt_rand(50,500); $missile007Left = mt_rand(100,300); $missle007Rotation = mt_rand(1,360);
$missile008Top = mt_rand(50,500); $missile008Left = mt_rand(100,300); $missle008Rotation = mt_rand(1,360);
$missile009Top = mt_rand(50,500); $missile009Left = mt_rand(100,300); $missle009Rotation = mt_rand(1,360);
$missile010Top = mt_rand(50,500); $missile010Left = mt_rand(100,300); $missle010Rotation = mt_rand(1,360);
$missile011Top = mt_rand(50,500); $missile011Left = mt_rand(100,300); $missle011Rotation = mt_rand(1,360);
$missile012Top = mt_rand(50,500); $missile012Left = mt_rand(100,300); $missle012Rotation = mt_rand(1,360);
$missile013Top = mt_rand(50,500); $missile013Left = mt_rand(100,300); $missle013Rotation = mt_rand(1,360);
$missile014Top = mt_rand(50,500); $missile014Left = mt_rand(100,300); $missle014Rotation = mt_rand(1,360);
$missile015Top = mt_rand(50,500); $missile015Left = mt_rand(100,300); $missle015Rotation = mt_rand(1,360);
$missile016Top = mt_rand(50,500); $missile016Left = mt_rand(100,300); $missle016Rotation = mt_rand(1,360);
$missile017Top = mt_rand(50,500); $missile017Left = mt_rand(100,300); $missle017Rotation = mt_rand(1,360);
$missile018Top = mt_rand(50,500); $missile018Left = mt_rand(100,300); $missle018Rotation = mt_rand(1,360);
$missile019Top = mt_rand(50,500); $missile019Left = mt_rand(100,300); $missle019Rotation = mt_rand(1,360);

$missile020Top = mt_rand(50,500); $missile020Left = mt_rand(100,300); $missle020Rotation = mt_rand(1,360);
$missile021Top = mt_rand(50,500); $missile021Left = mt_rand(100,300); $missle021Rotation = mt_rand(1,360);
$missile022Top = mt_rand(50,500); $missile022Left = mt_rand(100,300); $missle022Rotation = mt_rand(1,360);
$missile023Top = mt_rand(50,500); $missile023Left = mt_rand(100,300); $missle023Rotation = mt_rand(1,360);
$missile024Top = mt_rand(50,500); $missile024Left = mt_rand(100,300); $missle024Rotation = mt_rand(1,360);
$missile025Top = mt_rand(50,500); $missile025Left = mt_rand(100,300); $missle025Rotation = mt_rand(1,360);
$missile026Top = mt_rand(50,500); $missile026Left = mt_rand(100,300); $missle026Rotation = mt_rand(1,360);
$missile027Top = mt_rand(50,500); $missile027Left = mt_rand(100,300); $missle027Rotation = mt_rand(1,360);
$missile028Top = mt_rand(50,500); $missile028Left = mt_rand(100,300); $missle028Rotation = mt_rand(1,360);
$missile029Top = mt_rand(50,500); $missile029Left = mt_rand(100,300); $missle029Rotation = mt_rand(1,360);

$missile030Top = mt_rand(50,500); $missile030Left = mt_rand(100,300); $missle030Rotation = mt_rand(1,360);
$missile031Top = mt_rand(50,500); $missile031Left = mt_rand(100,300); $missle031Rotation = mt_rand(1,360);
$missile032Top = mt_rand(50,500); $missile032Left = mt_rand(100,300); $missle032Rotation = mt_rand(1,360);
$missile033Top = mt_rand(50,500); $missile033Left = mt_rand(100,300); $missle033Rotation = mt_rand(1,360);
$missile034Top = mt_rand(50,500); $missile034Left = mt_rand(100,300); $missle034Rotation = mt_rand(1,360);
$missile035Top = mt_rand(50,500); $missile035Left = mt_rand(100,300); $missle035Rotation = mt_rand(1,360);
$missile036Top = mt_rand(50,500); $missile036Left = mt_rand(100,300); $missle036Rotation = mt_rand(1,360);
$missile037Top = mt_rand(50,500); $missile037Left = mt_rand(100,300); $missle037Rotation = mt_rand(1,360);
$missile038Top = mt_rand(50,500); $missile038Left = mt_rand(100,300); $missle038Rotation = mt_rand(1,360);
$missile039Top = mt_rand(50,500); $missile039Left = mt_rand(100,300); $missle039Rotation = mt_rand(1,360);


/* display styles and positions */
$CSSstyles = "<style type=\"text/css\"><!--

body {
	margin: 0; padding: 0;
	background-color: #000; 
	background-image: url(starfield.gif);
	}

.wrp {
	width: 700px;
	margin-right:auto; margin-left:auto; margin-top: 0px; margin-bottom: 10px;
	padding: 0;
	position: relative;
	}

a:link {color: #fff; text-decoration: none; border-bottom: 0px solid #fff;}
a:visited {color: #fff; text-decoration: none; border-bottom: 0px solid #fff;}
a:hover  {color: #fff; text-decoration: none; border-bottom: 0px solid #CC6633;}
a:active {color: #fff; text-decoration: none; border-bottom: 0px solid #fff;}

.spacebattle {
	float: right;
	width: 400px; margin: 0; padding: 0;
	z-index: 0;
	position: relative;
}

.cntlpanel {
	float: left;
	width: 293px; margin: 5px 0 0 0; padding: 0;
	background-color: #000; 
	background-image: url(cntlbar-bkgd.png);
	background-repeat: repeat-y;
	text-align: center;
	z-index: 0;
}

div {margin: 0; padding: 0;}
form {margin: 0; padding: 0;}
img {margin: 0; padding: 0; border: 0;}

.msg01 {width: 290px; margin; 0; padding: 0; font: bold 30px/1.0em 'Londrina Solid', arial, helvetica; color: #fff; text-shadow: 2px 2px #000; letter-spacing: 0em; text-align: center;}
.msg02 {width: 290px; margin; 0; padding: 15px 0 0 0; font: bold 24px/1.15em 'Londrina Solid', arial, helvetica; text-shadow: 1px 1px #000; color: #fff; letter-spacing: 0.05em; text-align: center;}
.msg03 {width: 260px; margin; 0; padding: 15px 15px 15px 15px; font: bold 18px/1.15em 'Londrina Solid', arial, helvetica; text-shadow: 1px 1px #000; color: #fff; letter-spacing: 0.05em; text-align: center;}
.msg04 {width: 290px; margin; 0; padding: 0; font: bold 30px/1.0em 'Londrina Solid', arial, helvetica; color: #fff; text-shadow: 2px 2px #000; letter-spacing: 0.05em; text-align: center;}

.trgt {margin: 0 0 0 4px; padding: 4px; background-color: #666; border: 2px solid #fff; font: bold 24px/1.0em arial, helvetica; color: #fff; text-align: center;}
.fire {width: 200px; margin: 20px 0 20px 0; padding: 8px; font: bold 14px/1.0em arial, helvetica; color: #ffe0e0; letter-spacing: 0.5em;
	background-color: #f00;
	background-image: url(firebkg.png);
	background-repeat: repeat-x;
	border: 1px solid #fcc;
	-moz-box-shadow:    3px 3px 5px 5px #333;
	-webkit-box-shadow: 3px 3px 5px 5px #333;
	box-shadow:         3px 3px 5px 5px #333;
}
.next {width: 200px; margin: 20px 0 20px 0; padding: 8px; font: bold 14px/1.0em arial, helvetica; color: #00ffff; letter-spacing: 0.5em;
	background-color: #000;
	border: 1px solid #00ffff;
	-moz-box-shadow:    3px 3px 5px 5px #333;
	-webkit-box-shadow: 3px 3px 5px 5px #333;
	box-shadow:         3px 3px 5px 5px #333;
}
.fx01 {margin: 0 0 -5px 0;}

#theship {width: 240px; position: absolute; top: $shipTop$px; left: $shipLeft$px; transform: rotate($shipRotation$deg); z-index: -3;}

#enemy01 {width: 150px; position: absolute; top: $enemy01shipTop$px; left: $enemy01shipLeft$px; transform: rotate($enemy01shipRotation$deg); z-index: -2;}
#enemy02 {width: 150px; position: absolute; top: $enemy02shipTop$px; left: $enemy02shipLeft$px; transform: rotate($enemy02shipRotation$deg); z-index: -2;}
#enemy03 {width: 150px; position: absolute; top: $enemy03shipTop$px; left: $enemy03shipLeft$px; transform: rotate($enemy03shipRotation$deg); z-index: -2;}
#enemy04 {width: 150px; position: absolute; top: $enemy04shipTop$px; left: $enemy04shipLeft$px; transform: rotate($enemy04shipRotation$deg); z-index: -2;}
#enemy05 {width: 150px; position: absolute; top: $enemy05shipTop$px; left: $enemy05shipLeft$px; transform: rotate($enemy05shipRotation$deg); z-index: -2;}
#enemy06 {width: 150px; position: absolute; top: $enemy06shipTop$px; left: $enemy06shipLeft$px; transform: rotate($enemy06shipRotation$deg); z-index: -2;}
#enemy07 {width: 150px; position: absolute; top: $enemy07shipTop$px; left: $enemy07shipLeft$px; transform: rotate($enemy07shipRotation$deg); z-index: -2;}
#enemy08 {width: 150px; position: absolute; top: $enemy08shipTop$px; left: $enemy08shipLeft$px; transform: rotate($enemy08shipRotation$deg); z-index: -2;}
#enemy09 {width: 150px; position: absolute; top: $enemy09shipTop$px; left: $enemy09shipLeft$px; transform: rotate($enemy09shipRotation$deg); z-index: -2;}
#enemy10 {width: 150px; position: absolute; top: $enemy10shipTop$px; left: $enemy10shipLeft$px; transform: rotate($enemy10shipRotation$deg); z-index: -2;}
#enemy11 {width: 150px; position: absolute; top: $enemy11shipTop$px; left: $enemy11shipLeft$px; transform: rotate($enemy11shipRotation$deg); z-index: -2;}
#enemy12 {width: 150px; position: absolute; top: $enemy12shipTop$px; left: $enemy12shipLeft$px; transform: rotate($enemy12shipRotation$deg); z-index: -2;}

#enemy01 img {width: $enemy01shipSize$Pct; height: auto;}
#enemy02 img {width: $enemy02shipSize$Pct; height: auto;}
#enemy03 img {width: $enemy03shipSize$Pct; height: auto;}
#enemy04 img {width: $enemy04shipSize$Pct; height: auto;}
#enemy05 img {width: $enemy05shipSize$Pct; height: auto;}
#enemy06 img {width: $enemy06shipSize$Pct; height: auto;}
#enemy07 img {width: $enemy07shipSize$Pct; height: auto;}
#enemy08 img {width: $enemy08shipSize$Pct; height: auto;}
#enemy09 img {width: $enemy09shipSize$Pct; height: auto;}
#enemy10 img {width: $enemy10shipSize$Pct; height: auto;}
#enemy11 img {width: $enemy11shipSize$Pct; height: auto;}
#enemy12 img {width: $enemy12shipSize$Pct; height: auto;}

#missile001 {width: 30px; position: absolute; top: $missile001Top$px; left: $missile001Left$px; transform: rotate($missle001Rotation$deg); z-index: -3;}
#missile002 {width: 30px; position: absolute; top: $missile002Top$px; left: $missile002Left$px; transform: rotate($missle002Rotation$deg); z-index: -3;}
#missile003 {width: 30px; position: absolute; top: $missile003Top$px; left: $missile003Left$px; transform: rotate($missle003Rotation$deg); z-index: -3;}
#missile004 {width: 30px; position: absolute; top: $missile004Top$px; left: $missile004Left$px; transform: rotate($missle004Rotation$deg); z-index: -3;}
#missile005 {width: 30px; position: absolute; top: $missile005Top$px; left: $missile005Left$px; transform: rotate($missle005Rotation$deg); z-index: -3;}
#missile006 {width: 30px; position: absolute; top: $missile006Top$px; left: $missile006Left$px; transform: rotate($missle006Rotation$deg); z-index: -3;}
#missile007 {width: 30px; position: absolute; top: $missile007Top$px; left: $missile007Left$px; transform: rotate($missle007Rotation$deg); z-index: -3;}
#missile008 {width: 30px; position: absolute; top: $missile008Top$px; left: $missile008Left$px; transform: rotate($missle008Rotation$deg); z-index: -3;}
#missile009 {width: 30px; position: absolute; top: $missile009Top$px; left: $missile009Left$px; transform: rotate($missle009Rotation$deg); z-index: -3;}
#missile010 {width: 30px; position: absolute; top: $missile010Top$px; left: $missile010Left$px; transform: rotate($missle010Rotation$deg); z-index: -3;}
#missile011 {width: 30px; position: absolute; top: $missile011Top$px; left: $missile011Left$px; transform: rotate($missle011Rotation$deg); z-index: -3;}
#missile012 {width: 30px; position: absolute; top: $missile012Top$px; left: $missile012Left$px; transform: rotate($missle012Rotation$deg); z-index: -3;}
#missile013 {width: 30px; position: absolute; top: $missile013Top$px; left: $missile013Left$px; transform: rotate($missle013Rotation$deg); z-index: -3;}
#missile014 {width: 30px; position: absolute; top: $missile014Top$px; left: $missile014Left$px; transform: rotate($missle014Rotation$deg); z-index: -3;}
#missile015 {width: 30px; position: absolute; top: $missile015Top$px; left: $missile015Left$px; transform: rotate($missle015Rotation$deg); z-index: -3;}
#missile016 {width: 30px; position: absolute; top: $missile016Top$px; left: $missile016Left$px; transform: rotate($missle016Rotation$deg); z-index: -3;}
#missile017 {width: 30px; position: absolute; top: $missile017Top$px; left: $missile017Left$px; transform: rotate($missle017Rotation$deg); z-index: -3;}
#missile018 {width: 30px; position: absolute; top: $missile018Top$px; left: $missile018Left$px; transform: rotate($missle018Rotation$deg); z-index: -3;}
#missile019 {width: 30px; position: absolute; top: $missile019Top$px; left: $missile019Left$px; transform: rotate($missle019Rotation$deg); z-index: -3;}

#missile020 {width: 30px; position: absolute; top: $missile010Top$px; left: $missile010Left$px; transform: rotate($missle010Rotation$deg); z-index: -3;}
#missile021 {width: 30px; position: absolute; top: $missile011Top$px; left: $missile011Left$px; transform: rotate($missle011Rotation$deg); z-index: -3;}
#missile022 {width: 30px; position: absolute; top: $missile012Top$px; left: $missile012Left$px; transform: rotate($missle012Rotation$deg); z-index: -3;}
#missile023 {width: 30px; position: absolute; top: $missile013Top$px; left: $missile013Left$px; transform: rotate($missle013Rotation$deg); z-index: -3;}
#missile024 {width: 30px; position: absolute; top: $missile014Top$px; left: $missile014Left$px; transform: rotate($missle014Rotation$deg); z-index: -3;}
#missile025 {width: 30px; position: absolute; top: $missile015Top$px; left: $missile015Left$px; transform: rotate($missle015Rotation$deg); z-index: -3;}
#missile026 {width: 30px; position: absolute; top: $missile016Top$px; left: $missile016Left$px; transform: rotate($missle016Rotation$deg); z-index: -3;}
#missile027 {width: 30px; position: absolute; top: $missile017Top$px; left: $missile017Left$px; transform: rotate($missle017Rotation$deg); z-index: -3;}
#missile028 {width: 30px; position: absolute; top: $missile018Top$px; left: $missile018Left$px; transform: rotate($missle018Rotation$deg); z-index: -3;}
#missile029 {width: 30px; position: absolute; top: $missile019Top$px; left: $missile019Left$px; transform: rotate($missle019Rotation$deg); z-index: -3;}

#missile030 {width: 30px; position: absolute; top: $missile010Top$px; left: $missile010Left$px; transform: rotate($missle010Rotation$deg); z-index: -3;}
#missile031 {width: 30px; position: absolute; top: $missile011Top$px; left: $missile011Left$px; transform: rotate($missle011Rotation$deg); z-index: -3;}
#missile032 {width: 30px; position: absolute; top: $missile012Top$px; left: $missile012Left$px; transform: rotate($missle012Rotation$deg); z-index: -3;}
#missile033 {width: 30px; position: absolute; top: $missile013Top$px; left: $missile013Left$px; transform: rotate($missle013Rotation$deg); z-index: -3;}
#missile034 {width: 30px; position: absolute; top: $missile014Top$px; left: $missile014Left$px; transform: rotate($missle014Rotation$deg); z-index: -3;}
#missile035 {width: 30px; position: absolute; top: $missile015Top$px; left: $missile015Left$px; transform: rotate($missle015Rotation$deg); z-index: -3;}
#missile036 {width: 30px; position: absolute; top: $missile016Top$px; left: $missile016Left$px; transform: rotate($missle016Rotation$deg); z-index: -3;}
#missile037 {width: 30px; position: absolute; top: $missile017Top$px; left: $missile017Left$px; transform: rotate($missle017Rotation$deg); z-index: -3;}
#missile038 {width: 30px; position: absolute; top: $missile018Top$px; left: $missile018Left$px; transform: rotate($missle018Rotation$deg); z-index: -3;}
#missile039 {width: 30px; position: absolute; top: $missile019Top$px; left: $missile019Left$px; transform: rotate($missle019Rotation$deg); z-index: -3;}



--></style>";



/* cute messages to display on the NEUTRAL status screen */
if($controlMsgCount > "27") {$controlMsgCount = "2";}
if($controlMsgCount == "1") {$controlMsg = "We're trucking<br />along in space...";}
elseif($controlMsgCount == "2") {$controlMsg = "Running systems<br />diagnotics...";}
elseif($controlMsgCount == "3") {$controlMsg = "Tuning ship's<br />gravimetric fields...";}
elseif($controlMsgCount == "4") {$controlMsg = "Adjusting vectors<br />to compensate...";}
elseif($controlMsgCount == "5") {$controlMsg = "Purging auxilary<br />thrusters...";}
elseif($controlMsgCount == "6") {$controlMsg = "Resetting tetryon<br />source regulator...";}
elseif($controlMsgCount == "7") {$controlMsg = "Calibrating harmonic<br />induction...";}
elseif($controlMsgCount == "8") {$controlMsg = "Filtering plasma<br />inhibitor...";}
elseif($controlMsgCount == "9") {$controlMsg = "Aligning phased<br />flux grid...";}
elseif($controlMsgCount == "10") {$controlMsg = "Refilling baryon<br />reaction coolant...";}
elseif($controlMsgCount == "11") {$controlMsg = "Stabilizing primary<br />field loop...";}
elseif($controlMsgCount == "12") {$controlMsg = "Boosting dorsal<br />reaction grid...";}
elseif($controlMsgCount == "13") {$controlMsg = "Rebooting nucleonic<br />logic actuator...";}
elseif($controlMsgCount == "14") {$controlMsg = "Confirming multiphasic<br />stabilizer...";}
elseif($controlMsgCount == "15") {$controlMsg = "Recharging<br />dampening coil...";}
elseif($controlMsgCount == "16") {$controlMsg = "Clearing tachyon<br />discrimator...";}
elseif($controlMsgCount == "17") {$controlMsg = "Tuning neutrino<br />feed grid...";}
elseif($controlMsgCount == "18") {$controlMsg = "Applying new<br />non-linear algorithm...";}
elseif($controlMsgCount == "19") {$controlMsg = "Uploading new<br />pulse algorithm...";}
elseif($controlMsgCount == "20") {$controlMsg = "Replacing magnetic<br />coupling...";}
elseif($controlMsgCount == "21") {$controlMsg = "Checking displacement<br />matrix...";}
elseif($controlMsgCount == "22") {$controlMsg = "Cooling thermal<br />regulators...";}
elseif($controlMsgCount == "23") {$controlMsg = "Relinking invariance<br />stabilizer...";}
elseif($controlMsgCount == "24") {$controlMsg = "Increasing phased<br />field discrimator...";}
elseif($controlMsgCount == "25") {$controlMsg = "Switching out<br />reciprocating program...";}
elseif($controlMsgCount == "26") {$controlMsg = "Ejecting dorsal<br />feed coolant...";}
elseif($controlMsgCount == "27") {$controlMsg = "Synching to<br />parallel coupling...";}


/* random additions to control panel messages, just because... */
$funfactNum = mt_rand(1,28);
if ($funfactNum == "1") {$funfact = "FUN FACT: In microgravity, a candle flame burns blue and is shaped like a sphere.";}
elseif ($funfactNum == "2") {$funfact = "FUN FACT: Outer space smells like burnt steak.";}
elseif ($funfactNum == "3") {$funfact = "FUN FACT: In the vaccum of space, it is totally silent. There's no air to allow sound to travel.";}
elseif ($funfactNum == "4") {$funfact = "FUN FACT: In Earth's solar system, the Sun makes up 99.86% of all mass.";}
elseif ($funfactNum == "5") {$funfact = "FUN FACT: A million Earths can fit inside the Sun.";}
elseif ($funfactNum == "6") {$funfact = "FUN FACT: There are more trees on Earth than stars in our galaxy.";}
elseif ($funfactNum == "7") {$funfact = "FUN FACT: The dusty red skies of Mars turn blue at sunset.";}
elseif ($funfactNum == "8") {$funfact = "FUN FACT: That loose power coupling under your chair is going to cause a big problem later.";}
elseif ($funfactNum == "9") {$funfact = "FUN FACT: From time to time, Jupiter's moon Io has giant volcanic eruptions on its surface.";}
elseif ($funfactNum == "10") {$funfact = "FUN FACT: The biggest volcano yet found in our solar system is Olympus Mons, found on Mars.";}
elseif ($funfactNum == "11") {$funfact = "FUN FACT: The Valles Marineris canyon on Mars is 10 times as long as the Grand Canyon on Earth.";}
elseif ($funfactNum == "12") {$funfact = "FUN FACT: Surveys of Mercury suggest the planet closest to the sun is shrinking year by year.";}
elseif ($funfactNum == "13") {$funfact = "FUN FACT: Some of the mountains on the dwarf planet Pluto reach heights of 11,000 feet (3,300 meters).";}
elseif ($funfactNum == "14") {$funfact = "FUN FACT: The giant storm on Jupiter called The Great Red Spot is three times as wide as Earth.";}
elseif ($funfactNum == "15") {$funfact = "FUN FACT: The clouds above Saturn's north pole form a perfect hexagon shape, with each of its six sides streching about 7,500 miles (12,500 kilometers).";}
elseif ($funfactNum == "16") {$funfact = "FUN FACT: A billion Earths could fit inside the rings around Saturn.";}
elseif ($funfactNum == "17") {$funfact = "FUN FACT: The jet stream winds on Nepture travel at more than 1,500 mph (2,400 kph).";}
elseif ($funfactNum == "18") {$funfact = "FUN FACT: The planet Uranus is so tilted on its axis, its north pole practically points at the Sun.";}
elseif ($funfactNum == "19") {$funfact = "FUN FACT: On Mercury, the daytime high temperature and nighttime low vary by 1,000 degrees F (620 degrees C).";}
elseif ($funfactNum == "20") {$funfact = "FUN FACT: On the surface of Earth's moon, you'd only weight 1/6 what you do on Earth, but those old pants you outgrew still wouldn't fit.";}
elseif ($funfactNum == "21") {$funfact = "FUN FACT: No matter how good the food, outdoor dining on the Moon always gets bad reviews from critics who complain it has no atmosphere.";}
elseif ($funfactNum == "22") {$funfact = "FUN FACT: Good books about anti-gravity are hard to put down.";}
elseif ($funfactNum == "23") {$funfact = "FUN FACT: Stars don’t twinkle until their light passes through the atmosphere around Earth.";}
elseif ($funfactNum == "24") {$funfact = "FUN FACT: To escape Earth’s gravity, a spacecraft must travel more than 25,000 mph (40,200 kph).";}
elseif ($funfactNum == "25") {$funfact = "FUN FACT: It takes 8 minutes and 20 seconds for the Sun's light to reach Earth.";}
elseif ($funfactNum == "26") {$funfact = "FUN FACT: It takes 1 billion seconds for the light from a star 31.7 light-years away to reach Earth.";}
elseif ($funfactNum == "27") {$funfact = "FUN FACT: Neutron stars can spin at a rate of 600 rotations per second.";}
elseif ($funfactNum == "28") {$funfact = "FUN FACT: If two pieces of the same type of metal touch in space, they will bond and be stuck together permanently.";}

/* calculating formula and answer */
$number01num = (int)$number01;
$number02num = (int)$number02;
$correctAnswer = ($number01num) * ($number02num);
$guessnum = (int)$guess;

$ResultLine = "";

if ($guess == $correctAnswer) {
	$ResultLine = "<div class=\"msg01\">PERFECT!</div><div class=\"msg02\">Good job!</div>";
	}
elseif ($guess > $correctAnswer) {
	$ResultLine = "<div class=\"msg01\">TOO MUCH ENERGY!</div><div class=\"msg03\">We only needed $correctAnswer gigawatts for the lasers! We stopped the missiles but might not have enough power for later...</div>";
	$hpEngines = $hpEngines - 1;
	}
elseif ($guess < $correctAnswer) {
	$ResultLine = "<div class=\"msg01\">NOT ENOUGH ENERGY!</div><div class=\"msg03\">We needed $correctAnswer gigawatts for the lasers! Our ship's energy shield is hit! We're losing power!</div>";
	$hpShields = $hpShields - 1;
	}

/* shield and energy bars */

$extraNumber01 = mt_rand(0,5);
$extraNumber02 = mt_rand(1,6);

if ($hpShields == "3") {$imgShields = "barShields03.gif"; $shieldPower = "100"; $shieldStatus = "Shields:&nbsp;$shieldPower$Pct &nbsp;";}
elseif ($hpShields == "2") {$imgShields = "barShields02.gif"; $shieldPower = "63" + $extraNumber01; $shieldStatus = "Shields:&nbsp;$shieldPower$Pct &nbsp;";}
elseif ($hpShields == "1") {$imgShields = "barShields01.gif"; $shieldPower = "31" + $extraNumber01; $shieldStatus = "Shields:&nbsp;$shieldPower$Pct &nbsp;";}
elseif ($hpShields <= "0") {$imgShields = "barZero.gif"; $shieldPower = "0"; $shieldStatus = "Shields:&nbsp;OFFLINE<br />";}

if ($hpEngines == "3") {$imgEngines = "barEngines03.gif"; $energyPower = "100"; $energyStatus = "Engines:&nbsp;$energyPower$Pct";}
elseif ($hpEngines == "2") {$imgEngines = "barEngines02.gif"; $energyPower = "63" + $extraNumber02; $energyStatus = "Engines:&nbsp;$energyPower$Pct";}
elseif ($hpEngines == "1") {$imgEngines = "barEngines01.gif";$energyPower = "31" + $extraNumber02; $energyStatus = "Engines:&nbsp;$energyPower$Pct";}
elseif ($hpEngines <= "0") {$imgEngines = "barZero.gif"; $energyStatus = "Engines:&nbsp;EXHAUSTED<br />";}

if ($hpShields == "3" AND $hpEngines == "3") {$overallStatus = "cntlbar03alliswell.png"; $shipImg = "shipShGoodEngGood.gif";}
if ($hpShields == "3" AND $hpEngines == "2") {$overallStatus = "cntlbar03caution.png"; $shipImg = "shipShGoodEngPoor.gif";}
if ($hpShields == "3" AND $hpEngines == "1") {$overallStatus = "cntlbar03danger.png"; $shipImg = "shipShGoodEngPoor.gif";}
if ($hpShields == "3" AND $hpEngines <= "0") {$overallStatus = "cntlbar03danger.png"; $shipImg = "shipShGoodEngDown.gif";}

if ($hpShields == "2" AND $hpEngines == "3") {$overallStatus = "cntlbar03caution.png"; $shipImg = "shipShPoorEngGood.gif";}
if ($hpShields == "2" AND $hpEngines == "2") {$overallStatus = "cntlbar03caution.png"; $shipImg = "shipShPoorEngPoor.gif";}
if ($hpShields == "2" AND $hpEngines == "1") {$overallStatus = "cntlbar03danger.png"; $shipImg = "shipShPoorEngPoor.gif";}
if ($hpShields == "2" AND $hpEngines <= "0") {$overallStatus = "cntlbar03danger.png"; $shipImg = "shipShPoorEngDown.gif";}

if ($hpShields == "1" AND $hpEngines == "3") {$overallStatus = "cntlbar03danger.png"; $shipImg = "shipShPoorEngGood.gif";}
if ($hpShields == "1" AND $hpEngines == "2") {$overallStatus = "cntlbar03danger.png"; $shipImg = "shipShPoorEngPoor.gif";}
if ($hpShields == "1" AND $hpEngines == "1") {$overallStatus = "cntlbar03danger.png"; $shipImg = "shipShPoorEngPoor.gif";}
if ($hpShields == "1" AND $hpEngines <= "0") {$overallStatus = "cntlbar03danger.png"; $shipImg = "shipShPoorEngDown.gif";}

if ($hpShields <= "0" AND $hpEngines == "3") {$overallStatus = "cntlbar03danger.png"; $shipImg = "shipShDownEngGood.gif";}
if ($hpShields <= "0" AND $hpEngines == "2") {$overallStatus = "cntlbar03danger.png"; $shipImg = "shipShDownEngPoor.gif";}
if ($hpShields <= "0" AND $hpEngines == "1") {$overallStatus = "cntlbar03danger.png"; $shipImg = "shipShDownEngPoor.gif";}
if ($hpShields <= "0" AND $hpEngines <= "0") {$overallStatus = "cntlbar03danger.png"; $shipImg = "shipShDownEngDown.gif";}

/* START SCREEN */
if ($status == "") {
$status = "start";
$controlMsgCount = "1";
$nextstatus = "neutral";
$spaceBattle = "<div id=\"theship\"><img src=\"$shipImg\" /></div>";
$controlMsg = "We're trucking along in space...";
$stage = "0";
}


/* NEUTRAL SCREEN */
if ($status == "neutral") {
$nextstatus = "attack";
$stage = $stage + "1";
$spaceBattle = "<div id=\"theship\"><img src=\"$shipImg\" /></div>";
$controlPanel = "<div class=\"cntlpanel\"><img src=\"cntlbar01.png\" width=\"293\" height=\"47\" border=\"0\" alt=\"OPS REPORT\" />
<div class=\"msg01\">$controlMsg</div>
<div class=\"msg03\">$shieldStatus$energyStatus</div>
<div class=\"msg03\">$funfact</div>
<div class=\"msg04\"><input type=\"submit\" name=\"submit\" class=\"next\" value=\"NEXT...\" /></div>
<img src=\"cntlbar02.png\" width=\"293\" height=\"47\" border=\"0\" alt=\"***\" />
<img src=\"$imgShields\" width=\"125\" height=\"135\" alt=\"Status Of Our Shields\">&nbsp;
<img src=\"$imgEngines\" width=\"125\" height=\"135\" alt=\"Status Of Our Engines\">
<img src=\"$overallStatus\" class=\"fx01\" width=\"293\" height=\"78\" border=\"0\" />
</div>
<br clear=\"all\" />
<input type=\"hidden\" name=\"number01\" value=\"0\">
<input type=\"hidden\" name=\"number02\" value=\"0\">
<input type=\"hidden\" name=\"hpShields\" value=\"$hpShields\">
<input type=\"hidden\" name=\"hpEnergy\" value=\"$hpEngines\">
<input type=\"hidden\" name=\"status\" value=\"$nextstatus\">
<input type=\"hidden\" name=\"controlMsgCount\" value=\"$controlMsgCount\">
<input type=\"hidden\" name=\"stage\" value=\"$stage\">";
}

/* ATTACK SCREEN */
if ($status == "attack") {
$firstNumber = $stage + mt_rand(1,2);
if($firstNumber > "12") {$firstNumber = "12";}
$secondNumber = mt_rand(2,12);
$volleySize = $firstNumber * $secondNumber;
$nextstatus = "outcome";
$MessageNext = mt_rand(1,6);
$controlMsgCount = $controlMsgCount + $MessageNext;
$spaceBattle = "<div id=\"theship\"><img src=\"$shipImg\" /></div>";
if ($firstNumber >= "2") {$spaceBattle = "$spaceBattle <div id=\"enemy01\"><img src=\"enemyship.png\" /></div><div id=\"enemy02\"><img src=\"enemyship.png\" /></div>";}
if ($firstNumber >= "3") {$spaceBattle = "$spaceBattle <div id=\"enemy03\"><img src=\"enemyship.png\" /></div>";}
if ($firstNumber >= "4") {$spaceBattle = "$spaceBattle <div id=\"enemy04\"><img src=\"enemyship.png\" /></div>";}
if ($firstNumber >= "5") {$spaceBattle = "$spaceBattle <div id=\"enemy05\"><img src=\"enemyship.png\" /></div>";}
if ($firstNumber >= "6") {$spaceBattle = "$spaceBattle <div id=\"enemy06\"><img src=\"enemyship.png\" /></div>";}
if ($firstNumber >= "7") {$spaceBattle = "$spaceBattle <div id=\"enemy07\"><img src=\"enemyship.png\" /></div>";}
if ($firstNumber >= "8") {$spaceBattle = "$spaceBattle <div id=\"enemy08\"><img src=\"enemyship.png\" /></div>";}
if ($firstNumber >= "9") {$spaceBattle = "$spaceBattle <div id=\"enemy09\"><img src=\"enemyship.png\" /></div>";}
if ($firstNumber >= "10") {$spaceBattle = "$spaceBattle <div id=\"enemy10\"><img src=\"enemyship.png\" /></div>";}
if ($firstNumber >= "11") {$spaceBattle = "$spaceBattle <div id=\"enemy11\"><img src=\"enemyship.png\" /></div>";}
if ($firstNumber >= "12") {$spaceBattle = "$spaceBattle <div id=\"enemy12\"><img src=\"enemyship.png\" /></div>";}

if ($volleySize >= "1") {$spaceBattle = "$spaceBattle <div id=\"missile001\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "2") {$spaceBattle = "$spaceBattle <div id=\"missile002\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "3") {$spaceBattle = "$spaceBattle <div id=\"missile003\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "4") {$spaceBattle = "$spaceBattle <div id=\"missile004\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "5") {$spaceBattle = "$spaceBattle <div id=\"missile005\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "6") {$spaceBattle = "$spaceBattle <div id=\"missile006\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "7") {$spaceBattle = "$spaceBattle <div id=\"missile007\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "8") {$spaceBattle = "$spaceBattle <div id=\"missile008\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "9") {$spaceBattle = "$spaceBattle <div id=\"missile009\"><img src=\"missile01.png\" /></div>";}

if ($volleySize >= "10") {$spaceBattle = "$spaceBattle <div id=\"missile010\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "11") {$spaceBattle = "$spaceBattle <div id=\"missile011\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "12") {$spaceBattle = "$spaceBattle <div id=\"missile012\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "13") {$spaceBattle = "$spaceBattle <div id=\"missile013\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "14") {$spaceBattle = "$spaceBattle <div id=\"missile014\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "15") {$spaceBattle = "$spaceBattle <div id=\"missile015\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "16") {$spaceBattle = "$spaceBattle <div id=\"missile016\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "17") {$spaceBattle = "$spaceBattle <div id=\"missile017\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "18") {$spaceBattle = "$spaceBattle <div id=\"missile018\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "19") {$spaceBattle = "$spaceBattle <div id=\"missile019\"><img src=\"missile01.png\" /></div>";}

if ($volleySize >= "20") {$spaceBattle = "$spaceBattle <div id=\"missile020\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "21") {$spaceBattle = "$spaceBattle <div id=\"missile021\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "22") {$spaceBattle = "$spaceBattle <div id=\"missile022\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "23") {$spaceBattle = "$spaceBattle <div id=\"missile023\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "24") {$spaceBattle = "$spaceBattle <div id=\"missile024\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "25") {$spaceBattle = "$spaceBattle <div id=\"missile025\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "26") {$spaceBattle = "$spaceBattle <div id=\"missile026\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "27") {$spaceBattle = "$spaceBattle <div id=\"missile027\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "28") {$spaceBattle = "$spaceBattle <div id=\"missile028\"><img src=\"missile01.png\" /></div>";}
if ($volleySize >= "29") {$spaceBattle = "$spaceBattle <div id=\"missile029\"><img src=\"missile01.png\" /></div>";}



$controlPanel = "<div class=\"cntlpanel\"><img src=\"cntlbar01.png\" width=\"293\" height=\"47\" border=\"0\" alt=\"OPS REPORT\" />
<div class=\"msg01\">WE'RE UNDER ATTACK!</div>
<div class=\"msg02\">There are $firstNumber pirates<br />inbound, each firing<br />$secondNumber space missiles!</div>
<div class=\"msg03\">How much energy should we put into our ship's lasers to shoot down the missiles?</div>
<div class=\"msg04\">$firstNumber x $secondNumber = <input size=\"3\" type=\"text\" name=\"guess\" class=\"trgt\" value=\"\" />&nbsp;GW<br />
<input type=\"submit\" name=\"submit\" class=\"fire\" value=\"FIRE!\" />
</div>
<img src=\"cntlbar02.png\" width=\"293\" height=\"47\" border=\"0\" alt=\"***\" />
<img src=\"$imgShields\" width=\"125\" height=\"135\" alt=\"Status Of Our Shields\">&nbsp;
<img src=\"$imgEngines\" width=\"125\" height=\"135\" alt=\"Status Of Our Engines\">
<img src=\"$overallStatus\" class=\"fx01\" width=\"293\" height=\"78\" border=\"0\" />
</div>
<br clear=\"all\" /></div>
<input type=\"hidden\" name=\"number01\" value=\"$firstNumber\">
<input type=\"hidden\" name=\"number02\" value=\"$secondNumber\">
<input type=\"hidden\" name=\"hpShields\" value=\"$hpShields\">
<input type=\"hidden\" name=\"hpEnergy\" value=\"$hpEngines\">
<input type=\"hidden\" name=\"controlMsgCount\" value=\"$controlMsgCount\">
<input type=\"hidden\" name=\"status\" value=\"$nextstatus\">
<input type=\"hidden\" name=\"stage\" value=\"$stage\">";
}



/* OUTCOME SCREEN */
if ($status == "outcome") {
$nextstatus = "neutral";
$spaceBattle = "<div id=\"theship\"><img src=\"$shipImg\" /></div>";
$controlPanel = "<div class=\"cntlpanel\"><img src=\"cntlbar01.png\" width=\"293\" height=\"47\" border=\"0\" alt=\"OPS REPORT\" />
$ResultLine
<div class=\"msg03\"><input type=\"submit\" name=\"submit\" class=\"next\" value=\"NEXT...\" /></div>
<img src=\"cntlbar02.png\" width=\"293\" height=\"47\" border=\"0\" alt=\"***\" />
<img src=\"$imgShields\" width=\"125\" height=\"135\" alt=\"Status Of Our Shields\">&nbsp;
<img src=\"$imgEngines\" width=\"125\" height=\"135\" alt=\"Status Of Our Engines\">
<img src=\"$overallStatus\" class=\"fx01\" width=\"293\" height=\"78\" border=\"0\" />
</div>
<br clear=\"all\" /></div>
<input type=\"hidden\" name=\"number01\" value=\"$firstNumber\">
<input type=\"hidden\" name=\"number02\" value=\"$secondNumber\">
<input type=\"hidden\" name=\"hpShields\" value=\"$hpShields\">
<input type=\"hidden\" name=\"hpEnergy\" value=\"$hpEngines\">
<input type=\"hidden\" name=\"controlMsgCount\" value=\"$controlMsgCount\">
<input type=\"hidden\" name=\"status\" value=\"$nextstatus\">
<input type=\"hidden\" name=\"stage\" value=\"$stage\">";
}


/* display the appropriate screen */
if ($status == "start") {

echo "<html>
<head>
</head>
<body><form action=\"index.php\" method=\"post\">
<h1>Space Cadets!</h1>
<p><em>Updated graphics mockup version 2 (03/30/2021)</em></p>
<input type=\"hidden\" name=\"controlMsgCount\" value=\"1\">
<input type=\"hidden\" name=\"hpShields\" value=\"3\">
<input type=\"hidden\" name=\"hpEnergy\" value=\"3\">
<input type=\"hidden\" name=\"status\" value=\"$nextstatus\">
<input type=\"submit\" name=\"submit\" value=\"LAUNCH!\" />
</form>
</body>
</html>";

} else { 

echo "<!DOCTYPE html>
<html>
<head>
<meta name=\"robots\" content=\"noindex,nofollow\" />
<title>SPACE CADETS!</title>
<link rel=\"preconnect\" href=\"https://fonts.gstatic.com\">
<link href=\"https://fonts.googleapis.com/css2?family=Londrina+Solid:wght@300&display=swap\" rel=\"stylesheet\">
$CSSstyles
</head>
<body><form action=\"index.php\" method=\"post\"><div class=\"wrp\">

<div class=\"spacebattle\">
$spaceBattle
</div>

$controlPanel

</form></body>
</html>";
}

?>