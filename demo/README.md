# Demo App

Preparing Windows environment to run MOTIVE simulator.

## Prerequisites

- .NET Framework 4.6 Runtime (Preinstalled on Windows 10 and above)
- Microsoft Windows x64, Vista and above*
- Internet connection required for blockchain transactions
- First runtime may trigger Windows Firewall Alert, it is safe to allow the connection**

    * Tested on Windows 7 x64 and Windows 10 x64 1703/1803.
    ** Application name dependent, changing application name will trigger a new alert.

## Preparing

Using `git` or your Git version control system:

`git clone https://github.com/ANRGUSC/MOTIVE/`

Do not move or remove `app.exe`, `/node_modules` and its subdirectory contents.

## Configuration

Configuration parameters will be presented for modification upon launching application.

Value limitations:
- Timer until a vehicle comes in range: 1s to 10s (Default: 10s)
- Timer until a vehicle goes out of range: 30s to 150s (Default: 150s)

## Usage

Run `MOTIVE.exe`, not `app.exe`, otherwise the demo cannot advance.

### GUI

1. Open `demo` folder and run `MOTIVE.exe`.

Terminate by closing the Command Prompt window.

### CLI

1. Open a `cmd` or `powershell` window. 
2. `cd` to the `\demo` folder.
3. Run `.\MOTIVE.exe`.

Terminate by `^C`.

## Debugging

```
...
Error: Cannot find module './build/Release/scrypt'
...
```

`node_modules` or its subdirectory contents is moved or removed. Please clone the repository again.

```
...
(node:5056) UnhandledPromiseRejectionWarning: Unhandled promise rejection. This error originated either by throwing inside of an async function without a catch block, or by rejecting a promise which was not handled with .catch(). (rejection id: 5)
```

No Internet connection. Please check for Internet connectivity and if MOTIVE.exe is allowed to access the Internet. This error will not terminate the application, `^C` to terminate.

```
app.exe not found in .\
```

`app.exe` moved or removed. Please clone the repository again.

## 	Additional Information

- `app.exe` needs to be under the same `./` directory as `MOTIVE.exe`.
- Files under `/node_modules` is required to run `MOTIVE.exe`. 
- Display scaling settings may affect size of text and contents.

v1.0