[CPUMonitor]
Measure=Plugin
Plugin=UsageMonitor
Category=Processor
Counter=% Processor Time
Index=-1

[CPUMeasure]
Measure=Calc
Formula=CPUMonitor
AverageSize=10
MinValue=0
MaxValue=100

[RAMMonitor]
Measure=Plugin
Plugin=UsageMonitor
Category=Memory
Counter=% Committed Bytes In Use

[RAMMeasure]
Measure=Calc
Formula=RAMMonitor
AverageSize=10
MinValue=0
MaxValue=100

[DiskMonitor]
Measure=Plugin
Plugin=UsageMonitor
Category=LogicalDisk
Counter=% Disk Time

[DiskMeasure]
Measure=Calc
Formula=Clamp(DiskMonitor / 10, 0, 100)
AverageSize=10
MinValue=0
MaxValue=100

[NetBytes]
Measure=Plugin
Plugin=UsageMonitor
Category=Network Interface
Counter=Bytes total/sec

[NetWidth]
Measure=Plugin
Plugin=UsageMonitor
Category=Network Interface
Counter=Current bandwidth

[NetMeasure]
Measure=Calc
Formula=Clamp(NetBytes * 8 / NetWidth * 100, 0, 100)
AverageSize=10
MinValue=0
MaxValue=100
