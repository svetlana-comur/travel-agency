[Console]::OutputEncoding = [System.Text.Encoding]::UTF8
$OutputEncoding = [System.Text.Encoding]::UTF8

$name = Read-Host "Enter base migration name"

$project = "TravelAgency.DataAccess"
$startup = "TravelAgency.Api"

$contexts = @(
    "TourContext",
    "SpaContext",
    "HotelContext",
    "PlaceContext",
    "PackageContext",
    "UserContext"
)

foreach ($ctx in $contexts) {

    Write-Host "===================================="
    Write-Host "Context: $ctx" -ForegroundColor Cyan

    $timestamp = Get-Date -Format "yyyyMMdd_HHmm"
    $migrationName = "$timestamp-$name-$($ctx.Replace('Context',''))"

    Write-Host "Migration name: $migrationName" -ForegroundColor Yellow

    dotnet ef migrations add $migrationName `
        --project $project `
        --startup-project $startup `
        --context $ctx

    if ($LASTEXITCODE -ne 0) {
        Write-Host "Migration FAILED: $ctx" -ForegroundColor Red
        continue
    }

    Write-Host "Migration created: $ctx" -ForegroundColor Green

    dotnet ef database update `
        --project $project `
        --startup-project $startup `
        --context $ctx

    if ($LASTEXITCODE -ne 0) {
        Write-Host "Update FAILED: $ctx" -ForegroundColor Red
        continue
    }

    Write-Host "DB updated: $ctx" -ForegroundColor Green
}

Write-Host "===================================="
Write-Host "ALL CONTEXTS PROCESSED" -ForegroundColor Green
pause