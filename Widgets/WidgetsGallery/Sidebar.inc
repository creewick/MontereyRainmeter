[Variables]
SidebarWidth=160

[BackgroundMeter]
Shape=Rectangle 0,0,#WidgetWidth#,#WidgetHeight#,#WidgetRadius# | Fill Color #BackgroundColor# | StrokeWidth 0.5 | Stroke Color 808080
OnUpdateAction=[!SetOption #Tab# SolidColor "#ForegroundColor#20"]

[SidebarMeter]
Meter=Shape
Shape=Rectangle 0,0,#SidebarWidth#,#WidgetHeight#,#WidgetRadius# | Fill Color 80808040 | StrokeWidth 0.5 | Stroke Color 808080
Shape2=Rectangle (#SidebarWidth#/2),0,(#SidebarWidth#/2),#WidgetHeight#
Shape3=Combine Shape | Union Shape2
Padding = #WidgetPadding#,#WidgetPadding#,#WidgetPadding#,#WidgetPadding#
UpdateDivider=-1

[MenuItem]
Meter=String
AntiAlias=1
FontFace=#FontFace#
FontSize=(#SidebarWidth#*0.07)
FontColor=#ForegroundColor#
Y=(#WidgetPadding#+45)
X=#WidgetPadding#
W=(#SidebarWidth#-60)
Padding=44,8,16,8

[Welcome]
Meter=String
MeterStyle=MenuItem
Text=#Welcome#
Y=(#WidgetPadding#+45)
LeftMouseUpAction=[!WriteKeyValue Variables Tab "Welcome" "#@#Settings.inc"][!Refresh]

[WelcomeIcon]
Meter=Image
ImageName=#@#Images\Icons\Welcome.png
ImageTint=#ForegroundColor#
Y=(#WidgetPadding#+52)
X=(#WidgetPadding#+18)
W=(#SidebarWidth#*0.12)

[Settings]
Meter=String
MeterStyle=MenuItem
Text=#Settings#
Y=(#WidgetPadding#+80)
LeftMouseUpAction=[!WriteKeyValue Variables Tab "Settings" "#@#Settings.inc"][!Refresh]

[SettingsIcon]
Meter=Image
MeterStyle=WelcomeIcon
ImageName=#@#Images\Icons\Settings.png
Y=(#WidgetPadding#+87)

[About]
Meter=String
MeterStyle=MenuItem
Text=#About#
Y=(#WidgetPadding#+115)
LeftMouseUpAction=[!WriteKeyValue Variables Tab "About" "#@#Settings.inc"][!Refresh]

[AboutIcon]
Meter=Image
MeterStyle=WelcomeIcon
ImageName=#@#Images\Icons\About.png
Y=(#WidgetPadding#+122)

[WidgetsGroup]
Meter=String
Text=#Widgets#
StringCase=Upper
AntiAlias=1
FontFace=#FontFace#
FontSize=(#SidebarWidth#*0.05)
FontWeight=800
FontColor=#ForegroundColor#80
Y=(#WidgetPadding#+150)
X=#WidgetPadding#
W=(#SidebarWidth#-32)
Padding=16,8,16,8

[Clock]
Meter=String
MeterStyle=MenuItem
Text=#tClock#
Y=(#WidgetPadding#+180)
LeftMouseUpAction=[!WriteKeyValue Variables Tab "Clock" "#@#Settings.inc"][!Refresh]

[ClockIcon]
Meter=Image
ImageName=#@#Images\Icons\Clock.png
Y=(#WidgetPadding#+188)
X=(#WidgetPadding#+18)
W=(#SidebarWidth#*0.12)

[Calendar]
Meter=String
MeterStyle=MenuItem
Text=#Calendar#
Y=(#WidgetPadding#+215)
LeftMouseUpAction=[!WriteKeyValue Variables Tab "Calendar" "#@#Settings.inc"][!Refresh]

[CalendarIcon]
Meter=Image
MeterStyle=ClockIcon
ImageName=#@#Images\Icons\Calendar.png
Y=(#WidgetPadding#+222)

[ActivityMonitor]
Meter=String
MeterStyle=MenuItem
Text=#ActivityMonitor#
Y=(#WidgetPadding#+250)
LeftMouseUpAction=[!WriteKeyValue Variables Tab "ActivityMonitor" "#@#Settings.inc"][!Refresh]

[ActivityMonitorIcon]
Meter=Image
MeterStyle=ClockIcon
ImageName=#@#Images\Icons\ActivityMonitor.png
Y=(#WidgetPadding#+258)

[Weather]
Meter=String
MeterStyle=MenuItem
Text=#Weather#
Y=(#WidgetPadding#+285)
LeftMouseUpAction=[!WriteKeyValue Variables Tab "Weather" "#@#Settings.inc"][!Refresh]

[WeatherIcon]
Meter=Image
MeterStyle=ClockIcon
ImageName=#@#Images\Icons\Weather.png
Y=(#WidgetPadding#+292)
