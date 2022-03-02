[Variables]
@include=#@#Components\WidgetBase.inc

[Time]
Measure=Time
AverageSize=10

[SecondsAngle]
Measure=Calc
Formula=(Time % 60) * 6

[MinutesAngle]
Measure=Calc
Formula=(Time % 3600) / 10
UpdateDivider=30

[HoursAngle]
Measure=Calc
Formula=(Time % 43200) / 120
UpdateDivider=1800

[ClockhandWidth]
Measure=Calc
Formula=[WidgetHeight] * 0.025
DynamicVariables=1

[HourHandHeight]
Measure=Calc
Formula=[WidgetHeight] * 0.17
DynamicVariables=1

[MinuteHandHeight]
Measure=Calc
Formula=[WidgetHeight] * 0.34
DynamicVariables=1

[SecondHandHeight]
Measure=Calc
Formula=[WidgetHeight] * 0.39
DynamicVariables=1
