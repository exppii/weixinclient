; WeiXinClient.nsi
;
; This script is perhaps one of the simplest NSIs you can make. All of the
; optional settings are left to their default settings. The installer simply
; prompts the user asking them where to install, and drops a copy of example1.nsi
; there.
;--------------------------------


;Include Modern UI
!include "MUI.nsh"
!include InstallOptions.nsh


!define TEMP1 $R0
!define PRODUCT_NAME "WeiXinClient";
;!define MUI_ICON "applications_internet_128.ico"
; The name of the installer
Name "国防科技大学微信管理平台"


; The file to write
OutFile "${PRODUCT_NAME}_install.exe"

; The default installation directory
InstallDir "C:\Program Files (x86)\${PRODUCT_NAME}"

; Request application privileges for Windows Vista
;RequestExecutionLevel user
RequestExecutionLevel admin

;--------------------------------
!define MUI_ABORTWARNING
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE "LICENSE.txt"
 Page Custom SerialPageShow SerialPageLeave

!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

!insertmacro MUI_UNPAGE_WELCOME
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH

;--------------------------------
;Language
!insertmacro MUI_DEFAULT MUI_PAGE_UNINSTALLER_PREFIX ""
!insertmacro MUI_LANGUAGE "SimpChinese"

;Use ReserveFile for your own InstallOptions INI files too!

;ReserveFile "${NSISDIR}\Plugins\x86-unicode\InstallOptions.dll"



## Displays the serial dialog
Function SerialPageShow

 !insertmacro MUI_HEADER_TEXT "授权验证" "输入产品密钥 xxxx-xxxx-xxxx-xxxx-xxxx."

 PassDialog::Dialog Serial            \
                    /HEADINGTEXT '请输入正确的产品密钥....' \
                    /CENTER             \
                    /BOXDASH 12  70 4 '' \
                    /BOXDASH 92  70 4 ''  \
                    /BOXDASH 172 70 4 ''   \
                    /BOXDASH 252 70 4 ''    \
                    /BOX     332 70 4 ''

  Pop $R0 # success, back, cancel or error

FunctionEnd

## Validate serial numbers
Function SerialPageLeave

 ## Pop values from stack
 Pop $R0
 Pop $R1
 Pop $R2
 Pop $R3
 Pop $R4

 ## A bit of validation
 StrCmp $R0 'aaaa' 0 +4
 StrCmp $R1 'aaaa' 0 +3
 StrCmp $R2 'aaaa' 0 +2
 StrCmp $R3 'aaaa' 0 +1
 StrCmp $R4 'aaaa' +3 0
  MessageBox MB_OK|MB_ICONEXCLAMATION "您输入的密钥无效，请输入正确密钥!"
  Abort

 ## Display the values
; MessageBox MB_OK|MB_ICONINFORMATION "You inputted: $R0, $R1, $R2, $R3, $R4"

FunctionEnd


Function GetNetFrameworkVersion
;获取.Net Framework版本支持
    Push $1
    Push $0
    ReadRegDWORD $0 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" "Install"
    ReadRegDWORD $1 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" "Version"
    StrCmp $0 1 KnowNetFrameworkVersion +1
    ReadRegDWORD $0 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5" "Install"
    ReadRegDWORD $1 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5" "Version"
    StrCmp $0 1 KnowNetFrameworkVersion +1
    ReadRegDWORD $0 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.0\Setup" "InstallSuccess"
    ReadRegDWORD $1 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.0\Setup" "Version"
    StrCmp $0 1 KnowNetFrameworkVersion +1
    ReadRegDWORD $0 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v2.0.50727" "Install"
    ReadRegDWORD $1 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v2.0.50727" "Version"
    StrCmp $1 "" +1 +2
    StrCpy $1 "2.0.50727.832"
    StrCmp $0 1 KnowNetFrameworkVersion +1
    ReadRegDWORD $0 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v1.1.4322" "Install"
    ReadRegDWORD $1 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v1.1.4322" "Version"
    StrCmp $1 "" +1 +2
    StrCpy $1 "1.1.4322.573"
    StrCmp $0 1 KnowNetFrameworkVersion +1
    ReadRegDWORD $0 HKLM "SOFTWARE\Microsoft\.NETFramework\policy\v1.0" "Install"
    ReadRegDWORD $1 HKLM "SOFTWARE\Microsoft\.NETFramework\policy\v1.0" "Version"
    StrCmp $1 "" +1 +2
    StrCpy $1 "1.0.3705.0"
    StrCmp $0 1 KnowNetFrameworkVersion +1
    StrCpy $1 "not .NetFramework"
    KnowNetFrameworkVersion:
    Pop $0
    Exch $1
