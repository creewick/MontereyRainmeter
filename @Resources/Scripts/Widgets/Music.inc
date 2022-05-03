[TitleMeasure]
Measure=Plugin
Group=Measures
Plugin=#Plugin#
PlayerName=#PlayerName#
PlayerType=Title
UpdateDivider=(#BatterySaverMode# = 0 ? 1 : 2)
OnChangeAction=[!Refresh]

[CoverMeasure]
Measure=Plugin
Group=Measures
Plugin=#Plugin#
PlayerName=#PlayerName#
PlayerType=Cover

[ArtistMeasure]
Measure=Plugin
Group=Measures
Plugin=#Plugin#
PlayerName=#PlayerName#
PlayerType=Artist

[StateMeasure]
Measure=Plugin
Group=Measures
Plugin=#Plugin#
PlayerName=#PlayerName#
PlayerType=State
UpdateDivider=(#BatterySaverMode# = 0 ? 1 : 2)
OnUpdateAction=[!UpdateMeterGroup Buttons]

[IsColorTheme]
Measure=Calc
Formula=([&ThemeAsNumber] = 4) || ([&ThemeAsNumber] = 5)

[CoverChameleonMeasure]
Measure=Plugin
Group=Measures
Plugin=Chameleon
Type=File
Path=[CoverMeasure]
OnUpdateAction=[!UpdateMeasure CoverColor][!UpdateMeasure CoverForegroundColor][!Redraw]

[CoverColor]
Measure=Plugin
Group=Measures
Plugin=Chameleon
Parent=CoverChameleonMeasure
Color=Average
IfCondition=(StateMeasure<>0)
IfTrueAction=[!SetVariable BackgroundColor [CoverColor]][!UpdateMeter BackgroundMeter]
IfCondition2=(StateMeasure=0)
IfTrueAction2=[!SetVariable BackgroundColor #LightThemeBackground#][!UpdateMeter BackgroundMeter]
DynamicVariables=1
Disabled=([&IsColorTheme]=1)

[CoverForegroundColor]
Measure=Plugin
Group=Measures
Plugin=Chameleon
Parent=CoverChameleonMeasure
Color=Foreground1
IfCondition=(StateMeasure<>0)
IfTrueAction=[!SetVariable ForegroundColor [CoverForegroundColor]][!UpdateMeterGroup Buttons][!UpdateMeterGroup Text]
IfCondition2=(StateMeasure=0)
IfTrueAction2=[!SetVariable ForegroundColor #LightThemeForeground#][!UpdateMeterGroup Buttons][!UpdateMeterGroup Text]
DynamicVariables=1
Disabled=([&IsColorTheme]=1)
