param($scriptRoot)

$ErrorActionPreference = "Stop"

$programFilesx86 = ${Env:ProgramFiles(x86)}
$msBuild = "$programFilesx86\MSBuild\14.0\bin\msbuild.exe"
$nuGet = "$scriptRoot\..\tools\NuGet.exe"
$solution = "$scriptRoot\..\Sc.StaticAssets.sln"

& $nuGet restore $solution
& $msBuild $solution /p:Configuration=Release /t:Rebuild /m

$assembly = Get-Item "$scriptRoot\..\src\bin\Release\Sc.StaticAssets.dll" | Select-Object -ExpandProperty VersionInfo
$targetAssemblyVersion = $assembly.ProductVersion

& $nuGet pack "$scriptRoot\Sc.StaticAssets.nuget\Sc.StaticAssets.nuspec" -version $targetAssemblyVersion
& $nuGet pack "$scriptRoot\..\src\Sc.StaticAssets.csproj" -Symbols -Prop "Configuration=Release"