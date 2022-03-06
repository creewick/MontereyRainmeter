[WeatherParser]
Measure=WebParser
URL=https://api.openweathermap.org/data/2.5/onecall?lat=#Latitude#&lon=#Longitude#&exclude=minutely&units=#WeatherUnits#&lang=#WeatherLanguage#&appid=#APIKey#
UpdateDivider=1
UpdateRate=(60*15)
RegExp=(?siU).*"timezone":".*/(.*)".*"timezone_offset":(.*),.*"current".*"temp":(.*),.*"description":"(.*)".*"icon":"(.*([d|n]))".*"hourly".*"dt":(.*),.*"temp":(.*),.*"icon":"(.*)".*"dt":(.*),.*"temp":(.*),.*"icon":"(.*)".*"dt":(.*),.*"temp":(.*),.*"icon":"(.*)".*"dt":(.*),.*"temp":(.*),.*"icon":"(.*)".*"dt":(.*),.*"temp":(.*),.*"icon":"(.*)".*"dt":(.*),.*"temp":(.*),.*"icon":"(.*)".*"daily".*"dt":(.*),.*"min":(.*),.*"max":(.*),.*"icon":"(.*)".*"dt":(.*),.*"min":(.*),.*"max":(.*),.*"icon":"(.*)".*"dt":(.*),.*"min":(.*),.*"max":(.*),.*"icon":"(.*)".*"dt":(.*),.*"min":(.*),.*"max":(.*),.*"icon":"(.*)".*"dt":(.*),.*"min":(.*),.*"max":(.*),.*"icon":"(.*)".*"dt":(.*),.*"min":(.*),.*"max":(.*),.*"icon":"(.*)".*"dt":(.*),.*"min":(.*),.*"max":(.*),.*"icon":"(.*)".*
FinishAction=[!UpdateMeasureGroup Measures][!UpdateMeterGroup Meters][!Redraw]

[Timezone]
Measure=WebParser
URL=[WeatherParser]
StringIndex=1

[TimezoneOffset]
Measure=WebParser
URL=[WeatherParser]
StringIndex=2

[CurrentTempValue]
Measure=WebParser
URL=[WeatherParser]
StringIndex=3

[CurrentTemp]
Measure=Calc
Group=Measures
Formula=Round([CurrentTempValue],0)
DynamicVariables=1

[CurrentDescription]
Measure=WebParser
URL=[WeatherParser]
StringIndex=4

[CurrentIcon]
Measure=WebParser
URL=[WeatherParser]
StringIndex=5

[DarkMode]
Measure=WebParser
URL=[WeatherParser]
StringIndex=6
Substitute="d":"3694d8","n":"232640","":"3694d8"
OnUpdateAction=[!SetVariable BackgroundColor [DarkMode]][!SetVariable ForegroundColor "ffffff"]
Disabled=#Colored#

[HourlyTimeValue1]
Measure=WebParser
Url=[WeatherParser]
StringIndex=7

[HourlyTime1]
Measure=Time
Group=Measures
TimeStamp=([HourlyTimeValue1]+[TimezoneOffset])
DynamicVariables=1
Format=%H

[HourlyTempValue1]
Measure=WebParser
URL=[WeatherParser]
StringIndex=8

[HourlyTemp1]
Measure=Calc
Group=Measures
Formula=Round([HourlyTempValue1],0)
DynamicVariables=1

[HourlyIcon1]
Measure=WebParser
URL=[WeatherParser]
StringIndex=9

[HourlyTimeValue2]
Measure=WebParser
Url=[WeatherParser]
StringIndex=10

[HourlyTime2]
Measure=Time
Group=Measures
TimeStamp=([HourlyTimeValue2]+[TimezoneOffset])
DynamicVariables=1
Format=%H

[HourlyTempValue2]
Measure=WebParser
URL=[WeatherParser]
StringIndex=11

[HourlyTemp2]
Measure=Calc
Group=Measures
Formula=Round([HourlyTempValue2],0)
DynamicVariables=1

[HourlyIcon2]
Measure=WebParser
URL=[WeatherParser]
StringIndex=12

[HourlyTimeValue3]
Measure=WebParser
Url=[WeatherParser]
StringIndex=13

[HourlyTime3]
Measure=Time
Group=Measures
TimeStamp=([HourlyTimeValue3]+[TimezoneOffset])
DynamicVariables=1
Format=%H

[HourlyTempValue3]
Measure=WebParser
URL=[WeatherParser]
StringIndex=14

