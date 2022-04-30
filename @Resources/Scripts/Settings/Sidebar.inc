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

[Settings]
Meter=String
MeterStyle=MenuItem
Text=#tSettings#
Y=(10+35*2)
LeftMouseUpAction=[!WriteKeyValue Variables Tab "Settings" "#@#Variables\Settings.inc"][!Refresh]

[SettingsIcon]
Meter=Image
MeterStyle=MenuItemIcon
ImageName=#@#Images\Settings\Settings.png
Y=(17+35*2)

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
