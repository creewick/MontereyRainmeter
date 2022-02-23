[BackgroundMeter]
Meter = Shape
DynamicVariables = 1
Shape = Rectangle 0, 0, [WidgetWidth], [WidgetHeight], #WidgetBorderRadius#, #WidgetBorderRadius# | Fill Color [BackgroundColor] | StrokeWidth 0
Padding = #WidgetPaddingSize#, #WidgetPaddingSize#, #WidgetPaddingSize#, #WidgetPaddingSize#
UpdateDivider=-1

[ChameleonMeasure]
Measure=Plugin
Plugin=Chameleon
Type=Desktop
UpdateDivider=-1

[BackgroundColor]
Measure=Plugin
Plugin=Chameleon
Parent=ChameleonMeasure
Color=Background1
UpdateDivider=-1

[ForegroundColor]
Measure=Plugin
Plugin=Chameleon
Parent=ChameleonMeasure
Color=Foreground1
UpdateDivider=-1

[DarkMode]
Measure=Plugin
Plugin=Chameleon
Parent=ChameleonMeasure
Color=Luminance
RegExpSubstitute=1
Substitute="0.[5-9].*":"0","0.[0-4].*":"1"
UpdateDivider=-1
