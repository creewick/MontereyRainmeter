[Rainmeter]
OnRefreshAction=[!CommandMeasure CPUAnimation "Execute [&ActionList]"][!CommandMeasure RAMAnimation "Execute [&ActionList]"][!CommandMeasure DiskAnimation "Execute [&ActionList]"][!CommandMeasure NetAnimation "Execute [&ActionList]"]

[Variables]
CPUValue=0
RAMValue=0
DiskValue=0
NetValue=0

[ActionList]
Measure=Calc
Formula=1+#BatterySaverMode#

[NoneMeasure]
Measure=Calc
Formula=0

[BatteryMeasure]
Measure=Plugin
Plugin=PowerPlugin
PowerState=Percent
UpdateDivider=(60 * 5)
MinValue=0
MaxValue=100
IfCondition=((100 - BatteryMeasure) < #YellowStarts#)
IfTrueAction=[!SetVariable BatteryColor #GreenColor#]
IfCondition2=((100 - BatteryMeasure) >= #YellowStarts#) && ((100 - BatteryMeasure) < #RedStarts#)
IfTrueAction2=[!SetVariable BatteryColor #YellowColor#]
IfCondition3=((100 - BatteryMeasure) >= #RedStarts#)
IfTrueAction3=[!SetVariable BatteryColor #RedColor#]

[CPUMonitor]
Measure=Plugin
Plugin=UsageMonitor
Alias=CPU
UpdateDivider=(#BatterySaverMode# = 0 ? 10 : 20)
MinValue=0
MaxValue=100
OnChangeAction=[!UpdateMeasure CPURounded]

[CPURounded]
Measure=Calc
Formula=Round(CPUMonitor,0)
MinValue=0
MaxValue=100
IfCondition=(CPUMonitor < #YellowStarts#)
IfTrueAction=[!SetVariable CPUColor #GreenColor#]
IfCondition2=(CPUMonitor >= #YellowStarts#) && (CPUMonitor < #RedStarts#)
IfTrueAction2=[!SetVariable CPUColor #YellowColor#]
IfCondition3=(CPUMonitor >= #RedStarts#)
IfTrueAction3=[!SetVariable CPUColor #RedColor#]
OnChangeAction=[!CommandMeasure CPUAnimation "Stop [&ActionList]"][!CommandMeasure CPUAnimation "Execute [&ActionList]"]

[CPUMeasure]
Measure=Calc
Formula=#CPUValue#
MinValue=0
MaxValue=100
DynamicVariables=1

[CPUAnimation]
Measure=Plugin
Plugin=ActionTimer
ActionList1=Repeat AddStep, 100, 10
ActionList2=Update
AddStep=[!SetVariable CPUValue ([#CPUValue]+([&CPURounded:]-[#CPUValue])/2)][!UpdateMeasure CPUMeasure]
Update=[!SetVariable CPUValue [&CPURounded:]][!UpdateMeasure CPUMeasure]
DynamicVariables=1

[RAMMonitor]
Measure=Plugin
Plugin=UsageMonitor
Category=Memory
Counter=% Committed Bytes In Use
UpdateDivider=(#BatterySaverMode# = 0 ? 10 : 20)
MinValue=0
MaxValue=100
OnChangeAction=[!UpdateMeasure RAMRounded]

[RAMRounded]
Measure=Calc
Formula=Round(RAMMonitor,0)
MinValue=0
MaxValue=100
IfCondition=(RAMMonitor < #YellowStarts#)
IfTrueAction=[!SetVariable RAMColor #GreenColor#]
IfCondition2=(RAMMonitor >= #YellowStarts#) && (RAMMonitor < #RedStarts#)
IfTrueAction2=[!SetVariable RAMColor #YellowColor#]
IfCondition3=(RAMMonitor >= #RedStarts#)
IfTrueAction3=[!SetVariable RAMColor #RedColor#]
OnChangeAction=[!CommandMeasure RAMAnimation "Stop [&ActionList]"][!CommandMeasure RAMAnimation "Execute [&ActionList]"]

[RAMMeasure]
Measure=Calc
Formula=#RAMValue#
MinValue=0
MaxValue=100
DynamicVariables=1

[RAMAnimation]
Measure=Plugin
Plugin=ActionTimer
ActionList1=Repeat AddStep, 100, 10
ActionList2=Update
AddStep=[!SetVariable RAMValue ([#RAMValue]+([&RAMRounded:]-[#RAMValue])/2)][!UpdateMeasure RAMMeasure]
Update=[!SetVariable RAMValue [&RAMRounded:]][!UpdateMeasure RAMMeasure]
DynamicVariables=1

[DiskMonitor]
Measure=Plugin
Plugin=UsageMonitor
Category=LogicalDisk
Counter=% Disk Time
UpdateDivider=(#BatterySaverMode# = 0 ? 10 : 20)
MinValue=0
MaxValue=100
OnChangeAction=[!UpdateMeasure DiskRounded]

[DiskRounded]
Measure=Calc
Formula=Round(Clamp(DiskMonitor,0,100),0)
MinValue=0
MaxValue=100
IfCondition=(DiskMonitor < #YellowStarts#)
IfTrueAction=[!SetVariable DiskColor #GreenColor#]
IfCondition2=(DiskMonitor >= #YellowStarts#) && (DiskMonitor < #RedStarts#)
IfTrueAction2=[!SetVariable DiskColor #YellowColor#]
IfCondition3=(DiskMonitor >= #RedStarts#)
IfTrueAction3=[!SetVariable DiskColor #RedColor#]
OnChangeAction=[!CommandMeasure DiskAnimation "Stop [&ActionList]"][!CommandMeasure DiskAnimation "Execute [&ActionList]"]

[DiskMeasure]
Measure=Calc
Formula=#DiskValue#
MinValue=0
MaxValue=100
DynamicVariables=1

[DiskAnimation]
Measure=Plugin
Plugin=ActionTimer
ActionList1=Repeat AddStep, 100, 10
ActionList2=Update
AddStep=[!SetVariable DiskValue ([#DiskValue]+([&DiskRounded:]-[#DiskValue])/2)][!UpdateMeasure DiskMeasure]
Update=[!SetVariable DiskValue [&DiskRounded:]][!UpdateMeasure DiskMeasure]
DynamicVariables=1

[NetBytes]
Measure=Plugin
Plugin=UsageMonitor
Category=Network Interface
Counter=Bytes total/sec
MinValue=0
MaxValue=100
UpdateDivider=(#BatterySaverMode# = 0 ? 10 : 20)
OnChangeAction=[!UpdateMeasure NetRounded]

[NetWidth]
Measure=Plugin
Plugin=UsageMonitor
Category=Network Interface
Counter=Current bandwidth
MinValue=0
MaxValue=100
UpdateDivider=3600
OnChangeAction=[!UpdateMeasure NetRounded]

[NetRounded]
Measure=Calc
Formula=Round(Clamp(NetBytes * 8 / NetWidth * 100, 0, 100),0)
MinValue=0
MaxValue=100
IfCondition=(NetMeasure < #YellowStarts#)
IfTrueAction=[!SetVariable NetColor #GreenColor#]
IfCondition2=(NetMeasure >= #YellowStarts#) && (NetMeasure < #RedStarts#)
IfTrueAction2=[!SetVariable NetColor #YellowColor#]
IfCondition3=(NetMeasure >= #RedStarts#)
IfTrueAction3=[!SetVariable NetColor #RedColor#]
OnChangeAction=[!CommandMeasure NetAnimation "Stop [&ActionList]"][!CommandMeasure NetAnimation "Execute [&ActionList]"]

[NetMeasure]
Measure=Calc
Formula=#NetValue#
MinValue=0
MaxValue=100
DynamicVariables=1

[NetAnimation]
Measure=Plugin
Plugin=ActionTimer
ActionList1=Repeat AddStep, 100, 10
ActionList2=Update
AddStep=[!SetVariable NetValue ([#NetValue]+([&NetRounded:]-[#NetValue])/2)][!UpdateMeasure NetMeasure]
Update=[!SetVariable NetValue [&NetRounded:]][!UpdateMeasure NetMeasure]
DynamicVariables=1
