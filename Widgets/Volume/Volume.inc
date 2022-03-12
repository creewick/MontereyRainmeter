[VolumeMeasure]
Measure=Plugin
Plugin=Win7AudioPlugin
OnChangeAction=[!UpdateMeasure VolumeLevel][!UpdateMeterGroup Meters][!Redraw]
UpdateDivider=1

[VolumeLevel]
Measure=Calc
Formula=Min(Floor(VolumeMeasure/33),2)



; [AppVolume]
; Measure=Plugin
; Plugin=AppVolume
; IgnoreSystemSound=1

; [AppVolumeTotal]
; Measure=Plugin
; Plugin=AppVolume
; Parent=AppVolume
; Index = 1
