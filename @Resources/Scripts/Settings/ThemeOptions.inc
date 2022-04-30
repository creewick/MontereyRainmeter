
[ThemeBackgroundLabel]
Meter=String
MeterStyle=ThemeLabel
FontWeight=100
Text=#tBackgroundColor#:
Y=(180)
Hidden=([&ThemeAsNumber]<>1) && ([&ThemeAsNumber]<>2) && ([&ThemeAsNumber]<>4)

[LightBackgroundValue]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
Text=#LightThemeBackground#
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(180 - 2)
X=(#SidebarWidth#+190)
W=76
LeftMouseUpAction=[!CommandMeasure "LightBackgroundInput" "ExecuteBatch ALL"]
Hidden=([&ThemeAsNumber]<>1)

[LightBackgroundInput]
Measure=Plugin
Plugin=InputText
DefaultValue=#LightThemeBackground#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=808080
Y=(180 - 2)
X=(#SidebarWidth#+190-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables LightThemeBackground "$UserInput$" "#@#Variables\Global.inc"][!RefreshGroup Monterey]
Hidden=([&ThemeAsNumber]<>1)

[ThemeForegroundLabel]
Meter=String
MeterStyle=ThemeLabel
FontWeight=100
Text=#tForegroundColor#:
Y=(180)
X=(#SidebarWidth# + 440)
Hidden=([&ThemeAsNumber]<>1) && ([&ThemeAsNumber]<>2) && ([&ThemeAsNumber]<>4)

[LightForegroundValue]
Meter=String
MeterStyle=ThemeLabel
Text=#LightThemeForeground#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(180 - 2)
X=(#SidebarWidth#+490)
W=76
LeftMouseUpAction=[!CommandMeasure "LightForegroundInput" "ExecuteBatch ALL"]
Hidden=([&ThemeAsNumber]<>1)

[LightForegroundInput]
Measure=Plugin
Plugin=InputText
DefaultValue=#LightThemeForeground#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=808080
Y=(180 - 2)
X=(#SidebarWidth#+490-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables LightThemeForeground "$UserInput$" "#@#Variables\Global.inc"][!RefreshGroup Monterey]
Hidden=([&ThemeAsNumber]<>1)

[DarkBackgroundValue]
Meter=String
MeterStyle=ThemeLabel
Text=#DarkThemeBackground#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(180 - 2)
X=(#SidebarWidth#+190)
W=76
LeftMouseUpAction=[!CommandMeasure "DarkBackgroundInput" "ExecuteBatch ALL"]
Hidden=([&ThemeAsNumber]<>2)

[DarkBackgroundInput]
Measure=Plugin
Plugin=InputText
DefaultValue=#DarkThemeBackground#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(180 - 2)
X=(#SidebarWidth#+190-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables DarkThemeBackground "$UserInput$" "#@#Variables\Global.inc"][!RefreshGroup Monterey]
Hidden=([&ThemeAsNumber]<>2)

[DarkForegroundValue]
Meter=String
MeterStyle=ThemeLabel
Text=#DarkThemeForeground#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(180 - 2)
X=(#SidebarWidth#+490)
W=76
LeftMouseUpAction=[!CommandMeasure "DarkForegroundInput" "ExecuteBatch ALL"]
Hidden=([&ThemeAsNumber]<>2)

[DarkForegroundInput]
Measure=Plugin
Plugin=InputText
DefaultValue=#DarkThemeForeground#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(180 - 2)
X=(#SidebarWidth#+490-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables DarkThemeForeground "$UserInput$" "#@#Variables\Global.inc"][!RefreshGroup Monterey]
Hidden=([&ThemeAsNumber]<>2)

[AutoThemeStartLabel]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
FontWeight=100
Text=#tDarkTheme# #tTheme# #tFrom#:
Y=(180)
Hidden=([&ThemeAsNumber]<>3)

[AutoThemeStartValue]
Meter=String
MeterStyle=ThemeLabel
Text=#DarkThemeFrom#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(180 - 2)
X=(#SidebarWidth#+190)
W=76
LeftMouseUpAction=[!CommandMeasure "AutoThemeStartInput" "ExecuteBatch ALL"]
Hidden=([&ThemeAsNumber]<>3)

[AutoThemeStartInput]
Measure=Plugin
Plugin=InputText
DefaultValue=#DarkThemeFrom#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(180 - 2)
X=(#SidebarWidth#+190-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables DarkThemeFrom "$UserInput$" "#@#Variables\Global.inc"][!RefreshGroup Monterey]
Hidden=([&ThemeAsNumber]<>3)

[AutoThemeEndLabel]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
FontWeight=100
Text=#tTo#:
Y=(180)
X=(#SidebarWidth# + 440)
Hidden=([&ThemeAsNumber]<>3)

[AutoThemeEndValue]
Meter=String
MeterStyle=ThemeLabel
Text=#DarkThemeTo#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(180 - 2)
X=(#SidebarWidth#+490)
W=76
LeftMouseUpAction=[!CommandMeasure "AutoThemeEndInput" "ExecuteBatch ALL"]
Hidden=([&ThemeAsNumber]<>3)

[AutoThemeEndInput]
Measure=Plugin
Plugin=InputText
DefaultValue=#DarkThemeTo#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(180 - 2)
X=(#SidebarWidth#+490-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables DarkThemeTo "$UserInput$" "#@#Variables\Global.inc"][!RefreshGroup Monterey]
Hidden=([&ThemeAsNumber]<>3)

[ColorBackgroundValue]
Meter=String
MeterStyle=ThemeLabel
Text=#ColorThemeBackground#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(180 - 2)
X=(#SidebarWidth#+190)
W=76
LeftMouseUpAction=[!CommandMeasure "ColorBackgroundInput" "ExecuteBatch ALL"]
Hidden=([&ThemeAsNumber]<>4)

[ColorBackgroundInput]
Measure=Plugin
Plugin=InputText
DefaultValue=#ColorThemeBackground#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(180 - 2)
X=(#SidebarWidth#+190-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables ColorThemeBackground "$UserInput$" "#@#Variables\Global.inc"][!RefreshGroup Monterey]
Hidden=([&ThemeAsNumber]<>4)

[ColorForegroundValue]
Meter=String
MeterStyle=ThemeLabel
Text=#ColorThemeForeground#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(180 - 2)
X=(#SidebarWidth#+490)
W=76
LeftMouseUpAction=[!CommandMeasure "ColorForegroundInput" "ExecuteBatch ALL"]
Hidden=([&ThemeAsNumber]<>4)

[ColorForegroundInput]
Measure=Plugin
Plugin=InputText
DefaultValue=#ColorThemeForeground#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(180 - 2)
X=(#SidebarWidth#+490-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables ColorThemeForeground "$UserInput$" "#@#Variables\Global.inc"][!RefreshGroup Monterey]
Hidden=([&ThemeAsNumber]<>4)

[Line3]
Meter=Shape
Shape=Rectangle (#SidebarWidth# + 20),(225),(#WidgetWidth#-#SidebarWidth#-40),0 | StrokeWidth 0.5 | Stroke Color 808080
