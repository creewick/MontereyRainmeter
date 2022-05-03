[Label1]
Meter=String
MeterStyle=ThemeLabel
Text=#tWidgetSize#:
Y=(320)

[Value1]
Meter=String
MeterStyle=ThemeLabel
Text=#WidgetBase#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(320 - 2)
X=(#SidebarWidth#+190)
W=76
LeftMouseUpAction=[!CommandMeasure "Input1" "ExecuteBatch ALL"]

[Input1]
Measure=Plugin
Plugin=InputText
DefaultValue=#WidgetBase#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(320 - 2)
X=(#SidebarWidth#+190-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables WidgetBase "$UserInput$" "#@#Variables\Global.inc"][!RefreshGroup Monterey]

[Label2]
Meter=String
MeterStyle=ThemeLabel
Text=#tWidgetPadding#:
X=(#SidebarWidth#+440)
Y=(320)

[Value2]
Meter=String
MeterStyle=ThemeLabel
Text=#PaddingBase#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(320 - 2)
X=(#SidebarWidth#+490)
W=76
LeftMouseUpAction=[!CommandMeasure "Input2" "ExecuteBatch ALL"]

[Input2]
Measure=Plugin
Plugin=InputText
DefaultValue=#PaddingBase#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(320 - 2)
X=(#SidebarWidth#+490-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables PaddingBase "$UserInput$" "#@#Variables\Global.inc"][!RefreshGroup Monterey]

[Label3]
Meter=String
MeterStyle=ThemeLabel
Text=#tWidgetRadius#:
Y=370

[Value3]
Meter=String
MeterStyle=ThemeLabel
Text=#RadiusBase#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(370 - 2)
X=(#SidebarWidth#+190)
W=76
LeftMouseUpAction=[!CommandMeasure "Input3" "ExecuteBatch ALL"]

[Input3]
Measure=Plugin
Plugin=InputText
DefaultValue=#RadiusBase#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(370 - 2)
X=(#SidebarWidth#+190-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables RadiusBase "$UserInput$" "#@#Variables\Global.inc"][!RefreshGroup Monterey]

[Label4]
Meter=String
MeterStyle=ThemeLabel
Text=#tBatterySaverMode#:
Y=(370)
X=(#SidebarWidth#+440)
W=200

[Label4False]
Meter=Shape
Shape=Rectangle 0,0,38,24,12 | Fill Color 808080 | StrokeWidth 0
Shape2=Rectangle 2,2,20,20,10 | Fill Color ffffff | StrokeWidth 0
Y=(366)
X=(#SidebarWidth#+450)
Hidden=(#BatterySaverMode# = 1)
LeftMouseUpAction=[!WriteKeyValue Variables BatterySaverMode 1 "#@#Variables\Global.inc"][!RefreshGroup Monterey]

[Label4True]
Meter=Shape
Shape=Rectangle 0,0,38,24,12 | Fill Color 33cc66 | StrokeWidth 0
Shape2=Rectangle 16,2,20,20,10 | Fill Color ffffff | StrokeWidth 0
Y=(366)
X=(#SidebarWidth#+450)
Hidden=(#BatterySaverMode# = 0)
LeftMouseUpAction=[!WriteKeyValue Variables BatterySaverMode 0 "#@#Variables\Global.inc"][!RefreshGroup Monterey]
