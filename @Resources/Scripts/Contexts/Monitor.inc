[Variables]
MonitorContextTitle=CPU
MonitorContextAction=[!WriteKeyValue Variables [#Meter] "CPU" "#@#Variables\Monitor.inc"][!Refresh]
MonitorContextTitle2=RAM
MonitorContextAction2=[!WriteKeyValue Variables [#Meter] "RAM" "#@#Variables\Monitor.inc"][!Refresh]
MonitorContextTitle3=Disk
MonitorContextAction3=[!WriteKeyValue Variables [#Meter] "Disk" "#@#Variables\Monitor.inc"][!Refresh]
MonitorContextTitle4=Net
MonitorContextAction4=[!WriteKeyValue Variables [#Meter] "Net" "#@#Variables\Monitor.inc"][!Refresh]
MonitorContextTitle5=
MonitorContextAction5=[]

[SetTickMark]
Measure=String
String=[#[#Meter]]
DynamicVariables=1
IfMatch=CPU
IfMatchAction=[!SetOption Rainmeter ContextTitle "CPU  [\x2714]"]
IfNotMatchAction=[!SetOption Rainmeter ContextTitle "CPU"]
IfMatch2=RAM
IfMatchAction2=[!SetOption Rainmeter ContextTitle2 "RAM  [\x2714]"]
IfNotMatchAction2=[!SetOption Rainmeter ContextTitle2 "RAM"]
IfMatch3=Disk
IfMatchAction3=[!SetOption Rainmeter ContextTitle3 "Disk  [\x2714]"]
IfNotMatchAction3=[!SetOption Rainmeter ContextTitle3 "Disk"]
IfMatch4=Net
IfMatchAction4=[!SetOption Rainmeter ContextTitle4 "Net  [\x2714]"]
IfNotMatchAction4=[!SetOption Rainmeter ContextTitle4 "Net"]