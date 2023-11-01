try {
    git config user.email "azure-pipelines-bot@microsoft.com"
    git config user.name "azure-pipelines-bot"

    git checkout -f origin/$env:BRANCH_NAME

    # Check if the branch is checked out, since git not returns bad code when the checkout failed.
    $resultBranchName = git rev-parse --abbrev-ref HEAD
    if ($resultBranchName -ne $env:BRANCH_NAME) {
        Write-Error "git not checked-out to  branch '$env:BRANCH_NAME'. Current branch is '$resultBranchName'" -ErrorAction Stop
    }
}
catch {
    Write-Host "Failed to checkout branch '$env:BRANCH_NAME'"
    Write-Host $_.Exception.Message
    exit 1
}
