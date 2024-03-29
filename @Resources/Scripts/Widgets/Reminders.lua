function Initialize()
    SKIN:Bang('!SetVariable', 'ItemsCount', getRemindersCount())
    return 0
end

function getRemindersCount()
    local count = 0
    local value = SKIN:GetVariable('Item1', '')

    while (value ~= '')
    do
        count = count + 1
        value = SKIN:GetVariable('Item'..(count+1), '')
    end

    return count
end

function addReminder()
    local count = getRemindersCount()
    local text = SKIN:ReplaceVariables('#InputValue#')
    SKIN:Bang('!WriteKeyValue', 'Variables', 'Item'..(count+1), text, '#@#Variables/Reminders.inc')
    SKIN:Bang('!SetVariable', 'Item'..(count+1), text)
    SKIN:Bang('!SetVariable', 'ItemsCount', count+1)
    SKIN:Bang('!UpdateMeterGroup', 'Meters')
    SKIN:Bang('!Redraw')
    return ''
end

function removeReminder(index)
    local count = getRemindersCount()

    for i = index, count do
        local nextText =  SKIN:ReplaceVariables('#Item'..(i+1)..'#')
        if i < count then
            SKIN:Bang('!WriteKeyValue', 'Variables', 'Item'..i, nextText, '#@#Variables/Reminders.inc')
            SKIN:Bang('!SetVariable', 'Item'..i, nextText)
        else
            SKIN:Bang('!WriteKeyValue', 'Variables', 'Item'..i, '', '#@#Variables/Reminders.inc')
            SKIN:Bang('!SetVariable', 'Item'..i, '')
        end
    end
    SKIN:Bang('!SetVariable', 'ItemsCount', count-1)
    SKIN:Bang('!UpdateMeterGroup', 'Meters')
    SKIN:Bang('!Redraw')
    return ''
end

function editReminder(i)
    local text = SKIN:ReplaceVariables('#InputValue#')
    if (text == '' or text == nil) then removeReminder(i)
    else 
        SKIN:Bang('!WriteKeyValue', 'Variables', 'Item'..i, text, '#@#Variables/Reminders.inc')
        SKIN:Bang('!SetVariable', 'Item'..i, text)
        SKIN:Bang('!UpdateMeterGroup', 'Meters')
        SKIN:Bang('!Redraw')
    end
    return ''
end

function editListName()
    local text = SKIN:ReplaceVariables('#InputValue#')
    if (text ~= '' and text ~= nil) then
        SKIN:Bang('!WriteKeyValue', 'Variables', 'ListName', text, '#@#Variables/Reminders.inc')
        SKIN:Bang('!SetVariable', 'ListName', text)
        SKIN:Bang('!UpdateMeterGroup', 'Meters')
        SKIN:Bang('!Redraw')
    end
    return ''
end