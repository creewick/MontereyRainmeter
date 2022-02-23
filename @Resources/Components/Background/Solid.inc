[BackgroundMeter]
Meter = Shape
DynamicVariables = 1
Shape = Rectangle 0, 0, [WidgetWidth], [WidgetHeight], #WidgetBorderRadius#, #WidgetBorderRadius# | Fill Color #BackgroundColor# | StrokeWidth 0
Padding = #WidgetPaddingSize#, #WidgetPaddingSize#, #WidgetPaddingSize#, #WidgetPaddingSize#
UpdateDivider=-1

[SetBackgroundColor]
Measure = Calc
DynamicVariables = 1
IfCondition = #DarkMode#=0
IfTrueAction = [!SetVariable BackgroundColor #LightBackground#][!SetVariable ForegroundColor #DarkForeground#][!UpdateMeter BackgroundMeter]
IfFalseAction = [!SetVariable BackgroundColor #DarkBackground#][!SetVariable ForegroundColor #LightForeground#][!UpdateMeter BackgroundMeter]
UpdateDivider=-1
