[BackgroundMeter]
Meter = Shape
DynamicVariables = 1
Shape = Rectangle 0, 0, [WidgetWidth], [WidgetHeight], #WidgetBorderRadius#, #WidgetBorderRadius# | Fill Color [BackgroundColor]ee | StrokeWidth 0
Padding = #WidgetPaddingSize#, #WidgetPaddingSize#, #WidgetPaddingSize#, #WidgetPaddingSize#
UpdateDivider=10

[ChameleonMeasure]
Measure=Plugin
Plugin=Chameleon
Type=Desktop
UpdateDivider=10

[BackgroundColor]
Measure=Plugin
Plugin=Chameleon
Parent=ChameleonMeasure
Color=Average
UpdateDivider=10

[ForegroundColor]
Measure=Plugin
Plugin=Chameleon
Parent=ChameleonMeasure
Color=Foreground1
UpdateDivider=10

[DarkMode]
Measure=Plugin
Plugin=Chameleon
Parent=ChameleonMeasure
Color=Luminance
RegExpSubstitute=1
Substitute="0.[5-9].*":"0","0.[0-4].*":"1"
UpdateDivider=10
