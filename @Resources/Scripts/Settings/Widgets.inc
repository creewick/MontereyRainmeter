[Variables]
WidgetHeight=550
@Include1=#@#Variables\Layout.inc
@Include2=#@#Languages\#Language#\Widgets\Clock.inc
@Include3=#@#Languages\#Language#\Widgets\Calendar.inc
@Include4=#@#Languages\#Language#\Widgets\Monitor.inc
@Include5=#@#Languages\#Language#\Widgets\Weather.inc
@Include6=#@#Languages\#Language#\Widgets\Notes.inc
@Include7=#@#Languages\#Language#\Widgets\Reminders.inc
@Include8=#@#Languages\#Language#\Widgets\Music.inc
@Include9=#@#Languages\#Language#\Widgets\Volume.inc
@Include10=#@#Languages\#Language#\Widgets\Timer.inc

[Widgets]
Meter=Shape
Shape=Rectangle 20,20,(#WidgetWidth# - #SidebarWidth# - 40),450,6 | Fill Color #ForegroundColor#05 | StrokeWidth 0
X=#SidebarWidth#
Y=55
DynamicVariables=1

[Widget1Icon]
Meter=Image
ImageName=#@#Images\Icons\Clock.png
W=30
X=(#SidebarWidth#+30)
Y=(55+30)

[Widget1Title]
Meter=String
Text=#tClock#
FontSize=11
FontFace=#FontFace#
FontColor=#ForegroundColor#
FontWeight=400
AntiAlias=1
DynamicVariables=1
X=(#SidebarWidth#+70)
Y=(55+35)

[Widget1Opened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Widgets\Clock
UpdateDivider=1
OnChangeAction=[!Refresh]

[Widget1False]
Meter=Shape
Shape=Rectangle 0,0,38,24,12 | Fill Color 808080 | StrokeWidth 0
Shape2=Rectangle 2,2,20,20,10 | Fill Color ffffff | StrokeWidth 0
Y=(88)
X=(#WidgetWidth# - 30 - 40)
Hidden=([&Widget1Opened:] <> -1)
DynamicVariables=1
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Clock" "#ClockWidgetSize#.ini"]

[Widget1True]
Meter=Shape
Shape=Rectangle 0,0,38,24,12 | Fill Color 33cc66 | StrokeWidth 0
Shape2=Rectangle 16,2,20,20,10 | Fill Color ffffff | StrokeWidth 0
Y=(88)
X=(#WidgetWidth# - 30 - 40)
Hidden=([&Widget1Opened:] <> 1)
DynamicVariables=1
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Clock" "#ClockWidgetSize#.ini"]

[Line1]
Meter=Shape
Shape=Rectangle (#SidebarWidth# + 20),(125),(#WidgetWidth#-#SidebarWidth#-40),0 | StrokeWidth 0.5 | Stroke Color 80808080

[Widget2Icon]
Meter=Image
MeterStyle=Widget1Icon
ImageName=#@#Images\Icons\Calendar.png
Y=(55+80)

[Widget2Title]
Meter=String
MeterStyle=Widget1Title
Text=#tCalendar#
Y=(55+85)

[Widget2Opened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Widgets\Calendar
UpdateDivider=1
OnChangeAction=[!Refresh]

[Widget2False]
Meter=Shape
MeterStyle=Widget1False
Y=(138)
Hidden=([&Widget2Opened:] <> -1)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Calendar" "#CalendarWidgetSize#.ini"]

[Widget2True]
Meter=Shape
MeterStyle=Widget1True
Y=(138)
Hidden=([&Widget2Opened:] <> 1)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Calendar" "#CalendarWidgetSize#.ini"]

[Line2]
Meter=Shape
Shape=Rectangle (#SidebarWidth# + 20),(175),(#WidgetWidth#-#SidebarWidth#-40),0 | StrokeWidth 0.5 | Stroke Color 80808080

[Widget3Icon]
Meter=Image
MeterStyle=Widget1Icon
ImageName=#@#Images\Icons\Monitor.png
Y=(45+140)

[Widget3Title]
Meter=String
MeterStyle=Widget1Title
Text=#tMonitor#
Y=(45+145)

[Widget3Opened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Widgets\Monitor
UpdateDivider=1
OnChangeAction=[!Refresh]

[Widget3False]
Meter=Shape
MeterStyle=Widget1False
Y=(188)
Hidden=([&Widget3Opened:] <> -1)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Monitor" "#MonitorWidgetSize#.ini"]

[Widget3True]
Meter=Shape
MeterStyle=Widget1True
Y=(188)
Hidden=([&Widget3Opened:] <> 1)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Monitor" "#MonitorWidgetSize#.ini"]

[Line3]
Meter=Shape
Shape=Rectangle (#SidebarWidth# + 20),(225),(#WidgetWidth#-#SidebarWidth#-40),0 | StrokeWidth 0.5 | Stroke Color 80808080

[Widget4Icon]
Meter=Image
MeterStyle=Widget1Icon
ImageName=#@#Images\Icons\Weather.png
Y=(45+190)

[Widget4Title]
Meter=String
MeterStyle=Widget1Title
Text=#tWeather#
Y=(45+195)

[Widget4Opened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Widgets\Weather
UpdateDivider=1
OnChangeAction=[!Refresh]

[Widget4False]
Meter=Shape
MeterStyle=Widget1False
Y=(238)
Hidden=([&Widget4Opened:] <> -1)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Weather" "#WeatherWidgetSize#.ini"]

[Widget4True]
Meter=Shape
MeterStyle=Widget1True
Y=(238)
Hidden=([&Widget4Opened:] <> 1)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Weather" "#WeatherWidgetSize#.ini"]

[Line4]
Meter=Shape
Shape=Rectangle (#SidebarWidth# + 20),(275),(#WidgetWidth#-#SidebarWidth#-40),0 | StrokeWidth 0.5 | Stroke Color 80808080

[Widget5Icon]
Meter=Image
MeterStyle=Widget1Icon
ImageName=#@#Images\Icons\Notes.png
Y=(45+240)

[Widget5Title]
Meter=String
MeterStyle=Widget1Title
Text=#tNotes#
Y=(45+245)

[Widget5Opened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Widgets\Notes
UpdateDivider=1
OnChangeAction=[!Refresh]

[Widget5False]
Meter=Shape
MeterStyle=Widget1False
Y=(288)
Hidden=([&Widget5Opened:] <> -1)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Notes" "#NotesWidgetSize#.ini"]

[Widget5True]
Meter=Shape
MeterStyle=Widget1True
Y=(288)
Hidden=([&Widget5Opened:] <> 1)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Notes" "#NotesWidgetSize#.ini"]

[Line5]
Meter=Shape
Shape=Rectangle (#SidebarWidth# + 20),(325),(#WidgetWidth#-#SidebarWidth#-40),0 | StrokeWidth 0.5 | Stroke Color 80808080

[Widget6Icon]
Meter=Image
MeterStyle=Widget1Icon
ImageName=#@#Images\Icons\Reminders.png
Y=(45+290)

[Widget6Title]
Meter=String
MeterStyle=Widget1Title
Text=#tReminders#
Y=(45+295)

[Widget6Opened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Widgets\Reminders
UpdateDivider=1
OnChangeAction=[!Refresh]

[Widget6False]
Meter=Shape
MeterStyle=Widget1False
Y=(338)
Hidden=([&Widget6Opened:] <> -1)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Reminders" "#RemindersWidgetSize#.ini"]

[Widget6True]
Meter=Shape
MeterStyle=Widget1True
Y=(338)
Hidden=([&Widget6Opened:] <> 1)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Reminders" "#RemindersWidgetSize#.ini"]

[Line6]
Meter=Shape
Shape=Rectangle (#SidebarWidth# + 20),(375),(#WidgetWidth#-#SidebarWidth#-40),0 | StrokeWidth 0.5 | Stroke Color 80808080

[Widget7Icon]
Meter=Image
MeterStyle=Widget1Icon
ImageName=#@#Images\Icons\Music.png
Y=(45+340)

[Widget7Title]
Meter=String
MeterStyle=Widget1Title
Text=#tMusic#
Y=(45+345)

[Widget7Opened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Widgets\Music
UpdateDivider=1
OnChangeAction=[!Refresh]

[Widget7False]
Meter=Shape
MeterStyle=Widget1False
Y=(388)
Hidden=([&Widget7Opened:] <> -1)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Music" "#MusicWidgetSize#.ini"]

[Widget7True]
Meter=Shape
MeterStyle=Widget1True
Y=(388)
Hidden=([&Widget7Opened:] <> 1)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Music" "#MusicWidgetSize#.ini"]

[Line7]
Meter=Shape
Shape=Rectangle (#SidebarWidth# + 20),(425),(#WidgetWidth#-#SidebarWidth#-40),0 | StrokeWidth 0.5 | Stroke Color 80808080

[Widget8Icon]
Meter=Image
MeterStyle=Widget1Icon
ImageName=#@#Images\Icons\Volume.png
Y=(45+390)

[Widget8Title]
Meter=String
MeterStyle=Widget1Title
Text=#tVolume#
Y=(45+395)

[Widget8Opened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Widgets\Volume
UpdateDivider=1
OnChangeAction=[!Refresh]

[Widget8False]
Meter=Shape
MeterStyle=Widget1False
Y=(438)
Hidden=([&Widget8Opened:] <> -1)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Volume" "#VolumeWidgetSize#.ini"]

[Widget8True]
Meter=Shape
MeterStyle=Widget1True
Y=(438)
Hidden=([&Widget8Opened:] <> 1)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Volume" "#VolumeWidgetSize#.ini"]

[Line8]
Meter=Shape
Shape=Rectangle (#SidebarWidth# + 20),(475),(#WidgetWidth#-#SidebarWidth#-40),0 | StrokeWidth 0.5 | Stroke Color 80808080

[Widget9Icon]
Meter=Image
MeterStyle=Widget1Icon
ImageName=#@#Images\Icons\Timer.png
Y=(45+440)

[Widget9Title]
Meter=String
MeterStyle=Widget1Title
Text=#tTimer#
Y=(45+445)

[Widget9Opened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Widgets\Timer
UpdateDivider=1
OnChangeAction=[!Refresh]

[Widget9False]
Meter=Shape
MeterStyle=Widget1False
Y=(488)
Hidden=([&Widget9Opened:] <> -1)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Timer" "#TimerWidgetSize#.ini"]

[Widget9True]
Meter=Shape
MeterStyle=Widget1True
Y=(488)
Hidden=([&Widget9Opened:] <> 1)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Timer" "#TimerWidgetSize#.ini"]

