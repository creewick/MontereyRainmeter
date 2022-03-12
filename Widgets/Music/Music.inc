[TitleMeasure]
Measure=Plugin
Group=Measures
Plugin=MediaPlayer
PlayerType=Title
UpdateDivider=10
OnChangeAction=[!UpdateMeasureGroup Measures][!UpdateMeterGroup Text][!Redraw]

[CoverMeasure]
Measure=Plugin
Group=Measures
Plugin=MediaPlayer
PlayerType=Cover

[ArtistMeasure]
Measure=Plugin
Group=Measures
Plugin=MediaPlayer
PlayerType=Artist

[StateMeasure]
Measure=Plugin
Group=Measures
Plugin=MediaPlayer
PlayerType=State
UpdateDivider=5
OnChangeAction=[!UpdateMeterGroup Buttons][!Redraw]

[Variables]
IsColorTheme=0

[IsColorTheme]
Measure=String
Group=Measures
String=#Theme#
IfMatch=Color
IfMatchAction=[!SetVariable IsColorTheme 1]

[CoverChameleonMeasure]
Measure=Plugin
Group=Measures
Plugin=Chameleon
Type=File
Path=[CoverMeasure]

[CoverColor]
Measure=Plugin
Group=Measures
Plugin=Chameleon
Parent=CoverChameleonMeasure
Color=Average
IfCondition=(#IsColorTheme#<>1) && (StateMeasure<>0)
IfTrueAction=[!SetVariable BackgroundColor [CoverColor]][!UpdateMeter BackgroundMeter]
IfCondition2=(#IsColorTheme#<>1) && (StateMeasure=0)
IfTrueAction2=[!SetVariable BackgroundColor #BackgroundColor#][!UpdateMeter BackgroundMeter]
DynamicVariables=1

[CoverForegroundColor]
Measure=Plugin
Group=Measures
Plugin=Chameleon
Parent=CoverChameleonMeasure
Color=Foreground1
IfCondition=(#IsColorTheme#<>1) && (StateMeasure<>0)
IfTrueAction=[!SetVariable ForegroundColor [CoverForegroundColor]][!UpdateMeterGroup Buttons]
IfCondition2=(#IsColorTheme#<>1) && (StateMeasure=0)
IfTrueAction2=[!SetVariable ForegroundColor #ForegroundColor#][!UpdateMeterGroup Buttons]
DynamicVariables=1

[CoverIsDark]
Measure=Plugin
Group=Measures
Plugin=Chameleon
Parent=CoverChameleonMeasure
Color=Luminance
RegExpSubstitute=1
Substitute="0.[5-9].*":"0","0.[0-4].*":"1"
IfCondition=(#IsColorTheme# <> 1) && (StateMeasure=0)
IfTrueAction=[!SetVariable IsDark 0]
IfCondition2=(#IsColorTheme# <> 1) && (StateMeasure<>0)
IfTrueAction2=[!SetVariable IsDark [CoverIsDark]]
DynamicVariables=1