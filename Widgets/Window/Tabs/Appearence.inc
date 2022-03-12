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
X=(#WidgetPadding#+#SidebarWidth#+155)
Y=(#WidgetPadding#+105)
DynamicVariables=1
OnUpdateAction=[!SetOption "#Theme#Border" Hidden 0][!SetOption "#Theme#Label" FontWeight 600]
ClipString=2
W=120

[Light]
Meter=Image
ImageName=#@#Images\Widgets\Window\light.png
X=(#WidgetPadding#+#SidebarWidth#+160)
Y=(#WidgetPadding#+70)
W=80
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Light" "#@#Settings.inc"][!RefreshApp]

[Dark]
Meter=Image
MeterStyle=Light
ImageName=#@#Images\Widgets\Window\dark.png
X=(#WidgetPadding#+#SidebarWidth#+250)
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Dark" "#@#Settings.inc"][!RefreshApp]

[Auto]
Meter=Image
MeterStyle=Light
ImageName=#@#Images\Widgets\Window\auto.png
X=(#WidgetPadding#+#SidebarWidth#+340)
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Auto" "#@#Settings.inc"][!RefreshApp]

[Color]
Meter=Image
MeterStyle=Light
ImageName=#@#Images\Widgets\Window\color.png
X=(#WidgetPadding#+#SidebarWidth#+430)
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Color" "#@#Settings.inc"][!RefreshApp]

[Border]
Meter=Shape
Shape=Rectangle 0,0,80,53,5 | Fill Color 00000000 | StrokeWidth 2 | Stroke Color #ForegroundColor#
DynamicVariables=1
X=(#WidgetPadding#+#SidebarWidth#+160)
Y=(#WidgetPadding#+70)
Hidden=1

[LightBorder]
Meter=Shape
MeterStyle=Border

[DarkBorder]
Meter=Shape
MeterStyle=Border
X=(#WidgetPadding#+#SidebarWidth#+250)

[AutoBorder]
Meter=Shape
MeterStyle=Border
X=(#WidgetPadding#+#SidebarWidth#+340)

[ColorBorder]
Meter=Shape
MeterStyle=Border
X=(#WidgetPadding#+#SidebarWidth#+430)

[Label]
Meter=String
FontFace=#FontFace#
FontColor=#ForegroundColor#
FontSize=10
AntiAlias=1
StringAlign=Center
X=(#WidgetPadding#+#SidebarWidth#+200)
Y=(#WidgetPadding#+130)
DynamicVariables=1

[LightLabel]
Meter=String
MeterStyle=Label
Text=#tLightTheme#

[DarkLabel]
Meter=String
MeterStyle=Label
Text=#tDarkTheme#
X=(#WidgetPadding#+#SidebarWidth#+290)

[AutoLabel]
Meter=String
MeterStyle=Label
Text=#tAutoTheme#
X=(#WidgetPadding#+#SidebarWidth#+380)

[ColorLabel]
Meter=String
MeterStyle=Label
Text=#tColorTheme#
X=(#WidgetPadding#+#SidebarWidth#+470)

[Line2]
Meter=Shape
Shape=Rectangle (#WidgetPadding#+#SidebarWidth#),(#WidgetPadding#+160),(#WidgetWidth#-#SidebarWidth#),0 | StrokeWidth 0.5 | Stroke Color 808080

[LightThemeTitle]
Meter=String
MeterStyle=ThemeLabel
Text=#tLightTheme# #tTheme#
Y=(#WidgetPadding# + 180)

[LightThemeBackgroundLabel]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
FontWeight=100
Text=#tBackgroundColor#:
Y=(#WidgetPadding# + 210)

[LightBackgroundValue]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
Text=#LightThemeBackground#
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(#WidgetPadding# + 210 - 2)
X=(#WidgetPadding#+#SidebarWidth#+200)
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
Y=(#WidgetPadding# + 210 - 2)
X=(#WidgetPadding#+#SidebarWidth#+200-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables LightThemeBackground "$UserInput$" "#@#Settings.inc"][!RefreshApp]

[LightThemeForegroundLabel]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
FontWeight=100
Text=#tForegroundColor#:
Y=(#WidgetPadding# + 210)
X=(#WidgetPadding# + #SidebarWidth# + 420)

[LightForegroundValue]
Meter=String
MeterStyle=ThemeLabel
Text=#LightThemeForeground#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(#WidgetPadding# + 210 - 2)
X=(#WidgetPadding#+#SidebarWidth#+470)
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
Y=(#WidgetPadding# + 210 - 2)
X=(#WidgetPadding#+#SidebarWidth#+470-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables LightThemeForeground "$UserInput$" "#@#Settings.inc"][!RefreshApp]

[Line3]
Meter=Shape
Shape=Rectangle (#WidgetPadding#+#SidebarWidth#),(#WidgetPadding#+250),(#WidgetWidth#-#SidebarWidth#),0 | StrokeWidth 0.5 | Stroke Color 808080

[DarkThemeTitle]
Meter=String
MeterStyle=ThemeLabel
Text=#tDarkTheme# #tTheme#
Y=(#WidgetPadding# + 270)

[DarkThemeBackgroundLabel]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
FontWeight=100
Text=#tBackgroundColor#:
Y=(#WidgetPadding# + 300)

[DarkBackgroundValue]
Meter=String
MeterStyle=ThemeLabel
Text=#DarkThemeBackground#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(#WidgetPadding# + 300 - 2)
X=(#WidgetPadding#+#SidebarWidth#+200)
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
Y=(#WidgetPadding# + 300 - 2)
X=(#WidgetPadding#+#SidebarWidth#+200-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables DarkThemeBackground "$UserInput$" "#@#Settings.inc"][!RefreshApp]

[DarkThemeForegroundLabel]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
FontWeight=100
Text=#tForegroundColor#:
Y=(#WidgetPadding# + 300)
X=(#WidgetPadding# + #SidebarWidth# + 420)

[DarkForegroundValue]
Meter=String
MeterStyle=ThemeLabel
Text=#DarkThemeForeground#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(#WidgetPadding# + 300 - 2)
X=(#WidgetPadding#+#SidebarWidth#+470)
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
Y=(#WidgetPadding# + 300 - 2)
X=(#WidgetPadding#+#SidebarWidth#+470-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables DarkThemeForeground "$UserInput$" "#@#Settings.inc"][!RefreshApp]

[Line4]
Meter=Shape
Shape=Rectangle (#WidgetPadding#+#SidebarWidth#),(#WidgetPadding#+340),(#WidgetWidth#-#SidebarWidth#),0 | StrokeWidth 0.5 | Stroke Color 808080

[AutoThemeTitle]
Meter=String
MeterStyle=ThemeLabel
Text=#tAutoTheme# #tTheme#
Y=(#WidgetPadding# + 360)

[AutoThemeStartLabel]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
FontWeight=100
Text=#tDarkTheme# #tTheme# #tFrom#:
Y=(#WidgetPadding# + 390)

[AutoThemeStartValue]
Meter=String
MeterStyle=ThemeLabel
Text=#DarkThemeFrom#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(#WidgetPadding# + 390 - 2)
X=(#WidgetPadding#+#SidebarWidth#+200)
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
Y=(#WidgetPadding# + 390 - 2)
X=(#WidgetPadding#+#SidebarWidth#+200-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables DarkThemeFrom "$UserInput$" "#@#Settings.inc"][!RefreshApp]

[AutoThemeEndLabel]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
FontWeight=100
Text=#tTo#:
Y=(#WidgetPadding# + 390)
X=(#WidgetPadding# + #SidebarWidth# + 420)

[AutoThemeEndValue]
Meter=String
MeterStyle=ThemeLabel
Text=#DarkThemeTo#
FontSize=10
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Y=(#WidgetPadding# + 390 - 2)
X=(#WidgetPadding#+#SidebarWidth#+470)
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
Y=(#WidgetPadding# + 390 - 2)
X=(#WidgetPadding#+#SidebarWidth#+470-40)
W=80
StringAlign=Center
DynamicVariables=1
Command1=[!WriteKeyValue Variables DarkThemeTo "$UserInput$" "#@#Settings.inc"][!RefreshApp]

[Line5]
Meter=Shape
Shape=Rectangle (#WidgetPadding#+#SidebarWidth#),(#WidgetPadding#+430),(#WidgetWidth#-#SidebarWidth#),0 | StrokeWidth 0.5 | Stroke Color 808080

[ColorThemeTitle]
Meter=String
MeterStyle=ThemeLabel
Text=#tColorTheme# #tTheme#
Y=(#WidgetPadding# + 450)

[ColorThemeBackgroundLabel]
Meter=String
MeterStyle=ThemeLabel
FontSize=10
FontWeight=100
StringAlign=Center
Text=#tColorThemeDescription#
X=(#WidgetPadding#+(#SidebarWidth#+#WidgetWidth#)*0.5)
Y=(#WidgetPadding# + 480)
W=(#WidgetWidth#-#SidebarWidth#)