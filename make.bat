@echo off
setlocal

set CWD=%CD%

rem set MSBUILD="c:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe"
set MSBUILD="c:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\MSBuild.exe"
rem set MSBUILD="c:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"

rem Project name
set PRJNAME=TinyBandwidthMonitor

rem Solution file
set SLNFILE=TinyBandwidthMonitor.sln

rem Generate strong key: sn -k sign.snk
set KEYFILE=%CD%\%PRJNAME%\sign.snk

rem Enable assmebly signing
set KEYSIGN=true

rem Using: make.bat strongname
if "%1"=="strongname" goto list-public-keys

if not exist %MSBUILD% goto error-msbuild

if not exist Release mkdir Release
if exist Release del /q Release\*.*

if not "%KEYSIGN%"=="true" (
	rem Build "unsigned" assemblies
	%MSBUILD% %SLNFILE% /t:Build /p:Configuration=Release
	if not "%ERRORLEVEL%"=="0" goto error-compile
)

if "%KEYSIGN%"=="true" (
	rem Build "signed" strong name assmeblies
  if not exist %KEYFILE% goto error-missing-keyfile
	%MSBUILD% %SLNFILE% /t:Build /p:Configuration=Release /p:SignAssembly=true /p:AssemblyOriginatorKeyFile=%KEYFILE% /p:DelaySign=false
	if not "%ERRORLEVEL%"=="0" goto error-compile
)

copy %PRJNAME%\bin\Release\*.dll Release > nul
copy %PRJNAME%\bin\Release\*.exe Release > nul

echo Done!
goto end

:list-public-keys
rem Check if "sn.exe" is a available
sn >nul 2>&1
if not "%ERRORLEVEL%" == "0" (
  echo Error: Requires Developer Command Prompt for Visual Studio
	exit /b 1
)

rem Check the second argument
if not "%2"=="" (
	echo %2
	sn -T Release\%2 | findstr Public
	echo.
	goto end
)

rem Check each file
call %0 strongname avconv.exe

goto end

:error-missing-keyfile
echo Error: key file not found: %KEYFILE%
echo Hint: open Developer Command Prompt for VS and run
echo   sn -k %KEYFILE%
endlocal
exit /b 0

:error-msbuild
echo Error: msbuild.exe not found
echo Hint: edit make.bat and update the path
endlocal
exit /b 0

:error-compile
echo Failed to build the release!
endlocal
exit /b 0

:end
endlocal
exit /b 0