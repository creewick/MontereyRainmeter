function Draw()
    Padding = tonumber(SKIN:GetVariable('WidgetPaddingSize'))
    Labels = split(SKIN:GetVariable('WeekdaysShort'), ',')
    SundayWeek = tonumber(SKIN:GetVariable('SundayWeek'))
    FontFace = SKIN:GetVariable('FontFace')
    Size = tonumber(SKIN:GetMeasure('WidgetHeight'):GetStringValue())
    OffsetX = SELF:GetNumberOption('OffsetX', 0)
    FontSize = Size * 0.05
    initWeekdayLabels()
    initDaysLabels()
    return 0
end

function split(input, sep)
    local result = {}
    for str in string.gmatch(input, "([^"..sep.."]+)") do
        table.insert(result, str)
    end
    return result
end

function initWeekdayLabels()
    for a = 1, 7 do 
        SKIN:Bang('!SetOption', 'Label' .. a, 'Text', Labels[(a - SundayWeek) % 7 + 1])
        SKIN:Bang('!SetOption', 'Label' .. a, 'FontSize', FontSize) 
        SKIN:Bang('!SetOption', 'Label' .. a, 'FontFace', FontFace)
        SKIN:Bang('!SetOption', 'Label' .. a, 'FontColor', getTextColor((a - SundayWeek) % 7, false))
        SKIN:Bang('!SetOption', 'Label' .. a, 'StringAlign', 'CenterCenter')
        SKIN:Bang('!SetOption', 'Label' .. a, 'FontWeight', '400')
        SKIN:Bang('!SetOption', 'Label' .. a, 'AntiAlias', '1')
        SKIN:Bang('!SetOption', 'Label' .. a, 'X',
            string.format('(%d + %s + %s * %d / 8)', OffsetX, Padding, Size, a))
        SKIN:Bang('!SetOption', 'Label' .. a, 'Y', 
            string.format('(%s + %s / 4)', Padding, Size))
    end
end

function initDaysLabels()
    local d = tonumber(os.date('%d'))
    local mm = tonumber(os.date('%m'))
    local yy = tonumber(os.date('%Y'))
    local daysInMonth = getDaysInMonth(mm, yy)
    local weeks = getWeekCount(daysInMonth, mm, yy)
    local currentWeek = 1

    for dd = 1, daysInMonth do
        local weekday = tonumber(os.date('%w', os.time({ year=yy, month=mm, day=dd })))

        local x = OffsetX + Padding + Size * ((weekday - 1 + SundayWeek) % 7 + 1) / 8
        local y = Padding + Size / 4 + currentWeek * Size / (1.6 * weeks)

        if (dd == d) then initRedCircle(x, y) end

        SKIN:Bang('!SetOption', 'Day' .. dd, 'Text', dd)
        SKIN:Bang('!SetOption', 'Day' .. dd, 'FontSize', FontSize) 
        SKIN:Bang('!SetOption', 'Day' .. dd, 'FontFace', FontFace)
        SKIN:Bang('!SetOption', 'Day' .. dd, 'FontColor', getTextColor(weekday, dd == d))
        SKIN:Bang('!SetOption', 'Day' .. dd, 'StringAlign', 'CenterCenter')
        SKIN:Bang('!SetOption', 'Day' .. dd, 'FontWeight', '400')
        SKIN:Bang('!SetOption', 'Day' .. dd, 'AntiAlias', '1')
        SKIN:Bang('!SetOption', 'Day' .. dd, 'X', x)
        SKIN:Bang('!SetOption', 'Day' .. dd, 'Y', y)
        if isLastWeekDay(weekday) then 
            currentWeek = currentWeek + 1 
        end
    end
end

function initRedCircle(x, y)
    size = math.ceil(Size * 0.06)

    SKIN:Bang('!SetOption', 'RedCircle', 'Shape', 
        string.format('Ellipse %d,%d,%d,%d | Fill Color 240,60,60 | StrokeWidth 0', x, y, size, size))
end

function isWeekend(weekday)
    return weekday == 0 or weekday == 6
end

function isLastWeekDay(weekday)
    return (weekday == 6 and SundayWeek == 1) or (weekday == 0 and SundayWeek == 0)
end

function getDaysInMonth(month, year)
    local daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}

    return (month == 2 and isLeapYear(year)) and 29 or daysInMonth[month]
end

function isLeapYear(year)
    return year % 4 == 0 or (year % 100 ~= 0 and year % 400 == 0) 
end

function getTextColor(weekday, today)
    if today then return 'ffffff' end
    local opacity = (isWeekend(weekday)) and '80' or 'ff'
    local colorVar = SKIN:GetVariable('DarkMode') == '1' and 'LightForeground' or 'DarkForeground'
    local color = SKIN:GetVariable(colorVar)

    return string.format('%s%s', color, opacity)
end

function getWeekCount(daysInMonth, mm, yy)
    local weekday = tonumber(os.date('%w', os.time({ year=yy, month=mm, day=1 })))
    local daysInPrevMonth = (weekday + 6 + SundayWeek) % 7
    local totalDays = daysInMonth + daysInPrevMonth    

    return math.ceil(totalDays / 7)
end