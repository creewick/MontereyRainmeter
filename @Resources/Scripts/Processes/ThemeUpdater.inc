[TimeNow]
Measure=Time
UpdateDivider=60

[TimeStart]
Measure=Time
TimeStamp=#DarkThemeFrom#
TimeStampFormat=%H:%M

[TimeEnd]
Measure=Time
TimeStamp=#DarkThemeTo#
TimeStampFormat=%H:%M

[SecondsNow]
Measure=Calc
Formula=TimeNow % (60 * 60 * 24)
UpdateDivider=60

[SecondsStart]
Measure=Calc
Formula=TimeStart % (60 * 60 * 24)

[SecondsEnd]
Measure=Calc
Formula=TimeEnd % (60 * 60 * 24)

[IsBetween]
Measure=Calc
Formula=([SecondsNow] >= Min([SecondsStart],[SecondsEnd])) && ([SecondsNow] < Max([SecondsStart],[SecondsEnd]))
IfCondition=(#IsDark#=0) && ([SecondsStart] < [SecondsEnd]) && ([IsBetween] = 1)
IfTrueAction=[!WriteKeyValue Variables IsDark 1 "#@#Settings\Global.inc"][!RefreshGroup Monterey]
IfCondition2=(#IsDark#=0) && ([SecondsStart] > [SecondsEnd]) && ([IsBetween] = 0)
IfTrueAction2=[!WriteKeyValue Variables IsDark 1 "#@#Settings\Global.inc"][!RefreshGroup Monterey]
IfCondition3=(#IsDark#=1) && ([SecondsStart] < [SecondsEnd]) && ([IsBetween] = 0)
IfTrueAction3=[!WriteKeyValue Variables IsDark 0 "#@#Settings\Global.inc"][!RefreshGroup Monterey]
IfCondition4=(#IsDark#=1) && ([SecondsStart] > [SecondsEnd]) && ([IsBetween] = 1)
IfTrueAction4=[!WriteKeyValue Variables IsDark 0 "#@#Settings\Global.inc"][!RefreshGroup Monterey]
DynamicVariables=1
UpdateDivider=60