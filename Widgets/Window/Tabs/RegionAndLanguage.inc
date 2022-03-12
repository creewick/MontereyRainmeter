[Variables]
@include=#@#Languages\all.inc
WidgetHeight=300

[LangLabel]
Meter=String
Text=#tLanguage#:
FontFace=#FontFace#
FontWeight=400
FontColor=#ForegroundColor#
FontSize=12
AntiAlias=1
StringAlign=Right
X=(#WidgetPadding#+#SidebarWidth#+155)
Y=(#WidgetPadding#+105)
DynamicVariables=1
OnUpdateAction=[!SetOption "#Language#" SolidColor #ForegroundColor#80][!SetOption "#Language#" FontWeight 600][!SetOption "#Units#" SolidColor #ForegroundColor#80][!SetOption "#Units#" FontWeight 600]

[lang]
Meter=String
FontFace=#FontFace#
FontColor=#ForegroundColor#
FontSize=10
AntiAlias=1
Padding=16,2,16,2
StringAlign=Center
SolidColor=#ForegroundColor#40
DynamicVariables=1
Hidden=1
Y=(#WidgetPadding# + 105)

[ru]
Meter=String
MeterStyle=lang
Text=#ru#
Hidden=0
X=(#WidgetPadding#+#SidebarWidth#+210)
LeftMouseUpAction=[!WriteKeyValue Variables Language "ru" "#@#Settings.inc"][!RefreshApp]

[ua]
Meter=String
MeterStyle=lang
Text=#ua#
Hidden=0
X=(#WidgetPadding#+#SidebarWidth#+320)
LeftMouseUpAction=[!WriteKeyValue Variables Language "ua" "#@#Settings.inc"][!RefreshApp]

[en]
Meter=String
MeterStyle=lang
Text=#en#
Hidden=0
X=(#WidgetPadding#+#SidebarWidth#+425)
LeftMouseUpAction=[!WriteKeyValue Variables Language "en" "#@#Settings.inc"][!RefreshApp]

[TempLabel]
Meter=String
MeterStyle=LangLabel
Text=#tTemperature#:
Y=(#WidgetPadding#+150)

[metric]
Meter=String
MeterStyle=lang
Text=#tMetric#
Hidden=0
X=(#WidgetPadding#+#SidebarWidth#+210)
Y=(#WidgetPadding#+150)
LeftMouseUpAction=[!WriteKeyValue Variables Units "metric" "#@#Settings.inc"][!RefreshApp]

[imperial]
Meter=String
MeterStyle=lang
Text=#tImperial#
Hidden=0
X=(#WidgetPadding#+#SidebarWidth#+320)
Y=(#WidgetPadding#+150)
LeftMouseUpAction=[!WriteKeyValue Variables Units "imperial" "#@#Settings.inc"][!RefreshApp]

[standard]
Meter=String
MeterStyle=lang
Text=#tStandard#
Hidden=0
X=(#WidgetPadding#+#SidebarWidth#+425)
Y=(#WidgetPadding#+150)
LeftMouseUpAction=[!WriteKeyValue Variables Units "standard" "#@#Settings.inc"][!RefreshApp]
