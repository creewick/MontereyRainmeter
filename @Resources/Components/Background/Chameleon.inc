[BackgroundMeter]
Meter = Shape
DynamicVariables = 1
Shape = Rectangle 0, 0, [WidgetWidth], [WidgetHeight], #WidgetBorderRadius#, #WidgetBorderRadius# | Fill Color [BackgroundColor] | StrokeWidth 0
Padding = #WidgetPaddingSize#, #WidgetPaddingSize#, #WidgetPaddingSize#, #WidgetPaddingSize#

[ChameleonMeasure]
Measure=Plugin
Plugin=Chameleon
Type=Desktop

[BackgroundColor]
Measure=Plugin
Plugin=Chameleon
Parent=ChameleonMeasure
Color=Background1

[ForegroundColor]
Measure=Plugin
Plugin=Chameleon
Parent=ChameleonMeasure
Color=Foreground1

[DarkMode]
Measure=Plugin
Plugin=Chameleon
Parent=ChameleonMeasure
Color=Luminance
RegExpSubstitute=1
Substitute="0.[5-9].*":"0","0.[0-4].*":"1"
