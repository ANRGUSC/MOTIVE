# Demo App

Preparing a Windows environment to run the MOTIVE simulator.

## Functionalities Demonstrated

MOTIVE consists of the following key components:
* Beaconing: For identifying other MOTIVE devices.
* Link Prediction: To estimate how long the two MOTIVE devices (vehicles) will stay in contact with each other.
* Scheduling: For allocating the resources needed to provide and consume the data and compute services.
* Payment and Record: To pay for the services consumed and to record the transactions for verification purposes.
* Rating: To rate other MOTIVE devices (vehicles).

The beaconing implementation was carried out using WiFi's AdHoc mode (see [beaconing](../beaconing/)). In the demonstration, we configure the time when the vehicle will come in range since the demo of beaconing requires two MOTIVE devices. Next, the link prediction functionality is demonstrated through the configuration parameter, which determines how long the two vehicles will stay in contact with each other. Subsequently, the scheduling of EV_CHARGING_INFO service is illustrated using a simple FIFO scheduler. Next, the payment and recording of transactions are carried out using Ethereum Ropsten testnet. Lastly, the rating functionality is demonstrated using Ethereum Smart Contract deployed at Ethereum Ropsten testnet ((see [rating](../rating/)). Note that MOTIVE is agnostic to distributed ledger technology and the V2X communication system. 

* [Rating Smart Contract at Ropsten Testnet](https://ropsten.etherscan.io/address/0xab0defc61a0e795985c432b46bb5e9a895a67399)
* [Local Vehicle Address](https://ropsten.etherscan.io/address/0x32590BB72050e53df34676f9A75c17A0677866c7)
* [Remote Vehicle Address](https://ropsten.etherscan.io/address/0x1b87cd9c9c12a931958c114c9b6c257263e8a04e)


## Prerequisites

- .NET Framework 4.6 Runtime (Preinstalled on Windows 10 and above)
- Microsoft Windows x64, Vista and above*
- Internet connection required for blockchain transactions
- First runtime may trigger Windows Firewall Alert, and it is safe to allow the connection**

\* Tested on Windows 7 x64 and Windows 10 x64 1703/1803.

\*\* Application name dependent. Changing the application name will trigger a new alert.

## Preparing

Using `git` or your Git version control system:

`git clone https://github.com/ANRGUSC/MOTIVE/`

Alternatively, download the `*.zip` archive at `Clone or download > Download ZIP` on GitHub.com and decompress it.

Do not move or remove `app.exe`, `/node_modules` and its subdirectory contents.

## Configuration

Configuration parameters will be presented for modification upon launching the application.

Value limitations:
- Timer until a vehicle comes in range: 1s to 10s (Default: 10s)
- Timer until a vehicle goes out of range: 30s to 150s (Default: 150s)

## Usage

Run `MOTIVE.exe`, not `app.exe`, otherwise, the demo cannot advance.

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

`node_modules` or its subdirectory contents is moved or removed. Please clone or download the repository again.

```
...
(node:5056) UnhandledPromiseRejectionWarning: Unhandled promise rejection. This error originated either by throwing inside of an async function without a catch block, or by rejecting a promise which was not handled with .catch(). (rejection id: 5)
```

No Internet connection. Please check for Internet connectivity and if MOTIVE.exe is allowed to access the Internet. This error will not terminate the application, `^C` to terminate.

```
app.exe not found in .\
```

`app.exe` moved or removed. Please clone or download the repository again.

##     Additional Information

- `app.exe` needs to be under the same `./` directory as `MOTIVE.exe`.
- Files under `/node_modules` are required to run `MOTIVE.exe`. 
- Display scaling settings may affect the size of text and contents.

v1.1
