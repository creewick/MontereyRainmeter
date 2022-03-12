[CPUMonitor]
Measure=Plugin
Plugin=UsageMonitor
Category=Processor
Counter=% Processor Time
Index=-1
UpdateDivider=1

[CPUMeasure]
Measure=Calc
Formula=Round(CPUMonitor, 0)
AverageSize=10
MinValue=0
MaxValue=100
UpdateDivider=1
IfCondition = (CPUMeasure < #YellowStarts#)
IfTrueAction = [!SetVariable CPUColor #GreenColor#]
IfCondition2 = (CPUMeasure >= #YellowStarts#) && (CPUMeasure < #RedStarts#)
IfTrueAction2 = [!SetVariable CPUColor #YellowColor#]
IfCondition3 = (CPUMeasure >= #RedStarts#)
IfTrueAction3 = [!SetVariable CPUColor #RedColor#]

[RAMMonitor]
Measure=Plugin
Plugin=UsageMonitor
Category=Memory
Counter=% Committed Bytes In Use
UpdateDivider=1

[RAMMeasure]
Measure=Calc
Formula=Round(RAMMonitor, 0)
AverageSize=10
MinValue=0
MaxValue=100
UpdateDivider=1
IfCondition = (RAMMeasure < #YellowStarts#)
IfTrueAction = [!SetVariable RAMColor #GreenColor#]
IfCondition2 = (RAMMeasure >= #YellowStarts#) && (RAMMeasure < #RedStarts#)
IfTrueAction2 = [!SetVariable RAMColor #YellowColor#]
IfCondition3 = (RAMMeasure >= #RedStarts#)
IfTrueAction3 = [!SetVariable RAMColor #RedColor#]

[DiskMonitor]
Measure=Plugin
Plugin=UsageMonitor
Category=LogicalDisk
Counter=% Disk Time
UpdateDivider=1

[DiskMeasure]
Measure=Calc
Formula=Round(Clamp(DiskMonitor / 10, 0, 100),0)
AverageSize=10
MinValue=0
MaxValue=100
UpdateDivider=1
IfCondition = (DiskMeasure < #YellowStarts#)
IfTrueAction = [!SetVariable DiskColor #GreenColor#]
IfCondition2 = (DiskMeasure >= #YellowStarts#) && (DiskMeasure < #RedStarts#)
IfTrueAction2 = [!SetVariable DiskColor #YellowColor#]
IfCondition3 = (DiskMeasure >= #RedStarts#)
IfTrueAction3 = [!SetVariable DiskColor #RedColor#]

[NetBytes]
Measure=Plugin
Plugin=UsageMonitor
Category=Network Interface
Counter=Bytes total/sec
UpdateDivider=1

[NetWidth]
Measure=Plugin
Plugin=UsageMonitor
Category=Network Interface
Counter=Current bandwidth
UpdateDivider=1

[NetMeasure]
Measure=Calc
Formula=Round(Clamp(NetBytes * 8 / NetWidth * 100, 0, 100),0)
AverageSize=10
MinValue=0
MaxValue=100
UpdateDivider=1
IfCondition = (NetMeasure < #YellowStarts#)
IfTrueAction = [!SetVariable NetColor #GreenColor#]
IfCondition2 = (NetMeasure >= #YellowStarts#) && (NetMeasure < #RedStarts#)
IfTrueAction2 = [!SetVariable NetColor #YellowColor#]
IfCondition3 = (NetMeasure >= #RedStarts#)
IfTrueAction3 = [!SetVariable NetColor #RedColor#]
