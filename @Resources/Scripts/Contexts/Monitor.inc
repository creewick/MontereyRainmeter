[Variables]
MonitorContextTitle=None
MonitorContextAction=[!WriteKeyValue Variables [#Meter] "None" "#@#Variables\Monitor.inc"][!Refresh]
MonitorContextTitle2=---
MonitorContextAction2=[]
MonitorContextTitle3=CPU
MonitorContextAction3=[!WriteKeyValue Variables [#Meter] "CPU" "#@#Variables\Monitor.inc"][!Refresh]
MonitorContextTitle4=RAM
MonitorContextAction4=[!WriteKeyValue Variables [#Meter] "RAM" "#@#Variables\Monitor.inc"][!Refresh]
MonitorContextTitle5=Disk
MonitorContextAction5=[!WriteKeyValue Variables [#Meter] "Disk" "#@#Variables\Monitor.inc"][!Refresh]
MonitorContextTitle6=Net
MonitorContextAction6=[!WriteKeyValue Variables [#Meter] "Net" "#@#Variables\Monitor.inc"][!Refresh]
MonitorContextTitle7=Battery
MonitorContextAction7=[!WriteKeyValue Variables [#Meter] "Battery" "#@#Variables\Monitor.inc"][!Refresh]
MonitorContextTitle8=

[SetTickMark]
Measure=String
String=[#[#Meter]]
DynamicVariables=1
IfMatch=None
IfMatchAction=[!SetOption Rainmeter ContextTitle "None  [\x2714]"]
IfMatch2=CPU
IfMatchAction2=[!SetOption Rainmeter ContextTitle3 "CPU  [\x2714]"]
IfMatch3=RAM
IfMatchAction3=[!SetOption Rainmeter ContextTitle4 "RAM  [\x2714]"]
IfMatch4=Disk
IfMatchAction4=[!SetOption Rainmeter ContextTitle5 "Disk  [\x2714]"]
IfMatch5=Net
IfMatchAction5=[!SetOption Rainmeter ContextTitle6 "Net  [\x2714]"]
IfMatch6=Battery
IfMatchAction6=[!SetOption Rainmeter ContextTitle7 "Battery  [\x2714]"]