[BackgroundMeter]
Meter = Shape
DynamicVariables = 1
Shape = Rectangle 0, 0, [WidgetWidth], [WidgetHeight], #WidgetBorderRadius#, #WidgetBorderRadius# | Fill Color [BackgroundColor] | StrokeWidth 0
Padding = #WidgetPaddingSize#, #WidgetPaddingSize#, #WidgetPaddingSize#, #WidgetPaddingSize#

[BackgroundColor]
Measure = String
String = #DarkMode#
DynamicVariables = 1
Substitute = "0":"#LightBackground#", "1":"#DarkBackground#"
OnUpdateAction = [!UpdateMeter BackgroundMeter]

[ForegroundColor]
Measure = String
String = #DarkMode#
DynamicVariables = 1
Substitute = "0":"#DarkForeground#", "1":"#LightForeground#"
