try {
    $currentSprint = (Invoke-WebRequest https://whatsprintis.it -Headers @{"Accept" = "application/json" } | ConvertFrom-Json)

    # We're assuming this script will be used only once per sprint.
    $agentVersion = "3.$($currentSprint.sprint).0"

    Write-Host "Writing $agentVersion to agentversion file"
    $agentVersion | Out-File $PSScriptRoot/../src/agentversion
}
catch {
    Write-Error "Error: $($_.Exception.Message)" -ErrorAction Stop
}
