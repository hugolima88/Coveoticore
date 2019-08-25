#Parameters
$TotalItems = 22
$MaxItemsPerFolder = 4;
$ParentFolderContainerName = "bunch-of-items";

#Constants
$PageTemplateId = 			"{76036F5E-CBCE-46D1-AF0A-4143F9B557AA}" 		#(Sample Item)
$FolderTemplateId = 		"{A87A00B1-E6DB-45AB-8B54-636FEC3B5523}"
$HomePath = 				"master:\content\home\"
$MaxAllowedItemsPerFolder= 	"100";

#Validation
if($MaxItemsPerFolder -gt $MaxAllowedItemsPerFolder) {
	throw [System.ArgumentException] "Parameter 'MaxItemsPerFolder' can't be more than $MaxAllowedItemsPerFolder for performance reasons."
}

#Create Items
$NewFolderContainer = New-Item -Path $HomePath -Name $ParentFolderContainerName -ItemType $FolderTemplateId


Function Get-RandomItemName {
	return ( -join ((0x30..0x39) + ( 0x41..0x5A) + ( 0x61..0x7A) | Get-Random -Count 8  | % {[char]$_}) )
}

Function Create-BunchOfItems([int]$p_TotalItems, [string]$p_RoothPath, [ref]$p_TotalCreatedItems) {	
	$RandomPageName = Get-RandomItemName
	$NewPage = New-Item -Path $p_RoothPath -Name $RandomPageName -ItemType $PageTemplateId
	$p_TotalCreatedItems.Value = $p_TotalCreatedItems.Value + 1
	Write-Host "Create the item number $CreatedItemsCount"
	
	if($CreatedItemsCount -eq $TotalItems) {
		return
	}
	
	$TotalOfChildren = [Math]::Ceiling($p_TotalItems / $MaxItemsPerFolder)
	if($TotalOfChildren -gt $MaxItemsPerFolder) {
		$TotalOfChildren = $MaxItemsPerFolder
	}
	For ($i=1; $i -le $TotalOfChildren; $i++) {
		$TotalItemsToBeCreated = $p_TotalItems / $MaxItemsPerFolder
		Create-BunchOfItems $TotalItemsToBeCreated $NewPage.FullPath
	}
}

$CreatedItemsCount = 0;
Create-BunchOfItems $TotalItems ($HomePath + $NewFolderContainer.Name) ([ref]$CreatedItemsCount)
Write-Host("$CreatedItemsCount items created.")