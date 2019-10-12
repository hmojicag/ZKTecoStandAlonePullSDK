cd /d %~dp0
if /i "%PROCESSOR_IDENTIFIER:~0,3%"=="X86" (
	echo system is x86, new sdk is x86
	copy .\*.dll %windir%\system32\
	regsvr32 %windir%\system32\zkemkeeper.dll
	) else (
		echo system is x64, new sdk is x86, copy and register
		copy .\*.dll %windir%\SysWOW64\
		regsvr32 %windir%\SysWOW64\zkemkeeper.dll
	)
pause