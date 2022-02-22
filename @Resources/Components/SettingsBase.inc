[Rainmeter]
Update=100
RightMouseUpAction=[]

[Variables]
WidgetSize=large
@include=#@#Settings.inc
@include1=#@#Languages\#Language#.inc
@include2=#@#Components\WidgetSize.inc
@include3=#@#Components\SolidBackground.inc

[IconMeter]
Meter=Image
ImageName=#Icon#
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.06)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.06)
W=([WidgetWidth] * 0.1)
H=([WidgetHeight] * 0.1)
DynamicVariables=1

[Title]
Meter=String
Text=#Title#
FontSize=([WidgetWidth] * 0.04)
FontFace=#FontFace#
FontColor=#ForegroundColor#
FontWeight=600
AntiAlias=1
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.2)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.075)
DynamicVariables=1

[SaveButton]
Meter=Shape
Shape=Rectangle (#WidgetPaddingSize# + [WidgetWidth] * 0.73),(#WidgetPaddingSize# + [WidgetHeight] * 0.075),([WidgetWidth] * 0.2),([WidgetHeight] * 0.06),4, 4 | Fill Color 255,255,255,64 | StrokeColor 0,0,0,64
LeftMouseUpAction=[!ActivateConfig "#CURRENTCONFIG#" "#ReturnTo#"]
DynamicVariables=1

[SaveText]
Meter=String
Text=#Save#
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.03)
FontColor=#ForegroundColor#
AntiAlias=1
StringAlign=Center
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.83)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.082)
LeftMouseUpAction=[!ActivateConfig "#CURRENTCONFIG#" "#ReturnTo#"]
DynamicVariables=1

[Description]
Meter=String
Text=#Description#
FontSize=([WidgetWidth] * 0.035)
FontFace=#FontFace#
FontColor=128,128,128
FontWeight=300
AntiAlias=1
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.05)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.19)
DynamicVariables=1


[HideOption1]
Measure=String
String=#Option1Title#
RegExpSubstitute=1
Substitute=".+":"0","^$":"1"

[HideOption2]
Measure=String
String=#Option2Title#
RegExpSubstitute=1
Substitute=".+":"0","^$":"1"

[HideOption3]
Measure=String
String=#Option3Title#
RegExpSubstitute=1
Substitute=".+":"0","^$":"1"

[HideOption4]
Measure=String
String=#Option4Title#
RegExpSubstitute=1
Substitute=".+":"0","^$":"1"

[HideOption5]
Measure=String
String=#Option5Title#
RegExpSubstitute=1
Substitute=".+":"0","^$":"1"

[HideOption6]
Measure=String
String=#Option6Title#
RegExpSubstitute=1
Substitute=".+":"0","^$":"1"


[Option1Title]
Meter=String
Text=#Option1Title#
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.04)
FontColor=#ForegroundColor#
FontWeight=500
AntiAlias=1
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.05)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.33)
DynamicVariables=1
Hidden=[HideOption1]

[Option1Shape]
Meter=Shape
Shape=Rectangle (#WidgetPaddingSize# + [WidgetWidth] * 0.8), (#WidgetPaddingSize# + [WidgetHeight] * 0.33), ([WidgetWidth] * 0.13), ([WidgetHeight] * 0.06), 4, 4 | Fill Color 255,255,255,64 | StrokeColor 0,0,0,64
LeftMouseUpAction=[!CommandMeasure "Option1Input" "ExecuteBatch ALL"]
DynamicVariables=1
Hidden=[HideOption1]

[Option1Value]
Meter=String
Text=[#[#Option1]]
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.035)
FontColor=#ForegroundColor#
FontWeight=300
AntiAlias=1
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.805)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.335)
DynamicVariables=1
Hidden=[HideOption1]

[Option1Input]
Measure=Plugin
Plugin=InputText
DefaultValue=[#[#Option1]]
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.04)
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.8)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.33)
W=([WidgetWidth] * 0.13)
H=([WidgetHeight] * 0.06)
Command1=[!WriteKeyValue Variables "#Option1#" "$UserInput$" "#SettingsFile#"][!Refresh]
Hidden=[HideOption1]


[Option2Title]
Meter=String
Text=#Option2Title#
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.04)
FontColor=#ForegroundColor#
FontWeight=500
AntiAlias=1
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.05)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.43)
DynamicVariables=1
Hidden=[HideOption2]

[Option2Shape]
Meter=Shape
Shape=Rectangle (#WidgetPaddingSize# + [WidgetWidth] * 0.8), (#WidgetPaddingSize# + [WidgetHeight] * 0.43), ([WidgetWidth] * 0.13), ([WidgetHeight] * 0.06), 4, 4 | Fill Color 255,255,255,64 | StrokeColor 0,0,0,64
LeftMouseUpAction=[!CommandMeasure "Option2Input" "ExecuteBatch ALL"]
DynamicVariables=1
Hidden=[HideOption2]

[Option2Value]
Meter=String
Text=[#[#Option2]]
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.035)
FontColor=#ForegroundColor#
FontWeight=300
AntiAlias=1
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.805)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.435)
DynamicVariables=1
Hidden=[HideOption2]

[Option2Input]
Measure=Plugin
Plugin=InputText
DefaultValue=[#[#Option2]]
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.04)
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.8)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.43)
W=([WidgetWidth] * 0.13)
H=([WidgetHeight] * 0.06)
Command1=[!WriteKeyValue Variables "#Option2#" "$UserInput$" "#SettingsFile#"][!Refresh]
Hidden=[HideOption2]


[Option3Title]
Meter=String
Text=#Option3Title#
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.04)
FontColor=#ForegroundColor#
FontWeight=500
AntiAlias=1
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.05)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.53)
DynamicVariables=1
Hidden=[HideOption3]

