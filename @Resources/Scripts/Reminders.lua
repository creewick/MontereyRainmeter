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

function addReminder(text)
    local count = getRemindersCount()
    SKIN:Bang('!WriteKeyValue', 'Variables', 'Item'..(count+1), text, '#@#Variables/Reminders.inc')

    return 0
end

function removeReminder(index)
    local count = getRemindersCount()

    for i = index, count do
        local nextText = SKIN:GetVariable('Item'..(i+1), '')
        SKIN:Bang('!WriteKeyValue', 'Variables', 'Item'..i, nextText, '#@#Variables/Reminders.inc')
    end
    return 0
end

function editReminder(i, text)
    if (text == '' or text == nil)
        then removeReminder(i)
        else SKIN:Bang('!WriteKeyValue', 'Variables', 'Item'..i, text, '#@#Variables/Reminders.inc')
    end
    return 0
end


function editListName(text)
    if (text ~= '' and text ~= nil) then
        SKIN:Bang('!WriteKeyValue', 'Variables', 'ListName', text, '#@#Variables/Reminders.inc')
    end
    return 0
end