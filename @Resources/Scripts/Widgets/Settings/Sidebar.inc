[Variables]
SidebarWidth=160

[BackgroundMeter]
OnUpdateAction=[!SetOption #Tab# SolidColor "#ForegroundColor#20"]

[MenuItem]
Meter=String
AntiAlias=1
FontFace=#FontFace#
FontSize=11
FontColor=#ForegroundColor#
Y=(45)
W=(#SidebarWidth#-52)
Padding=44,8,8,8
DynamicVariables=1
ClipString=1

[MenuItemIcon]
Meter=Image
ImageTint=#ForegroundColor#
Y=(52)
X=(18)
W=(#SidebarWidth#*0.12)
DynamicVariables=1

[Widgets]
Meter=String
MeterStyle=MenuItem
Text=#tWidgets#
Y=(10+35*1)
LeftMouseUpAction=[!WriteKeyValue Variables Tab "Widgets" "#@#Variables\Settings.inc"][!Refresh]

[WidgetsIcon]
Meter=Image
MeterStyle=MenuItemIcon
ImageName=#@#Images\Settings\Add.png
Y=(17+35*1)

[SettingsGroup]
Meter=String
MeterStyle=MenuItem
Text=#tSettings#
FontSize=8
FontWeight=800
FontColor=#ForegroundColor#80
StringCase=Upper
Y=(10+35*2)
Padding=16,16,16,8

[Theme]
Meter=String
MeterStyle=MenuItem
Text=#tTheme#
Y=(10+35*3)
LeftMouseUpAction=[!WriteKeyValue Variables Tab "Theme" "#@#Variables\Settings.inc"][!Refresh]

[ThemeIcon]
Meter=Image
MeterStyle=MenuItemIcon
ImageName=#@#Images\Settings\Theme.png
Y=(17+35*3)

[Region]
Meter=String
MeterStyle=MenuItem
Text=#tRegion#
Y=(10+35*4)
LeftMouseUpAction=[!WriteKeyValue Variables Tab "Region" "#@#Variables\Settings.inc"][!Refresh]

[RegionIcon]
Meter=Image
MeterStyle=MenuItemIcon
ImageName=#@#Images\Settings\Region.png
Y=(17+35*4)

[Advanced]
Meter=String
MeterStyle=MenuItem
Text=#tAdvanced#
Y=(10+35*5)
LeftMouseUpAction=[!WriteKeyValue Variables Tab "Advanced" "#@#Variables\Settings.inc"][!Refresh]

[AdvancedIcon]
Meter=Image
MeterStyle=MenuItemIcon
ImageName=#@#Images\Settings\Advanced.png
Y=(17+35*5)


[About]
Meter=String
MeterStyle=MenuItem
Text=#tAbout#
Y=(#WidgetHeight#-50)
LeftMouseUpAction=[!WriteKeyValue Variables Tab "About" "#@#Variables\Settings.inc"][!Refresh]

[AboutIcon]
Meter=Image
MeterStyle=MenuItemIcon
ImageName=#@#Images\Settings\About.png
Y=(#WidgetHeight#-50+7)
