[Lua]
Measure=Script
ScriptFile=Sidebar.lua
Item1=Welcome
Item2=Settings
Item3=About
Item4=Widgets
Item5=Clock
Item6=Calendar
Item7=ActivityMonitor
Item8=Weather

[BackgroundMask]
Meter = Shape
DynamicVariables = 1
Shape = Rectangle 0, 0, ([WidgetWidth]-4), ([WidgetHeight]-4), #WidgetBorderRadius#, #WidgetBorderRadius# | Fill Color 000000 
Padding = (#WidgetPaddingSize#+2), (#WidgetPaddingSize#+2), (#WidgetPaddingSize#+2), (#WidgetPaddingSize#+2)
UpdateDivider=-1

[MainMeter]
Meter=Shape
Shape=Rectangle (#WidgetPaddingSize#+160),#WidgetPaddingSize#,640,500 | Fill Color 111111 | StrokeWidth 1 | Stroke Color 666666
Container=BackgroundMask
UpdateDivider=-1

[SidebarButton1]
Meter=Shape
[SidebarLabel1]
Meter=String
[SidebarIcon1]
Meter=Image
[SidebarButton2]
Meter=Shape
[SidebarLabel2]
Meter=String
[SidebarIcon2]
Meter=Image
[SidebarButton3]
Meter=Shape
[SidebarLabel3]
Meter=String
[SidebarIcon3]
Meter=Image
[SidebarButton4]
Meter=Shape
[SidebarLabel4]
Meter=String
[SidebarIcon4]
Meter=Image
[SidebarButton5]
Meter=Shape
[SidebarLabel5]
Meter=String
[SidebarIcon5]
Meter=Image
[SidebarButton6]
Meter=Shape
[SidebarLabel6]
Meter=String
[SidebarIcon6]
Meter=Image
[SidebarButton7]
Meter=Shape
[SidebarLabel7]
Meter=String
[SidebarIcon7]
Meter=Image
[SidebarButton8]
Meter=Shape
[SidebarLabel8]
Meter=String
[SidebarIcon8]
Meter=Image
