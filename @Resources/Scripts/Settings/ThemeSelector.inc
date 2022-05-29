[ThemeLabel]
Meter=String
Text=#tTheme#:
FontFace=#FontFace#
FontWeight=200
FontColor=#ForegroundColor#
FontSize=10
AntiAlias=1
StringAlign=Right
X=(#SidebarWidth#+140)
Y=(95)
DynamicVariables=1
OnUpdateAction=[!SetOption "#Theme#Border" Hidden 0][!SetOption "#Theme#Label" FontWeight 600]
ClipString=2
W=120

[Light]
Meter=Image
ImageName=#@#Images\Settings\light.png
X=(#SidebarWidth#+150)
Y=(70)
W=60
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Light" "#@#Variables\Global.inc"][!RefreshGroup Monterey]

[Dark]
Meter=Image
MeterStyle=Light
ImageName=#@#Images\Settings\dark.png
X=(#SidebarWidth#+230)
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Dark" "#@#Variables\Global.inc"][!RefreshGroup Monterey]

[Auto]
Meter=Image
MeterStyle=Light
ImageName=#@#Images\Settings\auto.png
X=(#SidebarWidth#+310)
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Auto" "#@#Variables\Global.inc"][!ActivateConfig "Monterey\Extras\Processes" "Processes.ini"][!RefreshGroup Monterey]

[Color]
Meter=Image
MeterStyle=Light
ImageName=#@#Images\Settings\color.png
X=(#SidebarWidth#+390)
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Color" "#@#Variables\Global.inc"][!ActivateConfig "Monterey\Extras\Processes" "Processes.ini"][!RefreshGroup Monterey]

[Blur]
Meter=Image
MeterStyle=Light
ImageName=#@#Images\Settings\blur.png
X=(#SidebarWidth#+470)
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Blur" "#@#Variables\Global.inc"][!ActivateConfig "Monterey\Extras\Processes" "Processes.ini"][!RefreshGroup Monterey]

[Border]
Meter=Shape
Shape=Rectangle 0,0,60,40,5 | Fill Color 00000000 | StrokeWidth 1.5 | Stroke Color #ForegroundColor#
DynamicVariables=1
X=(#SidebarWidth#+150)
Y=(70)
Hidden=1

[LightBorder]
Meter=Shape
MeterStyle=Border

[DarkBorder]
Meter=Shape
MeterStyle=Border
X=(#SidebarWidth#+230)

[AutoBorder]
Meter=Shape
MeterStyle=Border
X=(#SidebarWidth#+310)

[ColorBorder]
Meter=Shape
MeterStyle=Border
X=(#SidebarWidth#+390)

[BlurBorder]
Meter=Shape
MeterStyle=Border
X=(#SidebarWidth#+470)

[Label]
Meter=String
FontFace=#FontFace#
FontColor=#ForegroundColor#
FontSize=10
AntiAlias=1
StringAlign=Center
X=(#SidebarWidth#+180)
Y=(120)
W=(60)
DynamicVariables=1

[LightLabel]
Meter=String
MeterStyle=Label
Text=#tLightTheme#

[DarkLabel]
Meter=String
MeterStyle=Label
Text=#tDarkTheme#
X=(#SidebarWidth#+260)

[AutoLabel]
Meter=String
MeterStyle=Label
Text=#tAutoTheme#
X=(#SidebarWidth#+340)

[ColorLabel]
Meter=String
MeterStyle=Label
Text=#tColorTheme#
X=(#SidebarWidth#+420)

[BlurLabel]
Meter=String
MeterStyle=Label
Text=#tBlurTheme#
X=(#SidebarWidth#+500)

[Line2]
Meter=Shape
Shape=Rectangle (#SidebarWidth# + 20),(155),(#WidgetWidth#-#SidebarWidth#-40),0 | StrokeWidth 0.5 | Stroke Color 808080