FunctionEnd


Function DownloadNetFramework2
;下载 .NET Framework 2.0 SP2
  NSISdl::download /TRANSLATE2 '正在下载 %s' '正在连接...' '(剩余 1 秒)' '(剩余 1 分钟)' '(剩余 1 小时)' '(剩余 %u 秒)' '(剩余 %u 分钟)' '(剩余 %u 小时)' '已完成：%skB(%d%%) 大小：%skB 速度：%u.%01ukB/s' /TIMEOUT=7500 /NOIEPROXY 'http://download.microsoft.com/download/c/6/e/c6e88215-0178-4c6c-b5f3-158ff77b1f38/NetFx20SP2_x86.exe' '$TEMP\NetFx20SP2_x86.exe'
  Pop $R0
  StrCmp $R0 "success" 0 +3

  SetDetailsPrint textonly
  DetailPrint "正在安装 .NET Framework 2.0 SP2..."
  SetDetailsPrint listonly
  ExecWait '$TEMP\NetFx20SP2_x86.exe /norestart' $R1
  Delete "$TEMP\NetFx20SP2_x86.exe"

FunctionEnd

Function DownloadNetFramework35
;下载 .NET Framework 3.5 SP1
  NSISdl::download /TRANSLATE2 '正在下载 %s' '正在连接...' '(剩余 1 秒)' '(剩余 1 分钟)' '(剩余 1 小时)' '(剩余 %u 秒)' '(剩余 %u 分钟)' '(剩余 %u 小时)' '已完成：%skB(%d%%) 大小：%skB 速度：%u.%01ukB/s' /TIMEOUT=7500 /NOIEPROXY 'http://download.microsoft.com/download/2/0/E/20E90413-712F-438C-988E-FDAA79A8AC3D/dotnetfx35.exe' '$TEMP\dotnetfx35.exe'
  Pop $R0
  StrCmp $R0 "success" 0 +2

  SetDetailsPrint textonly
  DetailPrint "正在安装 .NET Framework 3.5 SP1..."
  SetDetailsPrint listonly
  ExecWait '$TEMP\dotnetfx35.exe /norestart' $R1
  Delete "$TEMP\dotnetfx35.exe"

FunctionEnd

Function DownloadNetFramework4
;下载 .NET Framework 4.0
  NSISdl::download /TRANSLATE2 '正在下载 %s' '正在连接...' '(剩余 1 秒)' '(剩余 1 分钟)' '(剩余 1 小时)' '(剩余 %u 秒)' '(剩余 %u 分钟)' '(剩余 %u 小时)' '已完成：%skB(%d%%) 大小：%skB 速度：%u.%01ukB/s' /TIMEOUT=7500 /NOIEPROXY 'http://download.microsoft.com/download/9/5/A/95A9616B-7A37-4AF6-BC36-D6EA96C8DAAE/dotNetFx40_Full_x86_x64.exe' '$TEMP\dotNetFx40_Full_x86_x64.exe'
  Pop $R0
  StrCmp $R0 "success" 0 +2

  SetDetailsPrint textonly
  DetailPrint "正在安装 .NET Framework 4.0 Full..."
  SetDetailsPrint listonly
  ExecWait '$TEMP\dotNetFx40_Full_x86_x64.exe /norestart' $R1
  Delete "$TEMP\dotNetFx40_Full_x86_x64.exe"

FunctionEnd

Function DownloadNetFramework45
;下载 .NET Framework 4.5
  NSISdl::download /TRANSLATE2 '正在下载 %s' '正在连接...' '(剩余 1 秒)' '(剩余 1 分钟)' '(剩余 1 小时)' '(剩余 %u 秒)' '(剩余 %u 分钟)' '(剩余 %u 小时)' '已完成：%skB(%d%%) 大小：%skB 速度：%u.%01ukB/s' /TIMEOUT=7500 /NOIEPROXY 'http://download.microsoft.com/download/E/2/1/E21644B5-2DF2-47C2-91BD-63C560427900/NDP452-KB2901907-x86-x64-AllOS-ENU.exe' '$TEMP\NDP452-KB2901907-x86-x64-AllOS-ENU.exe'
  Pop $R0
  StrCmp $R0 "success" 0 +2

  SetDetailsPrint textonly
  DetailPrint "正在安装 .NET Framework 4.5.2 ..."
  SetDetailsPrint listonly
  ExecWait '$TEMP\NDP452-KB2901907-x86-x64-AllOS-ENU.exe /norestart' $R1
  Delete "$TEMP\NDP452-KB2901907-x86-x64-AllOS-ENU.exe"

