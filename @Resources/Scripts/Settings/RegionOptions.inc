[LanguageLabel]
Meter=String
MeterStyle=ThemeLabel
Text=#tLanguage#:
Y=(250)

[LanguageValue]
Meter=String
MeterStyle=ThemeLabel
Text=[#[#Language]]
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
X=(#SidebarWidth#+190)
Y=(250-2)
W=76
LeftMouseUpAction=[!SetVariable Context "Languages"][!UpdateMeasure SetLanguageTickMark][!SkinCustomMenu]

[TemperatureLabel]
Meter=String
MeterStyle=ThemeLabel
Text=#tTemperature#:
X=(#SidebarWidth#+440)
Y=(250)

[TemperatureValue]
Meter=String
MeterStyle=ThemeLabel
Padding=2,2,2,2
StringAlign=Center
SolidColor=#ForegroundColor#40
Text=[#t[#Units]]
X=(#SidebarWidth#+490)
Y=(250-2)
W=76
LeftMouseUpAction=[!SetVariable Context "Units"][!UpdateMeasure SetUnitsTickMark][!SkinCustomMenu]

[Line4]
Meter=Shape
Shape=Rectangle (#SidebarWidth# + 20),(295),(#WidgetWidth#-#SidebarWidth#-40),0 | StrokeWidth 0.5 | Stroke Color 808080
