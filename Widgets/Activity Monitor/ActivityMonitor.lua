function Update()
    for i = 1, 4 do
        UpdateColor(i)
    end
end

function UpdateColor(index)
    local meter = SKIN:GetVariable('Meter'..index)
    local value = SKIN:GetMeasure(meter..'Measure'):GetValue()
    local yellowStarts = tonumber(SKIN:GetVariable('YellowStarts'))
    local redStarts = tonumber(SKIN:GetVariable('RedStarts'))
    local greenColor = SKIN:GetVariable('GreenColor')
    local yellowColor = SKIN:GetVariable('YellowColor')
    local redColor = SKIN:GetVariable('RedColor')

    if (value < yellowStarts) then 
        SKIN:Bang('!SetOption', 'Meter'..index..'Meter', 'LineColor', greenColor)
    elseif (value < redStarts) then
        SKIN:Bang('!SetOption', 'Meter'..index..'Meter', 'LineColor', yellowColor)
    else 
        SKIN:Bang('!SetOption', 'Meter'..index..'Meter', 'LineColor', redColor)
    end
end

function Draw(index, x, y, size, text)
    local meter = SKIN:GetVariable('Meter'..index)
    local padding = tonumber(SKIN:GetVariable('WidgetPaddingSize'))
    local widgetHeight = tonumber(SKIN:GetMeasure('WidgetHeight'):GetStringValue())
    local widgetWidth = tonumber(SKIN:GetMeasure('WidgetWidth'):GetStringValue())
    local widgetSize = math.min(widgetHeight, widgetWidth)

    DrawOuterCircle(index, padding, widgetSize, x, y, size)
    DrawMeter(index, meter, padding, widgetSize, x, y, size)
    DrawInnerCircle(index, padding, widgetSize, x, y, size)
    DrawImage(index, meter, padding, widgetSize, x, y, size)
    if text ~= nil then DrawText(index, meter, padding, widgetSize, x, y, size) end
    return 0
end

function DrawOuterCircle(index, padding, widgetSize, _x, _y, size)
    local name = string.format('Meter%sOuterCircle', index)
    local x = padding + widgetSize * _x
    local y = padding + widgetSize * _y
    local w = widgetSize * size
    local form = string.format('Ellipse %d, %d, %d, %d', x, y, w, w)
    local color = 'Fill Color 128, 128, 128, 128'
    local stroke = 'StrokeWidth 0'
    local shape = string.format('%s | %s | %s', form, color, stroke)


    SKIN:Bang('!SetOption', name, 'Shape', shape)
end 

function DrawMeter(index, meter, padding, widgetSize, _x, _y, size)
    local name = string.format('Meter%sMeter', index)
    local measureName = string.format('%sMeasure', meter)
    local x = padding + widgetSize * _x
    local y = padding + widgetSize * _y
    local length = widgetSize * size

    SKIN:Bang('!SetOption', name, 'MeasureName', measureName)
    SKIN:Bang('!SetOption', name, 'X', x)
    SKIN:Bang('!SetOption', name, 'Y', y)
    SKIN:Bang('!SetOption', name, 'StartAngle', '(-PI/2)')
    SKIN:Bang('!SetOption', name, 'LineLength', length)
    SKIN:Bang('!SetOption', name, 'AntiAlias', 1)
    SKIN:Bang('!SetOption', name, 'Solid', 1)
end

function DrawInnerCircle(index, padding, widgetSize, _x, _y, size)
    local name = string.format('Meter%sInnerCircle', index)
    local x = padding + widgetSize * _x
    local y = padding + widgetSize * _y
    local w = widgetSize * size - 5
    local form = string.format('Ellipse %d, %d, %d, %d', x, y, w, w)
    local color = 'Fill Color [BackgroundColor]'
    local stroke = 'StrokeWidth 0'
    local shape = string.format('%s | %s | %s', form, color, stroke)
    
    SKIN:Bang('!SetOption', name, 'Shape', shape)
end 

function DrawImage(index, meter, padding, widgetSize, _x, _y, size)
    local name = string.format('Meter%sImage', index)
    local darkMode = SKIN:GetMeasure('DarkMode'):GetValue() > 0.5 and 0 or 1
    local image = string.format('#@#Images\\Widgets\\System Monitor\\%s-%s.png', meter, darkMode)
    local w = widgetSize * (size - 0.03)
    local x = padding + widgetSize * _x - w / 2
    local y = padding + widgetSize * _y - w / 2
    
    SKIN:Bang('!SetOption', name, 'ImageName', image)
    SKIN:Bang('!SetOption', name, 'X', x)
    SKIN:Bang('!SetOption', name, 'Y', y)
    SKIN:Bang('!SetOption', name, 'W', w)
    SKIN:Bang('!SetOption', name, 'H', w)
end 

function DrawText(index, meter, padding, widgetSize, _x, _y, size)
    local name = string.format('Meter%sText', index)
    local measure = string.format('%sMeasure', meter)
    local x = padding + widgetSize * _x
    local y = padding + widgetSize * (_y + 2.2 * size)
    local fontSize = widgetSize * 0.09
    local fontColor = SKIN:GetMeasure('DarkMode'):GetValue() > 0.5 and SKIN:GetVariable('DarkForeground') or SKIN:GetVariable('LightForeground')

    SKIN:Bang('!SetOption', name, 'MeasureName', measure)
    SKIN:Bang('!SetOption', name, 'Text', '%1 %')
    SKIN:Bang('!SetOption', name, 'X', x)
    SKIN:Bang('!SetOption', name, 'Y', y)
    SKIN:Bang('!SetOption', name, 'FontColor', fontColor)
    SKIN:Bang('!SetOption', name, 'FontSize', fontSize)
    SKIN:Bang('!SetOption', name, 'StringAlign', 'CenterCenter')
    SKIN:Bang('!SetOption', name, 'AntiAlias', 1)
end