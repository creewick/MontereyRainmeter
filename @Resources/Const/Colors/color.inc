[Variables]
BackgroundColor=#DarkThemeBackground#
ForegroundColor=#DarkThemeForeground#
IsDark=1
GrayColor = 80808040

[ChameleonMeasure]
Measure=Plugin
Plugin=Chameleon
Type=Desktop

[BackgroundColor]
Measure=Plugin
Plugin=Chameleon
Parent=ChameleonMeasure
Color=Average
OnUpdateAction=[!SetVariable BackgroundColor [BackgroundColor]]

[ForegroundColor]
Measure=Plugin
Plugin=Chameleon
Parent=ChameleonMeasure
Color=Foreground1
OnUpdateAction=[!SetVariable ForegroundColor [ForegroundColor]]

[IsDark]
Measure=Plugin
Plugin=Chameleon
Parent=ChameleonMeasure
Color=Luminance
RegExpSubstitute=1
Substitute="0.[5-9].*":"0","0.[0-4].*":"1"
OnUpdateAction=[!SetVariable IsDark [IsDark]]