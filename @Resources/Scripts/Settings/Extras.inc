[Variables]
WidgetHeight=400

[ThemeUpdaterShape]
Meter=Shape
Shape=Rectangle 20,20,(#WidgetWidth# - #SidebarWidth# - 40),40,6 | Fill Color #ForegroundColor#05 | StrokeWidth 0
X=#SidebarWidth#
Y=55
DynamicVariables=1

[ThemeUpdaterMode]
Meter=String
Text=#tThemeUpdater#
FontFace=#FontFace#
FontWeight=400
FontColor=#ForegroundColor#
FontSize=11
AntiAlias=1
X=(#SidebarWidth#+30)
Y=(85)
DynamicVariables=1

[ThemeUpdaterOpened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Extras\ThemeUpdater
UpdateDivider=1
OnChangeAction=[!Refresh]

[ThemeUpdaterFalse]
Meter=Shape
Shape=Rectangle 0,0,38,24,12 | Fill Color 808080 | StrokeWidth 0
Shape2=Rectangle 2,2,20,20,10 | Fill Color ffffff | StrokeWidth 0
Y=(82)
X=(#WidgetWidth# - 30 - 40)
Hidden=([&ThemeUpdaterOpened:] <> -1)
DynamicVariables=1
LeftMouseUpAction=[!ToggleConfig "Monterey\Extras\ThemeUpdater" "ThemeUpdater.ini"]

[ThemeUpdaterTrue]
Meter=Shape
Shape=Rectangle 0,0,38,24,12 | Fill Color 33cc66 | StrokeWidth 0
Shape2=Rectangle 16,2,20,20,10 | Fill Color ffffff | StrokeWidth 0
Y=(82)
X=(#WidgetWidth# - 30 - 40)
Hidden=([&ThemeUpdaterOpened:] <> 1)
DynamicVariables=1
LeftMouseUpAction=[!ToggleConfig "Monterey\Extras\ThemeUpdater" "ThemeUpdater.ini"]

[ThemeUpdaterHelp]
Meter=String
MeterStyle=ThemeUpdaterMode
FontSize=10
FontColor=#ForegroundColor#80
ClipString=2
W=340
H=50
Y=120
Text=#tThemeUpdaterHelp#

[SidebarShape]
Meter=Shape
Shape=Rectangle 20,20,(#WidgetWidth# - #SidebarWidth# - 40),40,6 | Fill Color #ForegroundColor#05 | StrokeWidth 0
X=#SidebarWidth#
Y=160
DynamicVariables=1

[SidebarTitle]
Meter=String
Text=#tSidebar#
FontFace=#FontFace#
FontWeight=400
FontColor=#ForegroundColor#
FontSize=11
AntiAlias=1
X=(#SidebarWidth#+30)
Y=190
DynamicVariables=1

[SidebarOpened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Extras\Sidebar
UpdateDivider=1
OnChangeAction=[!Refresh]

[SidebarFalse]
Meter=Shape
Shape=Rectangle 0,0,38,24,12 | Fill Color 808080 | StrokeWidth 0
Shape2=Rectangle 2,2,20,20,10 | Fill Color ffffff | StrokeWidth 0
Y=(188)
X=(#WidgetWidth# - 30 - 40)
Hidden=([&SidebarOpened:] <> -1)
DynamicVariables=1
LeftMouseUpAction=[!ZPosGroup "1" "Monterey"][!ToggleConfig "Monterey\Extras\Sidebar" "Sidebar.ini"]

[SidebarTrue]
Meter=Shape
Shape=Rectangle 0,0,38,24,12 | Fill Color 33cc66 | StrokeWidth 0
Shape2=Rectangle 16,2,20,20,10 | Fill Color ffffff | StrokeWidth 0
Y=(188)
X=(#WidgetWidth# - 30 - 40)
Hidden=([&SidebarOpened:] <> 1)
DynamicVariables=1
LeftMouseUpAction=[!ZPosGroup "0" "Monterey"][!ToggleConfig "Monterey\Extras\Sidebar" "Sidebar.ini"]

[SidebarHelp]
Meter=String
MeterStyle=ThemeUpdaterMode
FontSize=10
FontColor=#ForegroundColor#80
ClipString=2
W=340
H=50
Y=225
Text=#tSidebarHelp#


[UnlockShape]
Meter=Shape
Shape=Rectangle 20,20,(#WidgetWidth# - #SidebarWidth# - 40),40,6 | Fill Color #ForegroundColor#05 | StrokeWidth 0
X=#SidebarWidth#
Y=265
DynamicVariables=1

[UnlockTitle]
Meter=String
Text=#tUnlock#
FontFace=#FontFace#
FontWeight=400
FontColor=#ForegroundColor#
FontSize=11
AntiAlias=1
X=(#SidebarWidth#+30)
Y=295
DynamicVariables=1

[UnlockOpened]
Measure=Plugin
Plugin=ConfigActive
ConfigName=Monterey\Extras\Unlock
UpdateDivider=1
OnChangeAction=[!Refresh]

[UnlockFalse]
Meter=Shape
Shape=Rectangle 0,0,38,24,12 | Fill Color 808080 | StrokeWidth 0
Shape2=Rectangle 2,2,20,20,10 | Fill Color ffffff | StrokeWidth 0
Y=(292)
X=(#WidgetWidth# - 30 - 40)
Hidden=([&UnlockOpened:] <> -1)
DynamicVariables=1
LeftMouseUpAction=[!ToggleConfig "Monterey\Extras\Unlock" "Unlock.ini"]

[UnlockTrue]
Meter=Shape
Shape=Rectangle 0,0,38,24,12 | Fill Color 33cc66 | StrokeWidth 0
Shape2=Rectangle 16,2,20,20,10 | Fill Color ffffff | StrokeWidth 0
Y=(292)
X=(#WidgetWidth# - 30 - 40)
Hidden=([&UnlockOpened:] <> 1)
DynamicVariables=1
LeftMouseUpAction=[!ToggleConfig "Monterey\Extras\Unlock" "Unlock.ini"]

[UnlockHelp]
Meter=String
MeterStyle=ThemeUpdaterMode
FontSize=10
FontColor=#ForegroundColor#80
ClipString=2
W=340
H=50
Y=330
Text=#tUnlockHelp#
InlineSetting=Weight | 700
InlinePattern=\n.*
LeftMouseUpAction=["#@#Scripts\Extras\Unlock\Install.lnk" "#@#Scripts\Extras\Unlock"]