[Variables]
@include=#@#Languages\all.inc
WidgetHeight=300

[LanguageLabel]
Meter=String
Text=#tLanguage#:
FontFace=#FontFace#
FontColor=#ForegroundColor#
FontSize=10
AntiAlias=1
StringAlign=Right
X=(#SidebarWidth#+155)
Y=(105)
DynamicVariables=1
OnUpdateAction=[!SetOption "#Language#" SolidColor #ForegroundColor#80][!SetOption "#Language#" FontWeight 600][!SetOption "#Units#" SolidColor #ForegroundColor#80][!SetOption "#Units#" FontWeight 600]

[LanguageValue]
Meter=String
Text=[#[#Language]]
FontFace=#FontFace#
FontColor=#ForegroundColor#
FontSize=10
AntiAlias=1
Padding=16,2,16,2
SolidColor=#ForegroundColor#40
DynamicVariables=1
X=(#SidebarWidth#+160)
Y=103
LeftMouseUpAction = [!SetOption Rainmeter ContextTitle "#ru#"][!SetOption Rainmeter ContextAction """[!WriteKeyValue Variables Language "ru" "#@#Settings\Global.inc"][!RefreshGroup Monterey]"""][!SetOption Rainmeter ContextTitle2 "#ua#"][!SetOption Rainmeter ContextAction2 """[!WriteKeyValue Variables Language "ua" "#@#Settings\Global.inc"][!RefreshGroup Monterey]"""][!SetOption Rainmeter ContextTitle3 "#en#"][!SetOption Rainmeter ContextAction3 """[!WriteKeyValue Variables Language "en" "#@#Settings\Global.inc"][!RefreshGroup Monterey]"""][!SetOption Rainmeter ContextTitle4 "#de#"][!SetOption Rainmeter ContextAction4 """[!WriteKeyValue Variables Language "de" "#@#Settings\Global.inc"][!RefreshGroup Monterey]"""][!SkinCustomMenu]

[TemperatureLabel]
Meter=String
MeterStyle=LanguageLabel
Text=#tTemperature#:
X=(#SidebarWidth#+420)

[TemperatureValue]
Meter=String
MeterStyle=LanguageValue
Text=[#t[#Units]]
X=(#SidebarWidth#+430)
LeftMouseUpAction = [!SetOption Rainmeter ContextTitle "#tMetric#"][!SetOption Rainmeter ContextAction """[!WriteKeyValue Variables Units "metric" "#@#Settings\Global.inc"][!RefreshGroup Monterey]"""][!SetOption Rainmeter ContextTitle2 "#tImperial#"][!SetOption Rainmeter ContextAction2 """[!WriteKeyValue Variables Units "imperial" "#@#Settings\Global.inc"][!RefreshGroup Monterey]"""][!SetOption Rainmeter ContextTitle3 "#tStandard#"][!SetOption Rainmeter ContextAction3 """[!WriteKeyValue Variables Units "standard" "#@#Settings\Global.inc"][!RefreshGroup Monterey]"""][!SetOption Rainmeter ContextTitle4 ""][!SkinCustomMenu]
