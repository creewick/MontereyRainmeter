[Variables]
WidgetHeight=380

[Widget1Icon]
Meter=Image
ImageName=#@#Images\Icons\Clock.png
W=50
X=(#SidebarWidth#+20)
Y=(45+20)

[Widget1Title]
Meter=String
Text=#tClock#
FontSize=12
FontFace=#FontFace#
FontColor=#ForegroundColor#
FontWeight=400
AntiAlias=1
DynamicVariables=1
X=(#SidebarWidth#+80)
Y=(45+20)

[Widget1Description]
Meter=String
Text=#tClockDescription#
FontSize=10
FontFace=#FontFace#
FontColor=#ForegroundColor#80
AntiAlias=1
DynamicVariables=1
ClipString=2
X=(#SidebarWidth#+80)
Y=(45+40)
W=120

[Widget1Add]
Meter=Shape
Shape=Rectangle 0,0,80,20,10 | Fill Color #ForegroundColor#20 | StrokeWidth 0
X=(#SidebarWidth#+220)
Y=(45+35)
DynamicVariables=1
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Clock" "Medium.ini"]

[Widget1Opened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Widgets\Clock
RegExpSubstitute=1
Substitute=".+":"#tRemove#","^$":"#tAdd#"
UpdateDivider=1

[Widget1AddText]
Meter=String
MeasureName=Widget1Opened
FontSize=8
FontFace=#FontFace#
FontColor=#ForegroundColor#
FontWeight=600
AntiAlias=1
DynamicVariables=1
StringAlign=Center
StringCase=Upper
X=(#SidebarWidth#+260)
Y=(45+38)
UpdateDivider=1

[Widget2Icon]
Meter=Image
MeterStyle=Widget1Icon
ImageName=#@#Images\Icons\Calendar.png
X=(#SidebarWidth#+340)

[Widget2Title]
Meter=String
MeterStyle=Widget1Title
Text=#tCalendar#
X=(#SidebarWidth#+400)

[Widget2Description]
Meter=String
MeterStyle=Widget1Description
Text=#tCalendarDescription#
X=(#SidebarWidth#+400)

[Widget2Add]
Meter=Shape
MeterStyle=Widget1Add
X=(#SidebarWidth#+540)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Calendar" "Medium.ini"]

[Widget2AddText]
Meter=String
MeasureName=Widget2Opened
MeterStyle=Widget1AddText
X=(#SidebarWidth#+580)

[Widget2Opened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Widgets\Calendar
RegExpSubstitute=1
Substitute=".+":"#tRemove#","^$":"#tAdd#"
UpdateDivider=1

[Widget3Icon]
Meter=Image
MeterStyle=Widget1Icon
ImageName=#@#Images\Icons\ActivityMonitor.png
Y=(45+100)

[Widget3Title]
Meter=String
MeterStyle=Widget1Title
Text=#tActivityMonitor#
Y=(45+100)

[Widget3Description]
Meter=String
MeterStyle=Widget1Description
Text=#tActivityMonitorDescription#
Y=(45+120)

[Widget3Add]
Meter=Shape
MeterStyle=Widget1Add
Y=(45+115)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\ActivityMonitor" "Medium.ini"]

[Widget3Opened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Widgets\Activity Monitor
RegExpSubstitute=1
Substitute=".+":"#tRemove#","^$":"#tAdd#"
UpdateDivider=1

[Widget3AddText]
Meter=String
MeasureName=Widget3Opened
MeterStyle=Widget1AddText
Y=(45+118)

[Widget4Icon]
Meter=Image
MeterStyle=Widget1Icon
ImageName=#@#Images\Icons\Weather.png
X=(#SidebarWidth#+340)
Y=(45+100)

[Widget4Title]
Meter=String
MeterStyle=Widget1Title
Text=#tWeather#
X=(#SidebarWidth#+400)
Y=(45+100)

[Widget4Description]
Meter=String
MeterStyle=Widget1Description
Text=#tWeatherDescription#
X=(#SidebarWidth#+400)
Y=(45+120)

[Widget4Add]
Meter=Shape
MeterStyle=Widget1Add
X=(#SidebarWidth#+540)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Weather" "Medium.ini"]
Y=(45+115)

[Widget4Opened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Widgets\Weather
RegExpSubstitute=1
Substitute=".+":"#tRemove#","^$":"#tAdd#"
UpdateDivider=1

[Widget4AddText]
Meter=String
MeasureName=Widget4Opened
MeterStyle=Widget1AddText
X=(#SidebarWidth#+580)
Y=(45+118)

[Widget5Icon]
Meter=Image
MeterStyle=Widget1Icon
ImageName=#@#Images\Icons\Notes.png
Y=(45+180)

[Widget5Title]
Meter=String
MeterStyle=Widget1Title
Text=#tNotes#
Y=(45+180)

[Widget5Description]
Meter=String
MeterStyle=Widget1Description
Text=#tNotesDescription#
Y=(45+200)

[Widget5Add]
Meter=Shape
MeterStyle=Widget1Add
Y=(45+195)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Notes" "Medium.ini"]

[Widget5Opened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Widgets\Notes
RegExpSubstitute=1
Substitute=".+":"#tRemove#","^$":"#tAdd#"
UpdateDivider=1

[Widget5AddText]
Meter=String
MeasureName=Widget5Opened
MeterStyle=Widget1AddText
Y=(45+198)

[Widget6Icon]
Meter=Image
MeterStyle=Widget1Icon
ImageName=#@#Images\Icons\Music.png
X=(#SidebarWidth#+340)
Y=(45+180)

[Widget6Title]
Meter=String
MeterStyle=Widget1Title
Text=#tMusic#
X=(#SidebarWidth#+400)
Y=(45+180)

[Widget6Description]
Meter=String
MeterStyle=Widget1Description
Text=#tMusicDescription#
X=(#SidebarWidth#+400)
Y=(45+200)

[Widget6Add]
Meter=Shape
MeterStyle=Widget1Add
X=(#SidebarWidth#+540)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Music" "Medium.ini"]
Y=(45+195)

[Widget6Opened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Widgets\Music
RegExpSubstitute=1
Substitute=".+":"#tRemove#","^$":"#tAdd#"
UpdateDivider=1

[Widget6AddText]
Meter=String
MeasureName=Widget6Opened
MeterStyle=Widget1AddText
X=(#SidebarWidth#+580)
Y=(45+198)

[Widget7Icon]
Meter=Image
MeterStyle=Widget1Icon
ImageName=#@#Images\Icons\Volume.png
Y=(45+260)

[Widget7Title]
Meter=String
MeterStyle=Widget1Title
Text=#tVolume#
Y=(45+260)

[Widget7Description]
Meter=String
MeterStyle=Widget1Description
Text=#tVolumeDescription#
Y=(45+280)

[Widget7Add]
Meter=Shape
MeterStyle=Widget1Add
Y=(45+275)
LeftMouseUpAction=[!ToggleConfig "Monterey\Widgets\Volume" "Medium.ini"]

[Widget7Opened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Widgets\Volume
RegExpSubstitute=1
Substitute=".+":"#tRemove#","^$":"#tAdd#"
UpdateDivider=1

[Widget7AddText]
Meter=String
MeasureName=Widget7Opened
MeterStyle=Widget1AddText
Y=(45+278)