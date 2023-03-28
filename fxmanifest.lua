fx_version 'bodacious'
game 'gta5'

file 'Client/bin/Release/**/*.dll'
resource_type 'gametype' { name = 'MVRP' }

client_script 'Client/bin/Release/**/*.net.dll'
server_script 'Server/bin/Release/**/*.net.dll'

--
-- NUI
--

ui_page 'Client/Interface/NUI/nui.html'

files{
	'Client/Interface/NUI/nui.html',
	'Client/Interface/NUI/script.js',
	'Client/Interface/NUI/style.css',
	'Client/Interface/NUI/Images/*',
	'Client/Interface/NUI/bootstrap/css/*',
	'Client/Interface/NUI/bootstrap/js/*'

}

author 'MV001'
version '1.0.0'
description 'MV001 Resource C#'