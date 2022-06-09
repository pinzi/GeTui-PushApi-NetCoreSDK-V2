[string]$SCRIPT       = '.\build.cake'
 
# Install cake.tool
dotnet tool install --global cake.tool

Write-Host "dotnet cake $SCRIPT $ARGS" -ForegroundColor GREEN

dotnet cake $SCRIPT $ARGS