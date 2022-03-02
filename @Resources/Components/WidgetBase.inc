[Variables]
@include=#@#Settings.inc
@include1=#@#Languages\#Language#.inc
@include2=#@#Components\RightClickMenu.inc

[SmallWidgetSize]
Measure = Calc
Formula = #WidgetBaseSize#
UpdateDivider=-1

[MediumWidgetSize]
Measure = Calc
Formula = (2 * #WidgetBaseSize# + 2 * #WidgetPaddingSize#)
UpdateDivider=-1

[LargeWidgetSize]
Measure = Calc
Formula = (4 * #WidgetBaseSize# + 6 * #WidgetPaddingSize#)
UpdateDivider=-1

[WidgetWidth]
Measure = String
String = #WidgetSize#
DynamicVariables = 1
Substitute = "small":"[SmallWidgetSize]","medium":"[MediumWidgetSize]","wide":"[LargeWidgetSize]","large":"[LargeWidgetSize]"
UpdateDivider=-1

[WidgetHeight]
Measure = String
String = #WidgetSize#
DynamicVariables = 1
Substitute = "small":"[SmallWidgetSize]","medium":"[MediumWidgetSize]","wide":"[MediumWidgetSize]","large":"[LargeWidgetSize]"
UpdateDivider=-1

[WidgetCenterX]
Measure = Calc
Formula = (#WidgetPaddingSize# + [WidgetWidth] / 2)
DynamicVariables = 1
UpdateDivider=-1

[WidgetCenterY]
Measure = Calc
Formula = (#WidgetPaddingSize# + [WidgetHeight] / 2)
DynamicVariables = 1
UpdateDivider=-1