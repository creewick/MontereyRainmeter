[Variables]
WidgetSize=large
@include=#@#Settings.inc
@include1=#@#Languages\#Language#.inc
@include2=#@#Components\Background\Solid.inc
@include3=#@#Components\WidgetBase.inc

[Rainmeter]
RightMouseUpAction=[]

[IconMeter]
Meter=Image
ImageName=#@#Images\Icons\#WidgetName#.png
X=(#WidgetPadding# + #WidgetWidth# * 0.06)
Y=(#WidgetPadding# + #WidgetHeight# * 0.06)
W=(#WidgetWidth# * 0.1)
H=(#WidgetHeight# * 0.1)

[Title]
Meter=String
Text=[#t[#WidgetName]]
FontSize=(#WidgetWidth# * 0.035)
FontFace=#FontFace#
FontColor=#ForegroundColor#
FontWeight=600
AntiAlias=1
X=(#WidgetPadding# + #WidgetWidth# * 0.2)
Y=(#WidgetPadding# + #WidgetHeight# * 0.08)

[SaveText]
Meter=String
Text=#tSave#
FontFace=#FontFace#
FontSize=(#WidgetWidth# * 0.03)
FontColor=#ForegroundColor#
AntiAlias=1
StringAlign=Right
X=(#WidgetPadding# + #WidgetWidth# * 0.92)
Y=(#WidgetPadding# + #WidgetHeight# * 0.08)
LeftMouseUpAction=[!ActivateConfig "#CURRENTCONFIG#" "#ReturnTo#"]
SolidColor=80808040
Padding=12,2,12,2

[Description]
Meter=String
Text=[#t[#WidgetName]Description]
FontSize=(#WidgetWidth# * 0.0325)
FontFace=#FontFace#
FontColor=128,128,128
FontWeight=300
AntiAlias=1
X=(#WidgetPadding# + #WidgetWidth# * 0.05)
Y=(#WidgetPadding# + #WidgetHeight# * 0.19)

; [Option1Title]
; Meter=String
; Text=#Option1Title#
; FontFace=#FontFace#
; FontSize=(#WidgetWidth# * 0.04)
; FontColor=#ForegroundColor#
; FontWeight=500
; AntiAlias=1
; X=(#WidgetPadding# + #WidgetWidth# * 0.05)
; Y=(#WidgetPadding# + #WidgetHeight# * 0.33)
; W=(#WidgetWidth# * 0.7)
; ClipString=1
; Hidden=(#OptionsCount# < 1)

; [Option1Value]
; Meter=String
; Text=[#[#Option1]]
; FontFace=#FontFace#
; FontSize=(#WidgetWidth# * 0.035)
; FontColor=#ForegroundColor#
; FontWeight=300
; AntiAlias=1
; StringAlign=Center
; X=(#WidgetPadding# + #WidgetWidth# * 0.85)
; Y=(#WidgetPadding# + #WidgetHeight# * 0.33)
; W=(#WidgetWidth# * 0.13)
; SolidColor=80808020
; Padding=2,2,2,2
; ClipString=1
; Hidden=(#OptionsCount# < 1)
; LeftMouseUpAction=[!CommandMeasure "Option1Input" "ExecuteBatch ALL"]

; [Option1Input]
; Measure=Plugin
; Plugin=InputText
; DefaultValue=[#[#Option1]]
; FontFace=#FontFace#
; FontSize=(#WidgetWidth# * 0.04)
; FontColor=#ForegroundColor#
; SolidColor=#BackgroundColor#
; X=(#WidgetPadding# + #WidgetWidth# * 0.78)
; Y=(#WidgetPadding# + #WidgetHeight# * 0.33)
; W=(#WidgetWidth# * 0.15)
; H=(#WidgetHeight# * 0.08)
; StringAlign=Center
; Command1=[!WriteKeyValue Variables "#Option1#" "$UserInput$" "#SettingsFile#"][!Refresh]

; [Option2Title]
; Meter=String
; MeterStyle=Option1Title
; Text=#Option2Title#
; Y=(#WidgetPadding# + #WidgetHeight# * 0.43)
; Hidden=(#OptionsCount# < 2)

; [Option2Value]
; Meter=String
; MeterStyle=Option1Value
; Text=[#[#Option2]]
; Y=(#WidgetPadding# + #WidgetHeight# * 0.43)
; Hidden=(#OptionsCount# < 2)
; LeftMouseUpAction=[!CommandMeasure "Option2Input" "ExecuteBatch ALL"]

; [Option2Input]
; Measure=Plugin
; Plugin=InputText
; DefaultValue=[#[#Option2]]
; FontFace=#FontFace#
; FontSize=(#WidgetWidth# * 0.04)
; FontColor=#ForegroundColor#
; SolidColor=#BackgroundColor#
; X=(#WidgetPadding# + #WidgetWidth# * 0.78)
; Y=(#WidgetPadding# + #WidgetHeight# * 0.43)
; W=(#WidgetWidth# * 0.15)
; H=(#WidgetHeight# * 0.08)
; StringAlign=Center
; Command1=[!WriteKeyValue Variables "#Option2#" "$UserInput$" "#SettingsFile#"][!Refresh]

; [Option3Title]
; Meter=String
; MeterStyle=Option1Title
; Text=#Option3Title#
; Y=(#WidgetPadding# + #WidgetHeight# * 0.53)
; Hidden=(#OptionsCount# < 3)

; [Option3Value]
; Meter=String
; MeterStyle=Option1Value
; Text=[#[#Option3]]
; Y=(#WidgetPadding# + #WidgetHeight# * 0.53)
; Hidden=(#OptionsCount# < 3)
; LeftMouseUpAction=[!CommandMeasure "Option3Input" "ExecuteBatch ALL"]

; [Option3Input]
; Measure=Plugin
; Plugin=InputText
; DefaultValue=[#[#Option3]]
; FontFace=#FontFace#
; FontSize=(#WidgetWidth# * 0.04)
; FontColor=#ForegroundColor#
; SolidColor=#BackgroundColor#
; X=(#WidgetPadding# + #WidgetWidth# * 0.78)
; Y=(#WidgetPadding# + #WidgetHeight# * 0.53)
; W=(#WidgetWidth# * 0.15)
; H=(#WidgetHeight# * 0.08)
; StringAlign=Center
; Command1=[!WriteKeyValue Variables "#Option3#" "$UserInput$" "#SettingsFile#"][!Refresh]

; [Option4Title]
; Meter=String
; MeterStyle=Option1Title
; Text=#Option4Title#
; Y=(#WidgetPadding# + #WidgetHeight# * 0.63)
; Hidden=(#OptionsCount# < 4)

; [Option4Value]
; Meter=String
; MeterStyle=Option1Value
; Text=[#[#Option4]]
; Y=(#WidgetPadding# + #WidgetHeight# * 0.63)
; Hidden=(#OptionsCount# < 4)
; LeftMouseUpAction=[!CommandMeasure "Option4Input" "ExecuteBatch ALL"]

; [Option4Input]
; Measure=Plugin
; Plugin=InputText
; DefaultValue=[#[#Option4]]
; FontFace=#FontFace#
; FontSize=(#WidgetWidth# * 0.04)
; FontColor=#ForegroundColor#
; SolidColor=#BackgroundColor#
; X=(#WidgetPadding# + #WidgetWidth# * 0.78)
; Y=(#WidgetPadding# + #WidgetHeight# * 0.63)
; W=(#WidgetWidth# * 0.15)
; H=(#WidgetHeight# * 0.08)
; StringAlign=Center
; Command1=[!WriteKeyValue Variables "#Option4#" "$UserInput$" "#SettingsFile#"][!Refresh]

; [Option5Title]
; Meter=String
; MeterStyle=Option1Title
; Text=#Option5Title#
; Y=(#WidgetPadding# + #WidgetHeight# * 0.73)
; Hidden=(#OptionsCount# < 5)

; [Option5Value]
; Meter=String
; MeterStyle=Option1Value
; Text=[#[#Option5]]
; Y=(#WidgetPadding# + #WidgetHeight# * 0.73)
; Hidden=(#OptionsCount# < 5)
; LeftMouseUpAction=[!CommandMeasure "Option5Input" "ExecuteBatch ALL"]

; [Option5Input]
; Measure=Plugin
; Plugin=InputText
; DefaultValue=[#[#Option5]]
; FontFace=#FontFace#
; FontSize=(#WidgetWidth# * 0.04)
; FontColor=#ForegroundColor#
; SolidColor=#BackgroundColor#
; X=(#WidgetPadding# + #WidgetWidth# * 0.78)
; Y=(#WidgetPadding# + #WidgetHeight# * 0.73)
; W=(#WidgetWidth# * 0.15)
; H=(#WidgetHeight# * 0.08)
; StringAlign=Center
; Command1=[!WriteKeyValue Variables "#Option5#" "$UserInput$" "#SettingsFile#"][!Refresh]

; [Option6Title]
; Meter=String
; MeterStyle=Option1Title
; Text=#Option6Title#
; Y=(#WidgetPadding# + #WidgetHeight# * 0.83)
; Hidden=(#OptionsCount# < 6)

; [Option6Value]
; Meter=String
; MeterStyle=Option1Value
; Text=[#[#Option6]]
; Y=(#WidgetPadding# + #WidgetHeight# * 0.83)
; Hidden=(#OptionsCount# < 6)
; LeftMouseUpAction=[!CommandMeasure "Option6Input" "ExecuteBatch ALL"]

; [Option6Input]
; Measure=Plugin
; Plugin=InputText
; DefaultValue=[#[#Option6]]
; FontFace=#FontFace#
; FontSize=(#WidgetWidth# * 0.04)
; FontColor=#ForegroundColor#
; SolidColor=#BackgroundColor#
; StringAlign=Center
; X=(#WidgetPadding# + #WidgetWidth# * 0.78)
; Y=(#WidgetPadding# + #WidgetHeight# * 0.83)
; W=(#WidgetWidth# * 0.15)
; H=(#WidgetHeight# * 0.08)
; StringAlign=Center
; Command1=[!WriteKeyValue Variables "#Option6#" "$UserInput$" "#SettingsFile#"][!Refresh]