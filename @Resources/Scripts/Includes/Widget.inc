[Rainmeter]
DefaultUpdateDivider=-1
RightMouseUpAction=[!SetVariable Context "Widget"][!SkinCustomMenu]

[BackgroundMeter]
Meter=Shape
Shape=Rectangle 0, 0, #WidgetWidth#, #WidgetHeight#, #WidgetRadius#, #WidgetRadius# | Fill Color #BackgroundColor# | StrokeWidth 0
Padding=#WidgetPadding#, #WidgetPadding#, #WidgetPadding#, #WidgetPadding#
DynamicVariables=1

[Variables]
WidgetPadding=#PaddingBase#
WidgetCenterX=(#WidgetPadding# + #WidgetWidth# / 2)
WidgetCenterY=(#WidgetPadding# + #WidgetHeight# / 2)

@Include=#@#Variables\Global.inc
@Include2=#@#Languages\#Language#\Widget.inc
@Include3=#@#Scripts\Themes\#Theme#.inc
@Include4=#@#Scripts\Sizes\#WidgetSize#.inc
@Include5=#@#Scripts\Includes\Context.inc
@Include6=#@#Scripts\Contexts\Widget.inc
