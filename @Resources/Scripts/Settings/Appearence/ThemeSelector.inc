[ThemeSelector]
Meter=Shape
Shape=Rectangle 20,20,(#WidgetWidth# - #SidebarWidth# - 40),115,6 | Fill Color #ForegroundColor#05 | StrokeWidth 0
X=#SidebarWidth#
Y=55
DynamicVariables=1

[ThemeLabel]
Meter=String
Text=#tTheme#
FontFace=#FontFace#
FontWeight=400
FontColor=#ForegroundColor#
FontSize=11
AntiAlias=1
X=(#SidebarWidth#+30)
Y=(85)
DynamicVariables=1
OnUpdateAction=[!SetOption "#Theme#Border" Hidden 0][!SetOption "#Theme#Label" FontWeight 600]
ClipString=2
W=120

[Light]
Meter=Image
ImageName=#@#Images\Settings\light.png
X=(#SidebarWidth#+30)
Y=(120)
W=60
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Light" "#@#Variables\Global.inc"][!RefreshGroup Monterey]

[Dark]
Meter=Image
MeterStyle=Light
ImageName=#@#Images\Settings\dark.png
X=(#SidebarWidth#+100)
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Dark" "#@#Variables\Global.inc"][!RefreshGroup Monterey]

[Auto]
Meter=Image
MeterStyle=Light
ImageName=#@#Images\Settings\auto.png
X=(#SidebarWidth#+170)
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Auto" "#@#Variables\Global.inc"][!ActivateConfig "Monterey\Extras\ThemeUpdater" "ThemeUpdater.ini"][!RefreshGroup Monterey]

[Color]
Meter=Image
MeterStyle=Light
ImageName=#@#Images\Settings\color.png
X=(#SidebarWidth#+240)
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Color" "#@#Variables\Global.inc"][!ActivateConfig "Monterey\Extras\ThemeUpdater" "ThemeUpdater.ini"][!RefreshGroup Monterey]

[Blur]
Meter=Image
MeterStyle=Light
ImageName=#@#Images\Settings\blur.png
X=(#SidebarWidth#+310)
LeftMouseUpAction=[!WriteKeyValue Variables Theme "Blur" "#@#Variables\Global.inc"][!ActivateConfig "Monterey\Extras\ThemeUpdater" "ThemeUpdater.ini"][!RefreshGroup Monterey]

[Border]
Meter=Shape
Shape=Rectangle 0,0,60,40,5 | Fill Color 00000000 | StrokeWidth 1.5 | Stroke Color #ForegroundColor#
DynamicVariables=1
X=(#SidebarWidth#+30)
Y=(120)
Hidden=1

[LightBorder]
Meter=Shape
MeterStyle=Border

[DarkBorder]
Meter=Shape
MeterStyle=Border
X=(#SidebarWidth#+100)

[AutoBorder]
Meter=Shape
MeterStyle=Border
X=(#SidebarWidth#+170)

[ColorBorder]
Meter=Shape
MeterStyle=Border
X=(#SidebarWidth#+240)

[BlurBorder]
Meter=Shape
MeterStyle=Border
X=(#SidebarWidth#+310)

[Label]
Meter=String
FontWeight=400
FontFace=#FontFace#
FontColor=#ForegroundColor#
FontSize=10
AntiAlias=1
StringAlign=Center
X=(#SidebarWidth#+60)
Y=(165)
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
X=(#SidebarWidth#+130)

[AutoLabel]
Meter=String
MeterStyle=Label
Text=#tAutoTheme#
X=(#SidebarWidth#+200)

[ColorLabel]
Meter=String
MeterStyle=Label
Text=#tColorTheme#
X=(#SidebarWidth#+270)

[BlurLabel]
Meter=String
MeterStyle=Label
Text=#tBlurTheme#
X=(#SidebarWidth#+340)
