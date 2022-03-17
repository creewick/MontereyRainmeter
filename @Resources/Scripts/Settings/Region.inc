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
X=(#SidebarWidth#+155)
Y=(105)
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
Y=(105)

[ru]
Meter=String
MeterStyle=lang
Text=#ru#
Hidden=0
X=(#SidebarWidth#+210)
LeftMouseUpAction=[!WriteKeyValue Variables Language "ru" "#@#Settings\Global.inc"][!RefreshGroup Monterey]

[ua]
Meter=String
MeterStyle=lang
Text=#ua#
Hidden=0
X=(#SidebarWidth#+320)
LeftMouseUpAction=[!WriteKeyValue Variables Language "ua" "#@#Settings\Global.inc"][!RefreshGroup Monterey]

[en]
Meter=String
MeterStyle=lang
Text=#en#
Hidden=0
X=(#SidebarWidth#+425)
LeftMouseUpAction=[!WriteKeyValue Variables Language "en" "#@#Settings\Global.inc"][!RefreshGroup Monterey]

[de]
Meter=String
MeterStyle=lang
Text=#de#
Hidden=0
X=(#SidebarWidth#+525)
LeftMouseUpAction=[!WriteKeyValue Variables Language "de" "#@#Settings\Global.inc"][!RefreshGroup Monterey]

[TempLabel]
Meter=String
MeterStyle=LangLabel
Text=#tTemperature#:
Y=(150)

[metric]
Meter=String
MeterStyle=lang
Text=#tMetric#
Hidden=0
X=(#SidebarWidth#+210)
Y=(150)
LeftMouseUpAction=[!WriteKeyValue Variables Units "metric" "#@#Settings\Global.inc"][!RefreshGroup Monterey]

[imperial]
Meter=String
MeterStyle=lang
Text=#tImperial#
Hidden=0
X=(#SidebarWidth#+320)
Y=(150)
LeftMouseUpAction=[!WriteKeyValue Variables Units "imperial" "#@#Settings\Global.inc"][!RefreshGroup Monterey]

[standard]
Meter=String
MeterStyle=lang
Text=#tStandard#
Hidden=0
X=(#SidebarWidth#+425)
Y=(150)
LeftMouseUpAction=[!WriteKeyValue Variables Units "standard" "#@#Settings\Global.inc"][!RefreshGroup Monterey]
