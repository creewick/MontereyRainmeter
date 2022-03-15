[Variables]
WidgetHeight=300

[Label1]
Meter=String
AntiAlias=1
FontSize=10
FontFace=#FontFace#
FontColor=#ForegroundColor#
Text=#tWidgetSize#:
StringAlign=Right
DynamicVariables=1
X=(#SidebarWidth#+155)
Y=(105)
ClipString=2
W=120

[Value1]
Meter=String
MeterStyle=Label1
Text=#WidgetBase#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(105 - 2)
X=(#SidebarWidth#+200)
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
Y=(105 - 2)
X=(#SidebarWidth#+200-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables WidgetBase "$UserInput$" "#@#Settings\Global.inc"][!RefreshGroup Monterey]

[Label2]
Meter=String
MeterStyle=Label1
Text=#tWidgetPadding#:
Y=(155)

[Value2]
Meter=String
MeterStyle=Label1
Text=#WidgetPadding#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(155 - 2)
X=(#SidebarWidth#+200)
W=76
LeftMouseUpAction=[!CommandMeasure "Input2" "ExecuteBatch ALL"]

[Input2]
Measure=Plugin
Plugin=InputText
DefaultValue=#WidgetPadding#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(155 - 2)
X=(#SidebarWidth#+200-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables WidgetPadding "$UserInput$" "#@#Settings\Global.inc"][!RefreshGroup Monterey]

[Label3]
Meter=String
MeterStyle=Label1
Text=#tWidgetRadius#:
X=(#SidebarWidth#+420)

[Value3]
Meter=String
MeterStyle=Label1
Text=#WidgetRadius#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(105 - 2)
X=(#SidebarWidth#+470)
W=76
LeftMouseUpAction=[!CommandMeasure "Input3" "ExecuteBatch ALL"]

[Input3]
Measure=Plugin
Plugin=InputText
DefaultValue=#WidgetRadius#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(105 - 2)
X=(#SidebarWidth#+470-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables WidgetRadius "$UserInput$" "#@#Settings\Global.inc"][!RefreshGroup Monterey]