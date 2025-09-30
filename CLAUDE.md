# MakeMeAdmin Project - Claude Instructions

## Project Overview
MakeMeAdmin is a Windows application that allows standard user accounts to be temporarily elevated to administrator-level privileges in a controlled, audited manner. This is commonly used in enterprise environments where users occasionally need admin access without permanent elevation.

## Architecture
The solution consists of multiple C# projects targeting .NET Framework:

### Core Components
- **Service** - Windows Service handling privileged operations via WCF
- **UserRequestApp** (LocalUI) - Local WinForms UI for requesting admin rights
- **RemoteUI** - Remote administration interface
- **Settings** - Registry-based configuration management
- **ProcessCommunication** - Inter-process communication layer
- **Logging** - Windows Event Log integration (dedicated MakeMeAdmin log)
- **UserList** - User/group management
- **LsaLogonSessions** - Windows logon session handling

### Support Components
- **Enumerations** - Shared constants and enums
- **WiXCustomAction** - Installer custom actions
- **Setup** - WiX Toolset installer project

## Build System
Uses MSBuild with Visual Studio 2022. Supports both x86 and x64 platforms.

**IMPORTANT**: Always perform a full clean before building to avoid issues with stale artifacts, especially after removing files or changing project configurations.

### Build Commands
```bash
# Full Clean (RECOMMENDED - always clean before building)
"C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe" MakeMeAdmin.sln -t:Clean -p:Configuration=Release -p:Platform=x86
"C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe" MakeMeAdmin.sln -t:Clean -p:Configuration=Release -p:Platform=x64

# Build (after clean)
"C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe" MakeMeAdmin.sln -t:Build -p:Configuration=Release -p:Platform=x86
"C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe" MakeMeAdmin.sln -t:Build -p:Configuration=Release -p:Platform=x64

# Alternative: Clean and Build in one command
"C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe" MakeMeAdmin.sln -t:Clean;Build -p:Configuration=Release -p:Platform=x86
"C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe" MakeMeAdmin.sln -t:Clean;Build -p:Configuration=Release -p:Platform=x64
```

### Build Best Practices
- **Always clean before building** to prevent issues with:
  - Stale multilingual satellite assemblies
  - Cached project references
  - Outdated WiX installer components
  - Resource file conflicts
- **Avoid incremental builds** when making structural changes to projects
- **Clean both platforms** when switching between x86/x64 builds

### WiX Installer Issues
- WiX Toolset v3.11 path configuration problem
- Requires admin rights to build installer projects
- Need to restart Visual Studio with admin rights to resolve WiX targets path

## Key Technologies
- **C# / .NET Framework** - Primary development platform
- **Windows Communication Foundation (WCF)** - Service communication
- **Windows Registry** - Configuration storage
- **Windows Services** - Background service architecture
- **WinForms** - User interface framework
- **Windows Security APIs** - LSA, token manipulation
- **WiX Toolset** - Installer creation

## Configuration
Settings are stored in Windows Registry under policy and preference keys:
- **Allowed Entities** - Users/groups permitted to request elevation
- **Timeout Settings** - Duration of temporary admin rights
- **Logging Configuration** - Event log settings
- **Service Endpoints** - TCP and Named Pipe communication settings

## Security Model
- Service runs with elevated privileges
- Client applications run as standard user
- Communication via secure WCF channels (Named Pipes/TCP)
- Registry-based policy enforcement
- Comprehensive audit logging
- Time-limited privilege elevation

## Development Guidelines
- Follow existing code patterns and naming conventions
- Use existing Settings class for configuration access
- Implement proper logging via Logging project
- Handle Windows security contexts carefully
- Test privilege elevation scenarios thoroughly
- Maintain x86/x64 platform compatibility

## Common File Locations
- **Configuration**: `Settings/Settings.cs`
- **Service Logic**: `Service/MakeMeAdminService.cs`
- **Local UI**: `UserRequestApp/SubmitRequestForm.cs`
- **Remote Admin**: `RemoteUI/SubmitRequestForm.cs`
- **Logging**: `Logging/ApplicationLog.cs`
- **User Management**: `UserList/UserList.cs`

## Testing
- Use TestCode project for testing functionality
- Test both x86 and x64 builds
- Verify service installation and startup
- Test privilege elevation scenarios
- Validate configuration changes
- Check audit logging functionality

## Deployment
- Build both x86 and x64 installers using WiX
- Service auto-installs during setup
- Registry configuration applied via installer
- Supports enterprise deployment scenarios