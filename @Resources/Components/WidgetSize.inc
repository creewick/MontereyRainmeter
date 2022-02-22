[SmallWidgetSize]
Measure = Calc
Formula = #WidgetBaseSize#

[MediumWidgetSize]
Measure = Calc
Formula = (2 * #WidgetBaseSize# + 2 * #WidgetPaddingSize#)

[LargeWidgetSize]
Measure = Calc
Formula = (4 * #WidgetBaseSize# + 6 * #WidgetPaddingSize#)

[WidgetWidth]
Measure = String
String = #WidgetSize#
DynamicVariables = 1
Substitute = "small":"[SmallWidgetSize]","medium":"[MediumWidgetSize]","wide":"[LargeWidgetSize]","large":"[LargeWidgetSize]"

[WidgetHeight]
Measure = String
String = #WidgetSize#
DynamicVariables = 1
Substitute = "small":"[SmallWidgetSize]","medium":"[MediumWidgetSize]","wide":"[MediumWidgetSize]","large":"[LargeWidgetSize]"
