param(
    [Parameter(Mandatory=$true)]
    [string]$ProjectName,
    
    [Parameter(Mandatory=$true)]
    [string]$OutputDir
)

Write-Host "Creating solution for project: $ProjectName in directory: $OutputDir"
Set-Location $OutputDir
dotnet new sln --name $ProjectName