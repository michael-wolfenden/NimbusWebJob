$ErrorActionPreference = 'Stop'
$PSScriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Definition
Set-StrictMode -Version Latest

Write-Host ""
Write-Host "███╗   ██╗██╗███╗   ███╗██████╗ ██╗   ██╗███████╗    ██╗    ██╗███████╗██████╗          ██╗ ██████╗ ██████╗ "
Write-Host "████╗  ██║██║████╗ ████║██╔══██╗██║   ██║██╔════╝    ██║    ██║██╔════╝██╔══██╗         ██║██╔═══██╗██╔══██╗"
Write-Host "██╔██╗ ██║██║██╔████╔██║██████╔╝██║   ██║███████╗    ██║ █╗ ██║█████╗  ██████╔╝         ██║██║   ██║██████╔╝"
Write-Host "██║╚██╗██║██║██║╚██╔╝██║██╔══██╗██║   ██║╚════██║    ██║███╗██║██╔══╝  ██╔══██╗    ██   ██║██║   ██║██╔══██╗"
Write-Host "██║ ╚████║██║██║ ╚═╝ ██║██████╔╝╚██████╔╝███████║    ╚███╔███╔╝███████╗██████╔╝    ╚█████╔╝╚██████╔╝██████╔╝"
Write-Host "╚═╝  ╚═══╝╚═╝╚═╝     ╚═╝╚═════╝  ╚═════╝ ╚══════╝     ╚══╝╚══╝ ╚══════╝╚═════╝      ╚════╝  ╚═════╝ ╚═════╝ "
Write-Host ""

# ServiceBus settings
$Namespace = "nimbus-web-job"

# Local watch folder
$FolderName = "WEBJOBS_SHUTDOWN_FILE"
$TempFolder = (get-item $env:temp).FullName
$LocalWatchDirctory = Join-Path $TempFolder -ChildPath $FolderName

Write-Host ""
Write-Host "Create servicebus namespace '$Namespace'" -foregroundcolor yellow
Write-Host "**********************************************************************" -foregroundcolor yellow

. scripts\Initialise-ServiceBus.ps1
Initialize-ServiceBus -Namespace $Namespace

Write-Host ""
Write-Host "Create local watch folder  '$LocalWatchDirctory'" -foregroundcolor yellow
Write-Host "**********************************************************************" -foregroundcolor yellow
New-Item -ItemType Directory -Force -Path $LocalWatchDirctory | Out-Null

Write-Host "The folder [$LocalWatchDirctory] has been successfully created."  -foregroundcolor green