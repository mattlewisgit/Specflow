param([string]$projectRootPath, [string]$testRoot)

Out-Default -Input ("Project root path: {0}" -f $projectRootPath)

$testRootPath = Join-Path -Path $projectRootPath -ChildPath $testRoot
Out-Default -Input ("Test root path: {0}" -f $testRootPath)

New-Item $projectRootPath\TestResults -ItemType directory -Force

$xUnitRunner = Get-ChildItem $projectRootPath\packages\xunit.runner.console.*\tools\xunit.console.exe | Select -ExpandProperty FullName -First 1
$testProjects = Get-ChildItem $testRootPath -Recurse -Include *.UnitTests.dll | Where { $_.FullName -match "bin" } | Select -ExpandProperty FullName

& "$xUnitRunner" $testProjects -xml ("$projectRootPath\TestResults\UnitTestResults.xml")

exit $LASTEXITCODE
