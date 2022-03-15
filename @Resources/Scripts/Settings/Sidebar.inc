[Variables]
SidebarWidth=160

[BackgroundMeter]
OnUpdateAction=[!SetOption #Tab# SolidColor "#ForegroundColor#20"]

[SidebarMeter]
Meter=Shape
Shape=Rectangle 0,0,#SidebarWidth#,#WidgetHeight#,#WidgetRadius# | Fill Color #GrayColor# | StrokeWidth 0.5 | Stroke Color 808080
Shape2=Rectangle (#SidebarWidth#/2),0,(#SidebarWidth#/2),#WidgetHeight#
Shape3=Combine Shape | Union Shape2
UpdateDivider=-1

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
LeftMouseUpAction=[!WriteKeyValue Variables Tab "Widgets" "#@#Settings\Settings.inc"][!Refresh]

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

[Appearence]
Meter=String
MeterStyle=MenuItem
Text=#tAppearence#
Y=(10+35*3)
LeftMouseUpAction=[!WriteKeyValue Variables Tab "Appearence" "#@#Settings\Settings.inc"][!Refresh]

[AppearenceIcon]
Meter=Image
MeterStyle=MenuItemIcon
ImageName=#@#Images\Settings\Theme.png
Y=(17+35*3)

[Region]
Meter=String
MeterStyle=MenuItem
Text=#tRegion#
Y=(10+35*4)
LeftMouseUpAction=[!WriteKeyValue Variables Tab "Region" "#@#Settings\Settings.inc"][!Refresh]

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
LeftMouseUpAction=[!WriteKeyValue Variables Tab "Advanced" "#@#Settings\Settings.inc"][!Refresh]

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
LeftMouseUpAction=[!WriteKeyValue Variables Tab "About" "#@#Settings\Settings.inc"][!Refresh]

[AboutIcon]
Meter=Image
MeterStyle=MenuItemIcon
ImageName=#@#Images\Settings\About.png
Y=(#WidgetHeight#-50+7)
