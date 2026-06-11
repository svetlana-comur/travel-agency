[Console]::OutputEncoding = [System.Text.Encoding]::UTF8
$OutputEncoding = [System.Text.Encoding]::UTF8

Write-Host "====================================" -ForegroundColor Red
Write-Host "DATABASE RESET STARTING" -ForegroundColor Red
Write-Host "===================================="

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

Write-Host "Dropping database (once)..." -ForegroundColor Yellow

dotnet ef database drop `
    --project $project `
    --startup-project $startup `
    --force `
    --context TourContext

if ($LASTEXITCODE -eq 0) {
    Write-Host "Database dropped successfully" -ForegroundColor Green
} else {
    Write-Host "Drop failed (maybe already deleted)" -ForegroundColor DarkYellow
}

Write-Host "Cleaning migrations..." -ForegroundColor Yellow

Get-ChildItem -Path $project -Recurse -Directory -Filter "Migrations" |
ForEach-Object {
    Remove-Item $_.FullName -Recurse -Force -ErrorAction SilentlyContinue
}

Write-Host "Migrations cleaned" -ForegroundColor Green

$name = Read-Host "Enter base migration name (Initial)"

foreach ($ctx in $contexts) {

    Write-Host "===================================="
    Write-Host "Context: $ctx" -ForegroundColor Cyan

    $short = $ctx.Replace("Context","")
    $migrationName = "$name-$short"

    Write-Host "Migration: $migrationName" -ForegroundColor Yellow

    dotnet ef migrations add $migrationName `
        --project $project `
        --startup-project $startup `
        --context $ctx

    if ($LASTEXITCODE -ne 0) {
        Write-Host "Migration FAILED: $ctx" -ForegroundColor Red
        continue
    }

    dotnet ef database update `
        --project $project `
        --startup-project $startup `
        --context $ctx

    if ($LASTEXITCODE -ne 0) {
        Write-Host "DB update FAILED: $ctx" -ForegroundColor Red
        continue
    }

    Write-Host "DONE: $ctx" -ForegroundColor Green
}

Write-Host "===================================="
Write-Host "RESET COMPLETE" -ForegroundColor Green
Write-Host "===================================="

pause