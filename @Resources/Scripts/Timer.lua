function start()
    local now = SKIN:GetMeasure('TrueNow'):GetValue()

    setAndSave('StartTime', now)

    local duration = SKIN:GetVariable('VisibleTime', 0)
    local endTime = now + duration

    setAndSave('EndTime', endTime)

    SKIN:Bang('!SetOption', 'Now', 'AverageSize', 10)

    update()
    return 0
end

function pause()
    local now = SKIN:GetMeasure('TrueNow'):GetValue()
    
    setAndSave('PauseTime', now)

    SKIN:Bang('!SetOption', 'Now', 'AverageSize', 1)

    update()
    return 0
end

function continue()
    local now = SKIN:GetMeasure('TrueNow'):GetValue()
    local pauseTime = SKIN:GetVariable('PauseTime', 0)
    local startTime = SKIN:GetVariable('StartTime', 0)
    local endTime = SKIN:GetVariable('EndTime', 0)
 
    local newStartTime = now - pauseTime + startTime
    setAndSave('StartTime', newStartTime)

    local newEndTime = now - pauseTime + endTime
    setAndSave('EndTime', newEndTime)
    setAndSave('PauseTime', -1)

    SKIN:Bang('!SetOption', 'Now', 'AverageSize', 10)

    update()
    return 0
end

function stop()
    SKIN:Bang('PlayStop')
    setAndSave('StartTime', -1)
    setAndSave('EndTime', -1)
    setAndSave('PauseTime', -1)
    
    SKIN:Bang('!Refresh')
    return 0
end

function increase(type, value)
    if (type == 'h') then value = value * 60 * 60 end
    if (type == 'm') then value = value * 60 end

    local time = SKIN:GetVariable('VisibleTime')
    SKIN:Bang('!SetVariable', 'VisibleTime', math.min(math.max(time + value, 0), 24 * 60 * 60 - 1))
    return 0
end

function input(type, value)
    local time = SKIN:GetVariable('VisibleTime')
    local seconds = time % 60
    local minutes = ((time - seconds) / 60) % 60
    local hours = (time - seconds - minutes * 60) / (60 * 60)

    if (type == 'h') then 
        time = time + (value - hours) * 60 * 60
    end
    if (type == 'm') then 
        time = time + (value - minutes) * 60
    end
    if (type == 's') then
        time = time + (value - seconds)
    end

    SKIN:Bang('!SetVariable', 'VisibleTime', math.min(math.max(time, 0), 24 * 60 * 60 - 1))
    return 0
end


function setAndSave(variable, value)
    SKIN:Bang('!WriteKeyValue', 'Variables', variable, value, '#@#Variables/Timer.inc')
    SKIN:Bang('!SetVariable', variable, value)
end

function update()
    SKIN:Bang('!UpdateMeasureGroup', 'Measures')
    SKIN:Bang('!UpdateMeterGroup', 'Meters')
end