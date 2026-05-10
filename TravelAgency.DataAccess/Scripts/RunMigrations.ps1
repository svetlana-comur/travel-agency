[Console]::OutputEncoding = [System.Text.Encoding]::UTF8
$OutputEncoding = [System.Text.Encoding]::UTF8
$PSDefaultParameterValues['Out-File:Encoding'] = 'utf8'

$name = Read-Host "Enter migration name"

$project = "TravelAgency.DataAccess"
$startup = "TravelAgency.Api"

$contexts = @(
    "TourContext",
    "UserContext"
)

foreach ($ctx in $contexts) {

    Write-Host "------------------------------------"
    Write-Host "Processing context: $ctx" -ForegroundColor Cyan

    # Создание миграции
    $output = cmd /c "dotnet ef migrations add $name --project $project --startup-project $startup --context $ctx" 2>&1

    # Проверка: есть ли изменения
    if ($output -match "No changes were found") {
        Write-Host "No changes in $ctx. Skipped." -ForegroundColor Yellow
        continue
    }

    # Если ошибка при создании миграции
    if ($LASTEXITCODE -ne 0) {
        Write-Host "Migration FAILED for $ctx" -ForegroundColor Red
        Write-Host $output
        exit 1
    }

    Write-Host "Migration created for $ctx" -ForegroundColor Green

    # Обновление базы
    dotnet ef database update `
        --project $project `
        --startup-project $startup `
        --context $ctx

    if ($LASTEXITCODE -ne 0) {
        Write-Host "Database update FAILED for $ctx" -ForegroundColor Red
        exit 1
    }

    Write-Host "Database updated for $ctx" -ForegroundColor Green
}

Write-Host "===================================="
Write-Host "ALL DONE" -ForegroundColor Green
pause