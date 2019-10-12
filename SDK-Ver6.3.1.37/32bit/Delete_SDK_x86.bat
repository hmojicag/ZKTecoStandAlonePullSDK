cd /d %~dp0
if /i "%PROCESSOR_IDENTIFIER:~0,3%"=="X86" (
	echo system is x86, new sdk is x86 
	del %windir%\System32\commpro.dll
	del %windir%\System32\comms.dll
	del %windir%\System32\rscagent.dll
	del %windir%\System32\rscomm.dll
	del %windir%\System32\tcpcomm.dll
	del %windir%\System32\usbcomm.dll
	del %windir%\System32\usbstd.dll
	del %windir%\System32\zkemkeeper.dll
	del %windir%\System32\zkemsdk.dll
	del %windir%\System32\plcommpro.dll
	del %windir%\System32\plcomms.dll
	del %windir%\System32\plrscagent.dll
	del %windir%\System32\plrscomm.dll
	del %windir%\System32\pltcpcomm.dll
	regsvr32 %windir%\System32\zkemkeeper.dll -u
	) else (
		echo system is x64, new sdk is x86, delete all
		del %windir%\System32\commpro.dll
		del %windir%\System32\comms.dll
		del %windir%\System32\rscagent.dll
		del %windir%\System32\rscomm.dll
		del %windir%\System32\tcpcomm.dll
		del %windir%\System32\usbcomm.dll
		del %windir%\system32\usbstd.dll
		del %windir%\System32\zkemkeeper.dll
		del %windir%\System32\zkemsdk.dll
		del %windir%\System32\plcommpro.dll
		del %windir%\System32\plcomms.dll
		del %windir%\System32\plrscagent.dll
		del %windir%\System32\plrscomm.dll
		del %windir%\System32\pltcpcomm.dll
		regsvr32 %windir%\System32\zkemkeeper.dll -u
		del %windir%\SysWOW64\commpro.dll
		del %windir%\SysWOW64\comms.dll
		del %windir%\SysWOW64\rscagent.dll
		del %windir%\SysWOW64\rscomm.dll
		del %windir%\SysWOW64\tcpcomm.dll
		del %windir%\SysWOW64\usbcomm.dll
		del %windir%\SysWOW64\usbstd.dll
		del %windir%\SysWOW64\zkemkeeper.dll
		del %windir%\SysWOW64\zkemsdk.dll
		del %windir%\SysWOW64\plcommpro.dll
		del %windir%\SysWOW64\plcomms.dll
		del %windir%\SysWOW64\plrscagent.dll
		del %windir%\SysWOW64\plrscomm.dll
		del %windir%\SysWOW64\pltcpcomm.dll
		regsvr32 %windir%\SysWOW64\zkemkeeper.dll -u
	)
pause