Function Initialize-ServiceBus
{
    [CmdletBinding()]
    Param(
        [Parameter(Mandatory = $true)]
        [string]
        $Namespace
    )

    Import-Module ServiceBus

    $CurrentNamespace = Get-SBNamespace | Where-Object {$_.Name -eq $Namespace}

    if ($CurrentNamespace)
    {
        Write-Host "The namespace [$Namespace] already exists, no need to create."  -foregroundcolor green
    }
    else
    {
        Write-Host "The [$Namespace] namespace does not exist."
        Write-Host "Creating the [$Namespace] namespace"

        $LocalUser = [Environment]::UserName
        New-SBNamespace -Name $Namespace -ManageUsers $LocalUser
        
        Write-Host "The [$Namespace] namespace has been successfully created."  -foregroundcolor green
    }
}