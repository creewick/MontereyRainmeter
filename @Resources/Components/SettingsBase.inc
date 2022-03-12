[Variables]
WidgetSize=large
@include1=#@#Components\WidgetBase.inc

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
DynamicVariables=1
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
DynamicVariables=1
AntiAlias=1
StringAlign=Right
X=(#WidgetPadding# + #WidgetWidth# * 0.92)
Y=(#WidgetPadding# + #WidgetHeight# * 0.08)
LeftMouseUpAction=[!ActivateConfig "#CURRENTCONFIG#" "#ReturnTo#"]
SolidColor=#GrayColor#
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