#Parameters
$TotalOfRenderings = 1
$RenderingId = "{1EF2E82A-AAB7-44CD-B20F-0E8A28D72793}"

#Constants
$PageItemName = "page-with-" + $TotalOfRenderings + "-view-renderings"
$PageTemplateId = "{0D16221B-87BE-47D0-91EA-6293F8FBF2A4}"
$ContentTemplateId = "{CC9C9D8B-E6B4-4A9D-9AA5-5A06C7822681}"
$FolderTemplateId = "{A87A00B1-E6DB-45AB-8B54-636FEC3B5523}"
$BaseContentItemId = "{B146FAA9-872E-45C6-B140-101720FB6B4D}"
$ContentFolderItemPath = ("master:\content\data\" + $PageItemName)

#Gets
$Device = Get-LayoutDevice -Default
$Rendering = Get-Item $RenderingId

#Create Items
$NewPage = New-Item -Path "master:\content\home" -Name $PageItemName -ItemType $PageTemplateId
$NewContentFolder = New-Item -Path "master:\content\data" -Name $PageItemName -ItemType $FolderTemplateId
For ($i=1; $i -le $TotalOfRenderings; $i++) {
    Copy-Item -Path $BaseContentItemId -Destination ($ContentFolderItemPath + "\" + $i)
	$NewContent = Get-Item ($ContentFolderItemPath + "\" + $i)
	Add-Rendering -Item $NewPage -Device $Device -Instance (New-Rendering -Item $Rendering) -Placeholder main -DataSource $NewContent.FullPath
}