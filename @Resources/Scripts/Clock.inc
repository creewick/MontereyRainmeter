[Variables]
ClockhandWidth = (#WidgetHeight# * 0.025)
HourHandHeight = (#WidgetHeight# * 0.17)
MinuteHandHeight = (#WidgetHeight# * 0.34)
SecondHandHeight = (#WidgetHeight# * 0.39)
Time=0
SecondsAngle=0
MinutesAngle=0
HoursAngle=0

[Time]
Measure=Time
UpdateDivider=1
OnChangeAction=[!CommandMeasure TimeAnimation "Stop 1"][!SetVariable Time [#CURRENTSECTION#:]][!CommandMeasure TimeAnimation "Execute 1"]

[TimeAnimation]
Measure=Plugin
Plugin=ActionTimer
ActionList1=Repeat Tick, 100, 10/
Tick=[!SetVariable SecondsAngle ((#Time#%60)*6)][!SetVariable MinutesAngle ((#Time#%3600)/10)][!SetVariable HoursAngle ((#Time#%43200)/120)][!UpdateMeasureGroup Meters][!Redraw]
DynamicVariables=1

; [SecondsAngle]
; Measure=Calc
; Formula=(Time % 60) * 6
; UpdateDivider=1

; [MinutesAngle]
; Measure=Calc
; Formula=(Time % 3600) / 10
; UpdateDivider=(10*3)

; [HoursAngle]
; Measure=Calc
; Formula=(Time % 43200) / 120
; UpdateDivider=(10*60*3)

[ClockCircleColor]
Measure=String
String=#IsDark#
Substitute="0":"ffffffa0","1":"ffffff20"
DynamicVariables=1

[ClockCircle]
Meter=Shape
Shape=Ellipse (#WidgetCenterX#),(#WidgetCenterY#),(#WidgetHeight# * (0.5 - 1 * #ClockfacePadding#)),(#WidgetHeight# * (0.5 - 1 * #ClockfacePadding#)) | Fill Color [ClockCircleColor] | StrokeWidth 0
DynamicVariables=1

[Clockface]
Meter=Image
ImageName=#@#Images\Clock\face-#IsDark#.png
X=(#WidgetPadding# + #WidgetWidth# * 0.5 - (#WidgetHeight# * (1 - 2 * #ClockfacePadding#) * 0.5))
Y=(#WidgetPadding# + #WidgetHeight# * 0.5 - (#WidgetHeight# * (1 - 2 * #ClockfacePadding#) * 0.5))
W=(#WidgetHeight# * (1 - 2 * #ClockfacePadding#))
H=(#WidgetHeight# * (1 - 2 * #ClockfacePadding#))
DynamicVariables=1

[Container]
Meter=Shape
DynamicVariables=1
Shape=Rectangle 0, 0, #WidgetWidth#, #WidgetHeight# | Fill Color 000000 | StrokeWidth 0
Padding=#WidgetPadding#, #WidgetPadding#, #WidgetPadding#, #WidgetPadding#

[ClockHand]
Meter=Shape
Group=Meters
Shape=Ellipse #WidgetCenterX#,#WidgetCenterY#,#ClockhandWidth#,#ClockhandWidth# | Fill Color 00000000 | Stroke Color #ForegroundColor# | StrokeWidth (#ClockhandWidth# / 2)
Shape2=Rectangle (#WidgetCenterX# - #ClockhandWidth# * 0.25),(#WidgetCenterY# - 3 * #ClockhandWidth#),(#ClockhandWidth#/2),(2*#ClockhandWidth#) | Fill Color #ForegroundColor# | StrokeWidth 0
Shape3=Rectangle (#WidgetCenterX# - #ClockhandWidth# / 2),(#WidgetCenterY# - 2 * #ClockhandWidth# - #HourHandHeight#),#ClockhandWidth#,#HourHandHeight#,(#ClockhandWidth# / 2)
Shape4=Combine Shape2 | Union Shape3 | Rotate #HoursAngle#,#WidgetCenterX#,#WidgetCenterY#
Container=Container
DynamicVariables=1
UpdateDivider=(10*60*3)

[MinuteHand]
Meter=Shape
Group=Meters
Shape=Ellipse #WidgetCenterX#,#WidgetCenterY#,#ClockhandWidth#,#ClockhandWidth# | Fill Color 00000000 | Stroke Color #ForegroundColor# | StrokeWidth (#ClockhandWidth# / 2)
Shape2=Rectangle (#WidgetCenterX# - #ClockhandWidth# * 0.25),(#WidgetCenterY# - 3 * #ClockhandWidth#),(#ClockhandWidth#/2),(2*#ClockhandWidth#) | Fill Color #ForegroundColor# | StrokeWidth 0
Shape3=Rectangle (#WidgetCenterX# - #ClockhandWidth# / 2),(#WidgetCenterY# - 2 * #ClockhandWidth# - #MinuteHandHeight#),#ClockhandWidth#,#MinuteHandHeight#,(#ClockhandWidth# / 2)
Shape4=Combine Shape2 | Union Shape3 | Rotate #MinutesAngle#,#WidgetCenterX#,#WidgetCenterY#
Container=Container
DynamicVariables=1
UpdateDivider=(10*3)

[SecondHand]
Meter=Shape
Group=Meters
Shape=Ellipse #WidgetCenterX#,#WidgetCenterY#,(#ClockhandWidth#*0.6),(#ClockhandWidth#*0.6) | Fill Color 00000000 | Stroke Color ff9900 | StrokeWidth (#ClockhandWidth# / 4)
Shape2=Rectangle (#WidgetCenterX# - #ClockhandWidth# / 8),(#WidgetCenterY# - #ClockhandWidth# / 2 - #SecondHandHeight#),(#ClockhandWidth#/4),#SecondHandHeight# | Fill Color ff9900 | StrokeWidth 0
Shape3=Rectangle (#WidgetCenterX# - #ClockhandWidth# / 8),(#WidgetCenterY# + #ClockhandWidth# / 2),(#ClockhandWidth#/4),(2*#ClockhandWidth#) | Fill Color ff9900 | StrokeWidth 0
Shape4=Combine Shape2 | Union Shape3 | Rotate #SecondsAngle#,#WidgetCenterX#,#WidgetCenterY#
Container=Container
Hidden=(#ShowSeconds# = 0)
DynamicVariables=1
UpdateDivider=1