FunctionEnd
;--------------------------------


Section -.NET Framework
  ;检测是否是需要的.NET Framework版本
  SectionIn RO
  Call GetNetFrameworkVersion
  Pop $R1
  ;${If} $R1 < '2.0.50727'
  ;${If} $R1 < '3.5.30729.4926'
  ${If} $R1 < '4.0.30319'
  ;${If} $R1 < '4.5.52747'
    MessageBox MB_YESNO|MB_ICONQUESTION "此软件运行需要.NET Framework 4.0运行环境，但您机器上似乎没有安装此环境。$\r$\n您有两个选择：$\r$\n1.您自己到互联网上下载.NET Framework 4.0安装，然后再运行此软件$\r$\n2.使用此安装程序在线下载并安装.NET Framework 4.0$\r$\n$\r$\n现在在线下载并安装.NET Framework 4.0,请确认您的机器已连接互联网.继续吗？" \
    /SD IDYES IDYES label_yes IDNO label_no
label_yes:
      Call DownloadNetFramework4
      Goto end
label_no:
    Abort
end:
    ${ENDIF}
SectionEnd

Section -Visual C++ Redistributable
  ;检测是否是需要的.NET Framework版本
  SectionIn RO



  ReadRegDword $R2 HKLM "SOFTWARE\Wow6432Node\Microsoft\VisualStudio\12.0\VC\Runtimes\x86" "Installed"
  ${AndIf} $R2 != "1"
        SetDetailsPrint textonly
        DetailPrint "正在安装 Visual C++ Redistributable 2013..."
        SetDetailsPrint listonly
        SetOutPath "$TEMP"
        SetOverwrite on
        File "vcredist_x86.exe"
        ExecWait '$TEMP\vcredist_x86.exe /q /norestart ' $R2
        Delete "$TEMP\vcredist_x86.exe"
  ${Else}
    !insertmacro Log "VisualStudio DLLs to the standard package (C++) 2013 is installed."
  ${EndIf}
SectionEnd


Section "WeiXinClient" ;
  SectionIn RO

  SetOutPath $INSTDIR

  ; Put file there
  File WeiXinClient.exe
  File WeiXinClient.exe.manifest
  File WeiXinClient.exe.config
  File CefSharp.BrowserSubprocess.exe
  File *.dll
  File *.xml
  File *.pak
  File icudtl.dat
  File natives_blob.bin
  File snapshot_blob.bin
  SetOutPath $INSTDIR\locales
  File locales\*.pak
  WriteUninstaller "$INSTDIR\Uninstall.exe"

SectionEnd

Section "桌面快捷方式"
  SectionIn 1
  CreateShortCut "$DESKTOP\${PRODUCT_NAME}.lnk" "$INSTDIR\${PRODUCT_NAME}.exe"

SectionEnd

Section "加入开始菜单"
  SectionIn 1
  SetShellVarContext all
  CreateDirectory "$SMPROGRAMS\${PRODUCT_NAME}"
  CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\Uninstall.lnk" "$INSTDIR\Uninstall.exe"
  CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\${PRODUCT_NAME}.lnk" "$INSTDIR\${PRODUCT_NAME}.exe"

SectionEnd
;--------------------------------
;Uninstaller Section
Section "Uninstall"

;Delete Start Menu Shortcuts
  Delete "$DESKTOP\${PRODUCT_NAME}.lnk"

;Delete Files

  RMDIR /r  "$INSTDIR\locales\*.*"
  RMDir /r "$INSTDIR\*.*"

;Remove the installation directory
  RMDir "$INSTDIR"



SetShellVarContext all

  RMDIR /r "$SMPROGRAMS\${PRODUCT_NAME}\*.*"
  RmDir  "$SMPROGRAMS\${PRODUCT_NAME}"

SectionEnd



;eof
