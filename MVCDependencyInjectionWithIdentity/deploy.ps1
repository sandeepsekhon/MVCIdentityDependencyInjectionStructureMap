param([string]$computerName, [string]$destinationDir, [string]$packName, [string]$packVersion, [string]$executeLocally)

Write-Host "computer name: $computerName"
Write-Host "destination dir: $destinationDir"
Write-Host "package name: $packName"
Write-Host "package version: $packVersion"
Write-Host "execute locally: $executeLocally"

$deployScript = {
param($dest, $packageName, $version)

$basePath = "d:\packages\"

$packageNameAndVersion = "$packageName.$version"
$extractDir = $basePath + $packageNameAndVersion

Write-Host "deploying to: $dest"
Write-Host "extracting to: $extractDir"
Write-Host "package: $packageName"
Write-Host "version: $version"

$zipDownload = $packageNameAndVersion + ".zip"

$packageUrl = "http://nuget.org/api/v2/package/$packageName/$version"

if (-Not (Test-Path $extractDir))
{
New-Item -ItemType directory -Path $extractDir
}else{
Get-ChildItem -Path ($extractDir + "\*") -Recurse | Remove-Item -Recurse -Force -Confirm:$false
}

$Path = $basePath + $zipDownload

Write-Host "Downloading package..."
$WebClient = New-Object System.Net.WebClient
$WebClient.DownloadFile($packageUrl, $path )

Write-Host "Extracting package..."

$shell = new-object -com shell.application
$zip = $shell.NameSpace($path)

foreach($item in $zip.items())
{
$shell.Namespace($extractDir).Copyhere($item)
}

Write-Host "Cleaning destination..."

Get-ChildItem -Path $dest -Recurse | Remove-Item -Recurse -Force -Confirm:$false

Write-Host "Deploying..."

Copy-Item ($extractDir + "\*") $dest -Recurse

Write-Host "Removing downloaded package from $path"
Remove-Item $path -Recurse -Force -Confirm:$false

Write-Host "Removing extracted package from $extractDir"
Remove-Item $extractDir -Recurse -Force -Confirm:$false
Remove-Item ("$extractDir\") -Recurse -Force -Confirm:$false

Write-Host "Done."

}

$output = Invoke-Command -ScriptBlock $deployScript -ArgumentList $destinationDir, $packName, $packVersion