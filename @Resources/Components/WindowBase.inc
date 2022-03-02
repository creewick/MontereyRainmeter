[BackgroundMeter]
Meter = Shape
DynamicVariables = 1
Shape = Rectangle 0, 0, [WidgetWidth], [WidgetHeight], #WidgetBorderRadius#, #WidgetBorderRadius# | Fill Color 111111ee | StrokeWidth 1 | Stroke Color 666666
Padding = #WidgetPaddingSize#, #WidgetPaddingSize#, #WidgetPaddingSize#, #WidgetPaddingSize#
UpdateDivider=-1

[RedLight]
Meter=Shape
Shape=Ellipse (#WidgetPaddingSize#+24),(#WidgetPaddingSize#+24),6,6 | Fill Color f9615e | StrokeWidth 0
LeftMouseUpAction=[!DeactivateConfig]

[YellowLight]
Meter=Shape
Shape=Ellipse (#WidgetPaddingSize#+44),(#WidgetPaddingSize#+24),6,6 | Fill Color 666666 | StrokeWidth 0

[GreenLight]
Meter=Shape
Shape=Ellipse (#WidgetPaddingSize#+64),(#WidgetPaddingSize#+24),6,6 | Fill Color 666666 | StrokeWidth 0