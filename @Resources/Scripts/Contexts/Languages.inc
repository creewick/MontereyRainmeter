[Variables]
LanguagesContextTitle=#ru#
LanguagesContextAction=[!WriteKeyValue Variables "Language" "ru" "#@#Variables\Global.inc"][!RefreshGroup Monterey]
LanguagesContextTitle2=#ua#
LanguagesContextAction2=[!WriteKeyValue Variables "Language" "ua" "#@#Variables\Global.inc"][!RefreshGroup Monterey]
LanguagesContextTitle3=#en#
LanguagesContextAction3=[!WriteKeyValue Variables "Language" "en" "#@#Variables\Global.inc"][!RefreshGroup Monterey]
LanguagesContextTitle4=#de#
LanguagesContextAction4=[!WriteKeyValue Variables "Language" "de" "#@#Variables\Global.inc"][!RefreshGroup Monterey]
LanguagesContextTitle5=

[SetLanguageTickMark]
Measure=String
String=#Language#
DynamicVariables=1
IfMatch=ru
IfMatchAction=[!SetVariable LanguagesContextTitle "#ru#  [\x2714]"]
IfMatch2=ua
IfMatchAction2=[!SetVariable LanguagesContextTitle2 "#ua#  [\x2714]"]
IfMatch3=en
IfMatchAction3=[!SetVariable LanguagesContextTitle3 "#en#  [\x2714]"]
IfMatch4=de
IfMatchAction3=[!SetVariable LanguagesContextTitle4 "#de#  [\x2714]"]
