[AutoThemeMeasure]
Measure=Calc
Formula=#IsDark#
IfCondition=(#IsDark# = 1)
IfTrueAction=[!SetVariable BackgroundColor #DarkThemeBackground#][!SetVariable ForegroundColor #DarkThemeForeground#]
IfFalseAction=[!SetVariable BackgroundColor #LightThemeBackground#][!SetVariable ForegroundColor #LightThemeForeground#]