[BackgroundMeter]
Meter = Shape
DynamicVariables = 1
Shape = Rectangle 0, 0, #WidgetWidth#, #WidgetHeight#, #WidgetRadius#, #WidgetRadius# | Fill Color #BackgroundColor# | StrokeWidth 0
Padding = #WidgetPadding#, #WidgetPadding#, #WidgetPadding#, #WidgetPadding#

[Variables]
@include  = #@#Settings.inc
@include1 = #@#Languages\#Language#.inc
@include2 = #@#Const\Colors\#Theme#.inc
@include3 = #@#Const\Sizes\#WidgetSize#.inc
@include4 = #@#Components\RightClickMenu.inc

WidgetCenterX = (#WidgetPadding# + #WidgetWidth# / 2)
WidgetCenterY = (#WidgetPadding# + #WidgetHeight# / 2)