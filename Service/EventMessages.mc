; // EventMessages.mc
; // Event message definitions for Make Me Admin
; //
; // This file is compiled by the Message Compiler (mc.exe) to generate
; // resources that Windows Event Viewer uses to display event descriptions.
; //
; // The %1 placeholder will be replaced with the message text provided by the application

MessageIdTypedef=DWORD

SeverityNames=(Success=0x0:STATUS_SEVERITY_SUCCESS
    Informational=0x1:STATUS_SEVERITY_INFORMATIONAL
    Warning=0x2:STATUS_SEVERITY_WARNING
    Error=0x3:STATUS_SEVERITY_ERROR
    )

FacilityNames=(System=0x0:FACILITY_SYSTEM
    Runtime=0x2:FACILITY_RUNTIME
    Stubs=0x3:FACILITY_STUBS
    Io=0x4:FACILITY_IO_ERROR_CODE
)

LanguageNames=(English=0x409:MSG00409)
LanguageNames=(Danish=0x406:MSG00406)
LanguageNames=(French=0x40c:MSG0040C)

; // Event ID 0: UserAddedToAdminsSuccess
MessageId=0x0
Severity=Informational
Facility=Runtime
SymbolicName=MSG_USER_ADDED_SUCCESS
Language=English
%1
.
Language=Danish
%1
.
Language=French
%1
.

; // Event ID 1: UserRemovedFromAdminsSuccess
MessageId=0x1
Severity=Informational
Facility=Runtime
SymbolicName=MSG_USER_REMOVED_SUCCESS
Language=English
%1
.
Language=Danish
%1
.
Language=French
%1
.

; // Event ID 2: UserAddedToAdminsFailure
MessageId=0x2
Severity=Warning
Facility=Runtime
SymbolicName=MSG_USER_ADDED_FAILURE
Language=English
%1
.
Language=Danish
%1
.
Language=French
%1
.

; // Event ID 3: UserRemovedFromAdminsFailure
MessageId=0x3
Severity=Warning
Facility=Runtime
SymbolicName=MSG_USER_REMOVED_FAILURE
Language=English
%1
.
Language=Danish
%1
.
Language=French
%1
.

; // Event ID 4: UserRemovedByExternalProcess
MessageId=0x4
Severity=Informational
Facility=Runtime
SymbolicName=MSG_USER_REMOVED_EXTERNAL
Language=English
%1
.
Language=Danish
%1
.
Language=French
%1
.

; // Event ID 5: RemoteRequestInformation
MessageId=0x5
Severity=Informational
Facility=Runtime
SymbolicName=MSG_REMOTE_REQUEST
Language=English
%1
.
Language=Danish
%1
.
Language=French
%1
.

; // Event ID 6: SessionChangeEvent
MessageId=0x6
Severity=Informational
Facility=Runtime
SymbolicName=MSG_SESSION_CHANGE
Language=English
%1
.
Language=Danish
%1
.
Language=French
%1
.

; // Event ID 7: ReasonDialogEmpty
MessageId=0x7
Severity=Informational
Facility=Runtime
SymbolicName=MSG_REASON_DIALOG_EMPTY
Language=English
%1
.
Language=Danish
%1
.
Language=French
%1
.

; // Event ID 8: ReasonProvidedByUser
MessageId=0x8
Severity=Informational
Facility=Runtime
SymbolicName=MSG_REASON_PROVIDED
Language=English
%1
.
Language=Danish
%1
.
Language=French
%1
.

; // Event ID 9: RemoteAccessFailure
MessageId=0x9
Severity=Error
Facility=Runtime
SymbolicName=MSG_REMOTE_ACCESS_FAILURE
Language=English
%1
.
Language=Danish
%1
.
Language=French
%1
.

; // Event ID 101 (0x65): ElevatedProcess
MessageId=0x65
Severity=Informational
Facility=Runtime
SymbolicName=MSG_ELEVATED_PROCESS
Language=English
%1
.
Language=Danish
%1
.
Language=French
%1
.

; // Event ID 9000 (0x2328): DebugMessage
MessageId=0x2328
Severity=Informational
Facility=Runtime
SymbolicName=MSG_DEBUG
Language=English
%1
.
Language=Danish
%1
.
Language=French
%1
.
