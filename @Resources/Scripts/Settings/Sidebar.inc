[Variables]
SidebarWidth=180

[BackgroundMeter]
OnUpdateAction=[!ShowMeter "[#SettingsTab]Shape"]

[Monterey]
Meter=Shape
Shape=Rectangle 10,0,(#SidebarWidth#-20),30,6 | Fill Color #ForegroundColor#20 | StrokeWidth 0
DynamicVariables=1
Y=(25+30*1)

[MontereyText]
Meter=String
Text=Monterey Rainmeter
X=(#SidebarWidth#/2)
Padding=6,6,6,6
DynamicVariables=1
ClipString=1
AntiAlias=1
FontFace=#FontFace#
FontSize=11
FontColor=#ForegroundColor#80
StringAlign=Center
Y=(25+30*1)

[WidgetsShape]
Meter=Shape
Shape=Rectangle 10,0,(#SidebarWidth#-20),30,6 | Fill Color #BackgroundColor#80 | StrokeWidth 0
DynamicVariables=1
Hidden=1
Y=(25+30*2.5)

[WidgetsText]
Meter=String
Text=#tWidgets#
DynamicVariables=1
LeftMouseUpAction=[!WriteKeyValue Variables SettingsTab "Widgets" "#@#Variables\Layout.inc"][!Refresh]
ClipString=1
AntiAlias=1
FontFace=#FontFace#
FontSize=11
FontColor=#ForegroundColor#
Padding=48,6,6,6
Y=(25+30*2.5)
W=(#SidebarWidth#-48-6)

[WidgetsIcon]
Meter=Image
ImageName=#@#Images\Settings\Widgets.png
DynamicVariables=1
Y=(29+30*2.5)
X=18
W=22
H=22

[ExtrasShape]
Meter=Shape
MeterStyle=WidgetsShape
Hidden=1
Y=(25+30*3.5)

[ExtrasText]
Meter=String
MeterStyle=WidgetsText
LeftMouseUpAction=[!WriteKeyValue Variables SettingsTab "Extras" "#@#Variables\Layout.inc"][!Refresh]
Text=#tExtras#
Y=(25+30*3.5)

[ExtrasIcon]
Meter=Image
MeterStyle=WidgetsIcon
ImageName=#@#Images\Settings\Extras.png
Y=(29+30*3.5)

[AppearenceShape]
Meter=Shape
MeterStyle=WidgetsShape
Hidden=1
Y=(25+30*5)

[AppearenceText]
Meter=String
MeterStyle=WidgetsText
LeftMouseUpAction=[!WriteKeyValue Variables SettingsTab "Appearence" "#@#Variables\Layout.inc"][!Refresh]
Text=#tAppearence#
Y=(25+30*5)

[AppearenceIcon]
Meter=Image
MeterStyle=WidgetsIcon
ImageName=#@#Images\Settings\Theme.png
Y=(29+30*5)

[LanguageShape]
Meter=Shape
MeterStyle=WidgetsShape
Hidden=1
Y=(25+30*6)

[LanguageText]
Meter=String
MeterStyle=WidgetsText
LeftMouseUpAction=[!WriteKeyValue Variables SettingsTab "Language" "#@#Variables\Layout.inc"][!Refresh]
Text=#tLanguage#
Y=(25+30*6)

[LanguageIcon]
Meter=Image
MeterStyle=WidgetsIcon
ImageName=#@#Images\Settings\Language.png
Y=(29+30*6)

[BatteryShape]
Meter=Shape
MeterStyle=WidgetsShape
Hidden=1
Y=(25+30*7)

[BatteryText]
Meter=String
MeterStyle=WidgetsText
LeftMouseUpAction=[!WriteKeyValue Variables SettingsTab "Battery" "#@#Variables\Layout.inc"][!Refresh]
Text=#tBattery#
Y=(25+30*7)

[BatteryIcon]
Meter=Image
MeterStyle=WidgetsIcon
ImageName=#@#Images\Settings\Battery.png
Y=(29+30*7)

[SupportShape]
Meter=Shape
MeterStyle=WidgetsShape
Hidden=1
Y=(25+30*8.5)

[SupportText]
Meter=String
MeterStyle=WidgetsText
LeftMouseUpAction=[]
Text=#tSupport#
Y=(25+30*8.5)

[SupportIcon]
Meter=Image
MeterStyle=WidgetsIcon
ImageName=#@#Images\Settings\Support.png
Y=(29+30*8.5)

[AboutShape]
Meter=Shape
MeterStyle=WidgetsShape
Hidden=1
Y=(25+30*9.5)

[AboutText]
Meter=String
MeterStyle=WidgetsText
LeftMouseUpAction=[!WriteKeyValue Variables SettingsTab "About" "#@#Variables\Layout.inc"][!Refresh]
Text=#tAbout#
Y=(25+30*9.5)

[AboutIcon]
Meter=Image
MeterStyle=WidgetsIcon
ImageName=#@#Images\Settings\About.png
Y=(29+30*9.5)
