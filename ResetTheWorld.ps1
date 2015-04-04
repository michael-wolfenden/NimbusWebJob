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

Write-Host ""
Write-Host "Create ServiceBus Namespace '$Namespace'" -foregroundcolor yellow
Write-Host "**********************************************************************" -foregroundcolor yellow

. scripts\Initialise-ServiceBus.ps1
Initialize-ServiceBus -Namespace $Namespace