[HourlyTemp3]
Measure=Calc
Group=Measures
Formula=Round([HourlyTempValue3],0)
DynamicVariables=1

[HourlyIcon3]
Measure=WebParser
URL=[WeatherParser]
StringIndex=15

[HourlyTimeValue4]
Measure=WebParser
Url=[WeatherParser]
StringIndex=16

[HourlyTime4]
Measure=Time
Group=Measures
TimeStamp=([HourlyTimeValue4]+[TimezoneOffset])
DynamicVariables=1
Format=%H

[HourlyTempValue4]
Measure=WebParser
URL=[WeatherParser]
StringIndex=17

[HourlyTemp4]
Measure=Calc
Group=Measures
Formula=Round([HourlyTempValue4],0)
DynamicVariables=1

[HourlyIcon4]
Measure=WebParser
URL=[WeatherParser]
StringIndex=18

[HourlyTimeValue5]
Measure=WebParser
Url=[WeatherParser]
StringIndex=19

[HourlyTime5]
Measure=Time
Group=Measures
TimeStamp=([HourlyTimeValue5]+[TimezoneOffset])
DynamicVariables=1
Format=%H

[HourlyTempValue5]
Measure=WebParser
URL=[WeatherParser]
StringIndex=20

[HourlyTemp5]
Measure=Calc
Group=Measures
Formula=Round([HourlyTempValue5],0)
DynamicVariables=1

[HourlyIcon5]
Measure=WebParser
URL=[WeatherParser]
StringIndex=21

[HourlyTimeValue6]
Measure=WebParser
Url=[WeatherParser]
StringIndex=22

[HourlyTime6]
Measure=Time
Group=Measures
TimeStamp=([HourlyTimeValue6]+[TimezoneOffset])
DynamicVariables=1
Format=%H

[HourlyTempValue6]
Measure=WebParser
URL=[WeatherParser]
StringIndex=23

[HourlyTemp6]
Measure=Calc
Group=Measures
Formula=Round([HourlyTempValue6],0)
DynamicVariables=1

[HourlyIcon6]
Measure=WebParser
URL=[WeatherParser]
StringIndex=24

[DailyTimeValue1]
Measure=WebParser
Url=[WeatherParser]
StringIndex=25

[DailyTime1]
Measure=Time
Group=Measures
TimeStamp=([DailyTimeValue1] + 11644473600)
FormatLocale=Local
DynamicVariables=1
Format=%a

[DailyLowValue1]
Measure=WebParser
Url=[WeatherParser]
StringIndex=26

[DailyLow1]
Measure=Calc
Group=Measures
Formula=Round([DailyLowValue1],0)
DynamicVariables=1

[DailyHighValue1]
Measure=WebParser
Url=[WeatherParser]
StringIndex=27

[DailyHigh1]
Measure=Calc
Group=Measures
Formula=Round([DailyHighValue1],0)
DynamicVariables=1

[DailyIcon1]
Measure=WebParser
Url=[WeatherParser]
StringIndex=28

[DailyTimeValue2]
Measure=WebParser
Url=[WeatherParser]
StringIndex=29

[DailyTime2]
Measure=Time
Group=Measures
TimeStamp=([DailyTimeValue2] + 11644473600)
FormatLocale=Local
DynamicVariables=1
Format=%a

[DailyLowValue2]
Measure=WebParser
Url=[WeatherParser]
StringIndex=30

[DailyLow2]
Measure=Calc
Group=Measures
Formula=Round([DailyLowValue2],0)
DynamicVariables=1

[DailyHighValue2]
Measure=WebParser
Url=[WeatherParser]
StringIndex=31

[DailyHigh2]
Measure=Calc
Group=Measures
Formula=Round([DailyHighValue2],0)
DynamicVariables=1

[DailyIcon2]
Measure=WebParser
Url=[WeatherParser]
StringIndex=32

[DailyTimeValue3]
Measure=WebParser
Url=[WeatherParser]
StringIndex=33

[DailyTime3]
Measure=Time
Group=Measures
TimeStamp=([DailyTimeValue3] + 11644473600)
FormatLocale=Local
DynamicVariables=1
Format=%a

[DailyLowValue3]
Measure=WebParser
Url=[WeatherParser]
StringIndex=34

[DailyLow3]
Measure=Calc
Group=Measures
Formula=Round([DailyLowValue3],0)
DynamicVariables=1

[DailyHighValue3]
Measure=WebParser
Url=[WeatherParser]
StringIndex=35

