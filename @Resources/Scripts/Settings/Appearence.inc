[Variables]
WidgetHeight=520

[ThemeLabel]
Meter=String
Text=#tTheme#:
FontFace=#FontFace#
FontWeight=400
FontColor=#ForegroundColor#
FontSize=12
AntiAlias=1
StringAlign=Right
X=(#SidebarWidth#+155)
Y=(105)
DynamicVariables=1
OnUpdateAction=[!SetOption "#Theme#Border" Hidden 0][!SetOption "#Theme#Label" FontWeight 600]
ClipString=2
W=120

[Light]
Meter=Image
ImageName=#@#Images\Settings\light.png
X=(#SidebarWidth#+160)
Y=(70)
W=80
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Light" "#@#Settings\Global.inc"][!RefreshGroup Monterey]

[Dark]
Meter=Image
MeterStyle=Light
ImageName=#@#Images\Settings\dark.png
X=(#SidebarWidth#+250)
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Dark" "#@#Settings\Global.inc"][!RefreshGroup Monterey]

[Auto]
Meter=Image
MeterStyle=Light
ImageName=#@#Images\Settings\auto.png
X=(#SidebarWidth#+340)
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Auto" "#@#Settings\Global.inc"][!ActivateConfig "Monterey\Processes" "Processes.ini"][!RefreshGroup Monterey]

[Color]
Meter=Image
MeterStyle=Light
ImageName=#@#Images\Settings\color.png
X=(#SidebarWidth#+430)
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Color" "#@#Settings\Global.inc"][!ActivateConfig "Monterey\Processes" "Processes.ini"][!RefreshGroup Monterey]

[Border]
Meter=Shape
Shape=Rectangle 0,0,80,53,5 | Fill Color 00000000 | StrokeWidth 2 | Stroke Color #ForegroundColor#
DynamicVariables=1
X=(#SidebarWidth#+160)
Y=(70)
Hidden=1

[LightBorder]
Meter=Shape
MeterStyle=Border

[DarkBorder]
Meter=Shape
MeterStyle=Border
X=(#SidebarWidth#+250)

[AutoBorder]
Meter=Shape
MeterStyle=Border
X=(#SidebarWidth#+340)

[ColorBorder]
Meter=Shape
MeterStyle=Border
X=(#SidebarWidth#+430)

[Label]
Meter=String
FontFace=#FontFace#
FontColor=#ForegroundColor#
FontSize=10
AntiAlias=1
StringAlign=Center
X=(#SidebarWidth#+200)
Y=(130)
DynamicVariables=1

[LightLabel]
Meter=String
MeterStyle=Label
Text=#tLightTheme#

[DarkLabel]
Meter=String
MeterStyle=Label
Text=#tDarkTheme#
X=(#SidebarWidth#+290)

[AutoLabel]
Meter=String
MeterStyle=Label
Text=#tAutoTheme#
X=(#SidebarWidth#+380)

[ColorLabel]
Meter=String
MeterStyle=Label
Text=#tColorTheme#
X=(#SidebarWidth#+470)

[Line2]
Meter=Shape
Shape=Rectangle (#SidebarWidth#),(160),(#WidgetWidth#-#SidebarWidth#),0 | StrokeWidth 0.5 | Stroke Color 808080

[LightThemeTitle]
Meter=String
MeterStyle=ThemeLabel
Text=#tLightTheme# #tTheme#
Y=(180)

[LightThemeBackgroundLabel]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
FontWeight=100
Text=#tBackgroundColor#:
Y=(210)

[LightBackgroundValue]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
Text=#LightThemeBackground#
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(210 - 2)
X=(#SidebarWidth#+200)
W=76
LeftMouseUpAction=[!CommandMeasure "LightBackgroundInput" "ExecuteBatch ALL"]

[LightBackgroundInput]
Measure=Plugin
Plugin=InputText
DefaultValue=#LightThemeBackground#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(210 - 2)
X=(#SidebarWidth#+200-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables LightThemeBackground "$UserInput$" "#@#Settings\Global.inc"][!RefreshGroup Monterey]

[LightThemeForegroundLabel]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
FontWeight=100
Text=#tForegroundColor#:
Y=(210)
X=(#SidebarWidth# + 420)

[LightForegroundValue]
Meter=String
MeterStyle=ThemeLabel
Text=#LightThemeForeground#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(210 - 2)
X=(#SidebarWidth#+470)
W=76
LeftMouseUpAction=[!CommandMeasure "LightForegroundInput" "ExecuteBatch ALL"]

[LightForegroundInput]
Measure=Plugin
Plugin=InputText
DefaultValue=#LightThemeForeground#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(210 - 2)
X=(#SidebarWidth#+470-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables LightThemeForeground "$UserInput$" "#@#Settings\Global.inc"][!RefreshGroup Monterey]

[Line3]
Meter=Shape
Shape=Rectangle (#SidebarWidth#),(250),(#WidgetWidth#-#SidebarWidth#),0 | StrokeWidth 0.5 | Stroke Color 808080

[DarkThemeTitle]
Meter=String
MeterStyle=ThemeLabel
Text=#tDarkTheme# #tTheme#
Y=(270)

[DarkThemeBackgroundLabel]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
FontWeight=100
Text=#tBackgroundColor#:
Y=(300)

[DarkBackgroundValue]
Meter=String
MeterStyle=ThemeLabel
Text=#DarkThemeBackground#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(300 - 2)
X=(#SidebarWidth#+200)
W=76
LeftMouseUpAction=[!CommandMeasure "DarkBackgroundInput" "ExecuteBatch ALL"]

[DarkBackgroundInput]
Measure=Plugin
Plugin=InputText
DefaultValue=#DarkThemeBackground#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(300 - 2)
X=(#SidebarWidth#+200-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables DarkThemeBackground "$UserInput$" "#@#Settings\Global.inc"][!RefreshGroup Monterey]

[DarkThemeForegroundLabel]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
FontWeight=100
Text=#tForegroundColor#:
Y=(300)
X=(#SidebarWidth# + 420)

[DarkForegroundValue]
Meter=String
MeterStyle=ThemeLabel
Text=#DarkThemeForeground#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(300 - 2)
X=(#SidebarWidth#+470)
W=76
LeftMouseUpAction=[!CommandMeasure "DarkForegroundInput" "ExecuteBatch ALL"]

[DarkForegroundInput]
Measure=Plugin
Plugin=InputText
DefaultValue=#DarkThemeForeground#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(300 - 2)
X=(#SidebarWidth#+470-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables DarkThemeForeground "$UserInput$" "#@#Settings\Global.inc"][!RefreshGroup Monterey]

[Line4]
Meter=Shape
Shape=Rectangle (#SidebarWidth#),(340),(#WidgetWidth#-#SidebarWidth#),0 | StrokeWidth 0.5 | Stroke Color 808080

[AutoThemeTitle]
Meter=String
MeterStyle=ThemeLabel
Text=#tAutoTheme# #tTheme#
Y=(360)

[AutoThemeStartLabel]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
FontWeight=100
Text=#tDarkTheme# #tTheme# #tFrom#:
Y=(390)

[AutoThemeStartValue]
Meter=String
MeterStyle=ThemeLabel
Text=#DarkThemeFrom#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(390 - 2)
X=(#SidebarWidth#+200)
W=76
LeftMouseUpAction=[!CommandMeasure "AutoThemeStartInput" "ExecuteBatch ALL"]

[AutoThemeStartInput]
Measure=Plugin
Plugin=InputText
DefaultValue=#DarkThemeFrom#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(390 - 2)
X=(#SidebarWidth#+200-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables DarkThemeFrom "$UserInput$" "#@#Settings\Global.inc"][!RefreshGroup Monterey]

[AutoThemeEndLabel]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
FontWeight=100
Text=#tTo#:
Y=(390)
X=(#SidebarWidth# + 420)

[AutoThemeEndValue]
Meter=String
MeterStyle=ThemeLabel
Text=#DarkThemeTo#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(390 - 2)
X=(#SidebarWidth#+470)
W=76
LeftMouseUpAction=[!CommandMeasure "AutoThemeEndInput" "ExecuteBatch ALL"]

[AutoThemeEndInput]
Measure=Plugin
Plugin=InputText
DefaultValue=#DarkThemeTo#
FontFace=#FontFace#
FontSize=10
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
Y=(390 - 2)
X=(#SidebarWidth#+470-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables DarkThemeTo "$UserInput$" "#@#Settings\Global.inc"][!RefreshGroup Monterey]

[Line5]
Meter=Shape
Shape=Rectangle (#SidebarWidth#),(430),(#WidgetWidth#-#SidebarWidth#),0 | StrokeWidth 0.5 | Stroke Color 808080

[ColorThemeTitle]
Meter=String
MeterStyle=ThemeLabel
Text=#tColorTheme# #tTheme#
Y=(450)

[ColorThemeBackgroundLabel]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
FontWeight=100
StringAlign=Center
Text=#tColorThemeDescription#
X=((#SidebarWidth#+#WidgetWidth#)*0.5)
Y=(480)
W=(#WidgetWidth#-#SidebarWidth#)