[Variables]
WidgetHeight=350

[Language]
Meter=Shape
Shape=Rectangle 20,20,(#WidgetWidth# - #SidebarWidth# - 40),80,6 | Fill Color #ForegroundColor#05 | StrokeWidth 0
X=#SidebarWidth#
Y=55
DynamicVariables=1

[BatterySaverMode]
Meter=String
Text=#tBatterySaverMode#
FontFace=#FontFace#
FontWeight=400
FontColor=#ForegroundColor#
FontSize=11
AntiAlias=1
X=(#SidebarWidth#+30)
Y=(85)
DynamicVariables=1

[BatterySaverModeFalse]
Meter=Shape
Shape=Rectangle 0,0,38,24,12 | Fill Color 808080 | StrokeWidth 0
Shape2=Rectangle 2,2,20,20,10 | Fill Color ffffff | StrokeWidth 0
Y=(82)
X=(#WidgetWidth# - 30 - 40)
Hidden=(#BatterySaverMode# = 1)
LeftMouseUpAction=[!WriteKeyValue Variables BatterySaverMode 1 "#@#Variables\Global.inc"][!RefreshGroup Monterey]

[BatterySaverModeTrue]
Meter=Shape
Shape=Rectangle 0,0,38,24,12 | Fill Color 33cc66 | StrokeWidth 0
Shape2=Rectangle 16,2,20,20,10 | Fill Color ffffff | StrokeWidth 0
Y=(82)
X=(#WidgetWidth# - 30 - 40)
Hidden=(#BatterySaverMode# = 0)
LeftMouseUpAction=[!WriteKeyValue Variables BatterySaverMode 0 "#@#Variables\Global.inc"][!RefreshGroup Monterey]

[Line1]
Meter=Shape
Shape=Rectangle (#SidebarWidth# + 20),(115),(#WidgetWidth#-#SidebarWidth#-40),0 | StrokeWidth 0.5 | Stroke Color 80808080

[BatteryAuto]
Meter=String
Text=#tAuto#
FontFace=#FontFace#
FontWeight=400
FontColor=#ForegroundColor#
FontSize=11
AntiAlias=1
X=(#SidebarWidth#+30)
Y=(125)
DynamicVariables=1

[BatteryAutoFalse]
Meter=Shape
Shape=Rectangle 0,0,38,24,12 | Fill Color 808080 | StrokeWidth 0
Shape2=Rectangle 2,2,20,20,10 | Fill Color ffffff | StrokeWidth 0
Y=(123)
X=(#WidgetWidth# - 30 - 40)
Hidden=(#BatterySaverMode# = 1)
LeftMouseUpAction=[!WriteKeyValue Variables BatterySaverMode 1 "#@#Variables\Global.inc"][!RefreshGroup Monterey]

[BatteryAutoTrue]
Meter=Shape
Shape=Rectangle 0,0,38,24,12 | Fill Color 33cc66 | StrokeWidth 0
Shape2=Rectangle 16,2,20,20,10 | Fill Color ffffff | StrokeWidth 0
Y=(123)
X=(#WidgetWidth# - 30 - 40)
Hidden=(#BatterySaverMode# = 0)
LeftMouseUpAction=[!WriteKeyValue Variables BatterySaverMode 0 "#@#Variables\Global.inc"][!RefreshGroup Monterey]

[BatteryHelp]
Meter=String
MeterStyle=BatterySaverMode
FontSize=10
FontColor=#ForegroundColor#80
ClipString=2
W=340
Y=160
Text=#tBatterySaverModeHelp#