[DailyHigh3]
Measure=Calc
Group=Measures
Formula=Round([DailyHighValue3],0)
DynamicVariables=1

[DailyIcon3]
Measure=WebParser
Url=[WeatherParser]
StringIndex=36

[DailyTimeValue4]
Measure=WebParser
Url=[WeatherParser]
StringIndex=37

[DailyTime4]
Measure=Time
Group=Measures
TimeStamp=([DailyTimeValue4] + 11644473600)
FormatLocale=Local
DynamicVariables=1
Format=%a

[DailyLowValue4]
Measure=WebParser
Url=[WeatherParser]
StringIndex=38

[DailyLow4]
Measure=Calc
Group=Measures
Formula=Round([DailyLowValue4],0)
DynamicVariables=1

[DailyHighValue4]
Measure=WebParser
Url=[WeatherParser]
StringIndex=39

[DailyHigh4]
Measure=Calc
Group=Measures
Formula=Round([DailyHighValue4],0)
DynamicVariables=1

[DailyIcon4]
Measure=WebParser
Url=[WeatherParser]
StringIndex=40

[DailyTimeValue5]
Measure=WebParser
Url=[WeatherParser]
StringIndex=41

[DailyTime5]
Measure=Time
Group=Measures
TimeStamp=([DailyTimeValue5] + 11644473600)
FormatLocale=Local
DynamicVariables=1
Format=%a

[DailyLowValue5]
Measure=WebParser
Url=[WeatherParser]
StringIndex=42

[DailyLow5]
Measure=Calc
Group=Measures
Formula=Round([DailyLowValue5],0)
DynamicVariables=1

[DailyHighValue5]
Measure=WebParser
Url=[WeatherParser]
StringIndex=43

[DailyHigh5]
Measure=Calc
Group=Measures
Formula=Round([DailyHighValue5],0)
DynamicVariables=1

[DailyIcon5]
Measure=WebParser
Url=[WeatherParser]
StringIndex=44

[DailyTimeValue6]
Measure=WebParser
Url=[WeatherParser]
StringIndex=45

[DailyTime6]
Measure=Time
Group=Measures
TimeStamp=([DailyTimeValue6] + 11644473600)
FormatLocale=Local
DynamicVariables=1
Format=%a

[DailyLowValue6]
Measure=WebParser
Url=[WeatherParser]
StringIndex=46

[DailyLow6]
Measure=Calc
Group=Measures
Formula=Round([DailyLowValue6],0)
DynamicVariables=1

[DailyHighValue6]
Measure=WebParser
Url=[WeatherParser]
StringIndex=47

[DailyHigh6]
Measure=Calc
Group=Measures
Formula=Round([DailyHighValue6],0)
DynamicVariables=1

[DailyIcon6]
Measure=WebParser
Url=[WeatherParser]
StringIndex=48

[DailyTimeValue7]
Measure=WebParser
Url=[WeatherParser]
StringIndex=49

[DailyTime7]
Measure=Time
Group=Measures
TimeStamp=([DailyTimeValue7] + 11644473600)
FormatLocale=Local
DynamicVariables=1
Format=%a

[DailyLowValue7]
Measure=WebParser
Url=[WeatherParser]
StringIndex=50

[DailyLow7]
Measure=Calc
Group=Measures
Formula=Round([DailyLowValue7],0)
DynamicVariables=1

[DailyHighValue7]
Measure=WebParser
Url=[WeatherParser]
StringIndex=51

[DailyHigh7]
Measure=Calc
Group=Measures
Formula=Round([DailyHighValue7],0)
DynamicVariables=1

[DailyIcon7]
Measure=WebParser
Url=[WeatherParser]
StringIndex=52

[DailyMin]
Measure=Calc
Group=Measures
Formula=Min(Min(Min(Min(Min([DailyLowValue1],[DailyLowValue2]),[DailyLowValue3]),[DailyLowValue4]),[DailyLowValue5]),[DailyLowValue6])
DynamicVariables=1

[DailyMax]
Measure=Calc
Group=Measures
Formula=Max(Max(Max(Max(Max([DailyHighValue1],[DailyHighValue2]),[DailyHighValue3]),[DailyHighValue4]),[DailyHighValue5]),[DailyHighValue6])
DynamicVariables=1

[MeterStep]
Measure=Calc
Group=Measures
Formula=(#WidgetWidth# * 0.36 / ([DailyMax] - [DailyMin]))
DynamicVariables=1
