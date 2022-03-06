[CommonGroup]
Meter=String
Text=#CommonSettings#
FontFace=#FontFace#
FontSize=(#WidgetHeight# * 0.03)
FontColor=#ForegroundColor#
FontWeight=500
AntiAlias=1
X=(#WidgetPaddingSize# + #SidebarWidth# + #WidgetWidth# * 0.02)
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.02)
W=(#WidgetWidth# * 0.3)
ClipString=1

[Option1Title]
Meter=String
Text=#LanguageText#
FontFace=#FontFace#
FontSize=(#WidgetHeight# * 0.025)
FontColor=#ForegroundColor#
AntiAlias=1
X=(#WidgetPaddingSize# + #SidebarWidth# + #WidgetWidth# * 0.04)
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.10)
W=(#WidgetWidth# * 0.3)
ClipString=1

[Option1Value]
Meter=String
Text=#Language#
FontFace=#FontFace#
FontSize=(#WidgetHeight# * 0.025)
FontColor=#ForegroundColor#
FontWeight=300
AntiAlias=1
StringAlign=Center
X=(#WidgetPaddingSize# + #SidebarWidth# + #WidgetWidth# * 0.4)
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.10)
W=(#WidgetWidth# * 0.095)
SolidColor=80808020
ClipString=1
LeftMouseUpAction=[!CommandMeasure "Option1Input" "ExecuteBatch ALL"]

[Option1Input]
Measure=Plugin
Plugin=InputText
DefaultValue=#Language#
FontFace=#FontFace#
FontSize=(#WidgetHeight# * 0.025)
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
StringAlign=Center
X=(#WidgetPaddingSize# + #SidebarWidth# + #WidgetWidth# * 0.35)
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.10 - 2)
W=(#WidgetWidth# * 0.1)
H=(#WidgetHeight# * 0.05)
Command1=[!WriteKeyValue Variables Language "$UserInput$" "#@#Settings.inc"][!Refresh][!RefreshApp]

[ColorGroup]
Meter=String
MeterStyle=CommonGroup
Text=#ColorSettings#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.18)

[Option2Title]
Meter=String
MeterStyle=Option1Title
Text=#DarkThemeText#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.26)

[Option2Value]
Meter=String
MeterStyle=Option1Value
Text=#DarkMode#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.26)
LeftMouseUpAction=[!CommandMeasure "Option2Input" "ExecuteBatch ALL"]

[Option2Input]
Measure=Plugin
Plugin=InputText
DefaultValue=#DarkMode#
FontFace=#FontFace#
FontSize=(#WidgetHeight# * 0.025)
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
StringAlign=Center
X=(#WidgetPaddingSize# + #SidebarWidth# + #WidgetWidth# * 0.35)
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.26)
W=(#WidgetWidth# * 0.1)
H=(#WidgetHeight# * 0.05)
Command1=[!WriteKeyValue Variables DarkMode "$UserInput$" "#@#Settings.inc"][!Refresh][!RefreshApp]

[Option3Title]
Meter=String
MeterStyle=Option1Title
Text=#DarkBackgroundText#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.34)

[Option3Value]
Meter=String
MeterStyle=Option1Value
Text=#DarkBackground#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.34)
LeftMouseUpAction=[!CommandMeasure "Option3Input" "ExecuteBatch ALL"]

[Option3Input]
Measure=Plugin
Plugin=InputText
DefaultValue=#DarkBackground#
FontFace=#FontFace#
FontSize=(#WidgetHeight# * 0.025)
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
StringAlign=Center
X=(#WidgetPaddingSize# + #SidebarWidth# + #WidgetWidth# * 0.35)
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.34)
W=(#WidgetWidth# * 0.1)
H=(#WidgetHeight# * 0.05)
Command1=[!WriteKeyValue Variables DarkBackground "$UserInput$" "#@#Settings.inc"][!Refresh][!RefreshApp]

[Option4Title]
Meter=String
MeterStyle=Option1Title
Text=#LightBackgroundText#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.4)

[Option4Value]
Meter=String
MeterStyle=Option1Value
Text=#LightBackground#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.4)
LeftMouseUpAction=[!CommandMeasure "Option4Input" "ExecuteBatch ALL"]

[Option4Input]
Measure=Plugin
Plugin=InputText
DefaultValue=#LightBackground#
FontFace=#FontFace#
FontSize=(#WidgetHeight# * 0.025)
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
StringAlign=Center
X=(#WidgetPaddingSize# + #SidebarWidth# + #WidgetWidth# * 0.35)
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.4)
W=(#WidgetWidth# * 0.1)
H=(#WidgetHeight# * 0.05)
Command1=[!WriteKeyValue Variables LightBackground "$UserInput$" "#@#Settings.inc"][!Refresh][!RefreshApp]

[Option5Title]
Meter=String
MeterStyle=Option1Title
Text=#DarkForegroundText#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.48)

[Option5Value]
Meter=String
MeterStyle=Option1Value
Text=#DarkForeground#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.48)
LeftMouseUpAction=[!CommandMeasure "Option5Input" "ExecuteBatch ALL"]

[Option5Input]
Measure=Plugin
Plugin=InputText
DefaultValue=#DarkForeground#
FontFace=#FontFace#
FontSize=(#WidgetHeight# * 0.025)
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
StringAlign=Center
X=(#WidgetPaddingSize# + #SidebarWidth# + #WidgetWidth# * 0.35)
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.48)
W=(#WidgetWidth# * 0.1)
H=(#WidgetHeight# * 0.05)
Command1=[!WriteKeyValue Variables DarkForeground "$UserInput$" "#@#Settings.inc"][!Refresh][!RefreshApp]

[Option6Title]
Meter=String
MeterStyle=Option1Title
Text=#LightForegroundText#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.54)

[Option6Value]
Meter=String
MeterStyle=Option1Value
Text=#LightForeground#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.54)
LeftMouseUpAction=[!CommandMeasure "Option6Input" "ExecuteBatch ALL"]

[Option6Input]
Measure=Plugin
Plugin=InputText
DefaultValue=#LightForeground#
FontFace=#FontFace#
FontSize=(#WidgetHeight# * 0.025)
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
StringAlign=Center
X=(#WidgetPaddingSize# + #SidebarWidth# + #WidgetWidth# * 0.35)
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.54)
W=(#WidgetWidth# * 0.1)
H=(#WidgetHeight# * 0.05)
Command1=[!WriteKeyValue Variables LightForeground "$UserInput$" "#@#Settings.inc"][!Refresh][!RefreshApp]

[AdvancedGroup]
Meter=String
MeterStyle=CommonGroup
Text=#AdvancedSettings#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.62)

[Option7Title]
Meter=String
MeterStyle=Option1Title
Text=#WidgetBaseSizeText#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.7)

[Option7Value]
Meter=String
MeterStyle=Option1Value
Text=#WidgetBaseSize#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.7)
LeftMouseUpAction=[!CommandMeasure "Option7Input" "ExecuteBatch ALL"]

[Option7Input]
Measure=Plugin
Plugin=InputText
DefaultValue=#WidgetBaseSize#
FontFace=#FontFace#
FontSize=(#WidgetHeight# * 0.025)
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
StringAlign=Center
X=(#WidgetPaddingSize# + #SidebarWidth# + #WidgetWidth# * 0.35)
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.7)
W=(#WidgetWidth# * 0.1)
H=(#WidgetHeight# * 0.05)
Command1=[!WriteKeyValue Variables WidgetBaseSize "$UserInput$" "#@#Settings.inc"][!Refresh][!RefreshApp]

[Option8Title]
Meter=String
MeterStyle=Option1Title
Text=#WidgetPaddingSizeText#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.76)

[Option8Value]
Meter=String
MeterStyle=Option1Value
Text=#WidgetPaddingSize#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.76)
LeftMouseUpAction=[!CommandMeasure "Option8Input" "ExecuteBatch ALL"]

[Option8Input]
Measure=Plugin
Plugin=InputText
DefaultValue=#WidgetPaddingSize#
FontFace=#FontFace#
FontSize=(#WidgetHeight# * 0.025)
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
StringAlign=Center
X=(#WidgetPaddingSize# + #SidebarWidth# + #WidgetWidth# * 0.35)
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.76)
W=(#WidgetWidth# * 0.1)
H=(#WidgetHeight# * 0.05)
Command1=[!WriteKeyValue Variables WidgetPaddingSize "$UserInput$" "#@#Settings.inc"][!Refresh][!RefreshApp]


[Option9Title]
Meter=String
MeterStyle=Option1Title
Text=#WidgetBorderRadiusText#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.82)

[Option9Value]
Meter=String
MeterStyle=Option1Value
Text=#WidgetBorderRadius#
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.82)
LeftMouseUpAction=[!CommandMeasure "Option9Input" "ExecuteBatch ALL"]

[Option9Input]
Measure=Plugin
Plugin=InputText
DefaultValue=#WidgetBorderRadius#
FontFace=#FontFace#
FontSize=(#WidgetHeight# * 0.025)
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
StringAlign=Center
X=(#WidgetPaddingSize# + #SidebarWidth# + #WidgetWidth# * 0.35)
Y=(#WidgetPaddingSize# + 50 + #WidgetHeight# * 0.82)
W=(#WidgetWidth# * 0.1)
H=(#WidgetHeight# * 0.05)
Command1=[!WriteKeyValue Variables WidgetBorderRadius "$UserInput$" "#@#Settings.inc"][!Refresh][!RefreshApp]

