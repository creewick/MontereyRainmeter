function Initialize()
    for i = 1, 100 do 
        local item = SELF:GetOption('Item'..i)
        if (item == '') then break end
        if (item == 'Widgets')
            then drawTitle(item, i)
            else drawItem(item, i) 
        end
    end
end

function drawItem(item, i)
    local labelMeter = 'SidebarLabel'..i
    local iconMeter = 'SidebarIcon'..i
    local padding = SKIN:GetVariable('WidgetPaddingSize')

    SKIN:Bang('!SetOption', labelMeter, 'Text', SKIN:GetVariable(item))
    SKIN:Bang('!SetOption', labelMeter, 'FontFace', SKIN:GetVariable('FontFace'))
    SKIN:Bang('!SetOption', labelMeter, 'FontColor', 'ffffff')
    SKIN:Bang('!SetOption', labelMeter, 'FontSize', 11)
    SKIN:Bang('!SetOption', labelMeter, 'AntiAlias', 1)
    SKIN:Bang('!SetOption', labelMeter, 'X', padding + 40)
    SKIN:Bang('!SetOption', labelMeter, 'Y', padding + 20 + 30 * i)

    SKIN:Bang('!SetOption', iconMeter, 'ImageName', '#@#Images\\Icons\\'..item..'.png')
    SKIN:Bang('!SetOption', iconMeter, 'X', padding + 18)
    SKIN:Bang('!SetOption', iconMeter, 'Y', padding + 22 + 30 * i)
    SKIN:Bang('!SetOption', iconMeter, 'W', 14)

    if (item == 'Welcome' or item == 'Settings' or item == 'About') then
        SKIN:Bang('!SetOption', iconMeter, 'ImageTint', 'ffffff')
    end
end

function drawTitle(item, i)
    local labelMeter = 'SidebarLabel'..i
    local padding = SKIN:GetVariable('WidgetPaddingSize')

    SKIN:Bang('!SetOption', labelMeter, 'Text', SKIN:GetVariable(item))
    SKIN:Bang('!SetOption', labelMeter, 'FontFace', SKIN:GetVariable('FontFace'))
    SKIN:Bang('!SetOption', labelMeter, 'FontColor', '666666')
    SKIN:Bang('!SetOption', labelMeter, 'FontSize', 8)
    SKIN:Bang('!SetOption', labelMeter, 'StringCase', 'Upper')
    SKIN:Bang('!SetOption', labelMeter, 'FontWeight', 800)
    SKIN:Bang('!SetOption', labelMeter, 'AntiAlias', 1)
    SKIN:Bang('!SetOption', labelMeter, 'X', padding + 12)
    SKIN:Bang('!SetOption', labelMeter, 'Y', padding + 20 + 30 * i)

end