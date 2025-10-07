# ConfigureEventLog.ps1
# Sets EventMessageFile registry keys for Make Me Admin event log
# The event log structure must already be created by New-EventLog before calling this script

param(
    [Parameter(Mandatory=$true)]
    [string]$InstallFolder
)

try {
    Write-Host "Setting EventMessageFile for Make Me Admin event log..."
    Write-Host "Install folder: $InstallFolder"

    $dllPath = Join-Path $InstallFolder "EventMessages.dll"
    $regPath = "HKLM:\SYSTEM\CurrentControlSet\Services\EventLog\MakeMeAdmin\Make Me Admin"

    # Verify the DLL exists
    if (-not (Test-Path $dllPath)) {
        Write-Host "ERROR: EventMessages.dll not found at: $dllPath"
        exit 1
    }

    # Verify the registry path exists (should have been created by New-EventLog)
    if (-not (Test-Path $regPath)) {
        Write-Host "ERROR: Registry path does not exist: $regPath"
        Write-Host "The event log must be created first with New-EventLog"
        exit 1
    }

    Write-Host "Setting EventMessageFile to: $dllPath"

    # Set the EventMessageFile and CategoryMessageFile registry values
    Set-ItemProperty -Path $regPath -Name "EventMessageFile" -Value $dllPath -Type ExpandString -ErrorAction Stop
    Set-ItemProperty -Path $regPath -Name "CategoryMessageFile" -Value $dllPath -Type ExpandString -ErrorAction Stop
    Set-ItemProperty -Path $regPath -Name "TypesSupported" -Value 7 -Type DWord -ErrorAction Stop

    Write-Host "EventMessageFile configured successfully."
    exit 0
}
catch {
    Write-Host "Error setting EventMessageFile: $_"
    Write-Host "Error details: $($_.Exception.Message)"
    exit 1
}