[Option3Shape]
Meter=Shape
Shape=Rectangle (#WidgetPaddingSize# + [WidgetWidth] * 0.8), (#WidgetPaddingSize# + [WidgetHeight] * 0.53), ([WidgetWidth] * 0.13), ([WidgetHeight] * 0.06), 4, 4 | Fill Color 255,255,255,64 | StrokeColor 0,0,0,64
LeftMouseUpAction=[!CommandMeasure "Option3Input" "ExecuteBatch ALL"]
DynamicVariables=1
Hidden=[HideOption3]

[Option3Value]
Meter=String
Text=[#[#Option3]]
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.035)
FontColor=#ForegroundColor#
FontWeight=300
AntiAlias=1
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.805)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.535)
DynamicVariables=1
Hidden=[HideOption3]

[Option3Input]
Measure=Plugin
Plugin=InputText
DefaultValue=[#[#Option3]]
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.04)
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.8)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.53)
W=([WidgetWidth] * 0.13)
H=([WidgetHeight] * 0.06)
Command1=[!WriteKeyValue Variables "#Option3#" "$UserInput$" "#SettingsFile#"][!Refresh]
Hidden=[HideOption3]


[Option4Title]
Meter=String
Text=#Option4Title#
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.04)
FontColor=#ForegroundColor#
FontWeight=500
AntiAlias=1
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.05)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.63)
DynamicVariables=1
Hidden=[HideOption4]

[Option4Shape]
Meter=Shape
Shape=Rectangle (#WidgetPaddingSize# + [WidgetWidth] * 0.8), (#WidgetPaddingSize# + [WidgetHeight] * 0.63), ([WidgetWidth] * 0.13), ([WidgetHeight] * 0.06), 4, 4 | Fill Color 255,255,255,64 | StrokeColor 0,0,0,64
LeftMouseUpAction=[!CommandMeasure "Option4Input" "ExecuteBatch ALL"]
DynamicVariables=1
Hidden=[HideOption4]

[Option4Value]
Meter=String
Text=[#[#Option4]]
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.035)
FontColor=#ForegroundColor#
FontWeight=300
AntiAlias=1
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.805)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.635)
DynamicVariables=1
Hidden=[HideOption4]

[Option4Input]
Measure=Plugin
Plugin=InputText
DefaultValue=[#[#Option4]]
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.04)
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.8)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.63)
W=([WidgetWidth] * 0.13)
H=([WidgetHeight] * 0.06)
Command1=[!WriteKeyValue Variables "#Option4#" "$UserInput$" "#SettingsFile#"][!Refresh]
Hidden=[HideOption4]


[Option5Title]
Meter=String
Text=#Option5Title#
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.04)
FontColor=#ForegroundColor#
FontWeight=500
AntiAlias=1
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.05)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.73)
DynamicVariables=1
Hidden=[HideOption5]

[Option5Shape]
Meter=Shape
Shape=Rectangle (#WidgetPaddingSize# + [WidgetWidth] * 0.8), (#WidgetPaddingSize# + [WidgetHeight] * 0.73), ([WidgetWidth] * 0.13), ([WidgetHeight] * 0.06), 4, 4 | Fill Color 255,255,255,64 | StrokeColor 0,0,0,64
LeftMouseUpAction=[!CommandMeasure "Option5Input" "ExecuteBatch ALL"]
DynamicVariables=1
Hidden=[HideOption5]

[Option5Value]
Meter=String
Text=[#[#Option5]]
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.035)
FontColor=#ForegroundColor#
FontWeight=300
AntiAlias=1
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.805)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.735)
DynamicVariables=1
Hidden=[HideOption5]

[Option5Input]
Measure=Plugin
Plugin=InputText
DefaultValue=[#[#Option5]]
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.04)
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.8)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.73)
W=([WidgetWidth] * 0.13)
H=([WidgetHeight] * 0.06)
Command1=[!WriteKeyValue Variables "#Option5#" "$UserInput$" "#SettingsFile#"][!Refresh]
Hidden=HideOption5


[Option6Title]
Meter=String
Text=#Option6Title#
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.04)
FontColor=#ForegroundColor#
FontWeight=500
AntiAlias=1
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.05)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.83)
DynamicVariables=1
Hidden=[HideOption6]

[Option6Shape]
Meter=Shape
Shape=Rectangle (#WidgetPaddingSize# + [WidgetWidth] * 0.8), (#WidgetPaddingSize# + [WidgetHeight] * 0.83), ([WidgetWidth] * 0.13), ([WidgetHeight] * 0.06), 4, 4 | Fill Color 255,255,255,64 | StrokeColor 0,0,0,64
LeftMouseUpAction=[!CommandMeasure "Option6Input" "ExecuteBatch ALL"]
DynamicVariables=1
Hidden=[HideOption6]

[Option6Value]
Meter=String
Text=[#[#Option6]]
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.035)
FontColor=#ForegroundColor#
FontWeight=300
AntiAlias=1
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.805)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.835)
DynamicVariables=1
Hidden=[HideOption6]

[Option6Input]
Measure=Plugin
Plugin=InputText
DefaultValue=[#[#Option6]]
FontFace=#FontFace#
FontSize=([WidgetWidth] * 0.04)
FontColor=#ForegroundColor#
SolidColor=#BackgroundColor#
X=(#WidgetPaddingSize# + [WidgetWidth] * 0.8)
Y=(#WidgetPaddingSize# + [WidgetHeight] * 0.83)
W=([WidgetWidth] * 0.13)
H=([WidgetHeight] * 0.06)
Command1=[!WriteKeyValue Variables "#Option6#" "$UserInput$" "#SettingsFile#"][!Refresh]
Hidden=[HideOption6]