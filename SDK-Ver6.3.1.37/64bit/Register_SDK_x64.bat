cd /d %~dp0
if /i "%PROCESSOR_IDENTIFIER:~0,3%"=="X86" (
	echo system is x86, but new sdk is x64, so no copy or register
	) else (
		echo system is x64, new sdk is x64, copy and register.
		copy .\*.dll %windir%\System32\
		regsvr32 %windir%\System32\zkemkeeper.dll
	)
pause