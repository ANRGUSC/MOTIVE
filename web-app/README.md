# Web App
Preparing Node.js environment to run MOTIVE Web App.

## Requirements
Tested with `Node.js v8.x+`.

## Preparing
Using `git` or your Git version control system:
`git clone https://github.com/ANRGUSC/MOTIVE/`
Do not move or remove `app.js`, `/node_modules` , `config` , `routes` , `views` and its subdirectory contents.

## Package Requirements
```
npm install
npm install web3
```

## Usage
1. In the Project Directory do `npm start`.
2. Open browser and type `localhost:8080` to go to Home Page.

## Toggle Ethereum Accounts
1.If you want to use another Metamask/Ethereum account linked to your Dashboard :
`routes\index.js`.
2.Change the private key to the account by changing:
`const account = web3.eth.accounts.privateKeyToAccount('--YOUR_INFURA_KEY--');`.

## Debugging
If you get the following error after cloning the repo.
```
Error: \\?\F:\USC\Motive\MOTIVE\web-app\node_modules\scrypt\build\Release\scrypt.node is not a valid Win32 application\\?\F:\USC\Motive\MOTIVE\web-app\node_modules\scrypt\build\Release\scrypt.node
    at Object.Module._extensions..node (module.js:664:18)
    at Module.load (module.js:554:32)
    at tryModuleLoad (module.js:497:12)
    at Function.Module._load (module.js:489:3)
    at Module.require (module.js:579:17)
    at require (internal/module.js:11:18)
    at Object.<anonymous> (F:\USC\Motive\MOTIVE\web-app\node_modules\scrypt\index.js:3:20)
    at Module._compile (module.js:635:30)
    at Object.Module._extensions..js (module.js:646:10)
    at Module.load (module.js:554:32)
npm ERR! code ELIFECYCLE
npm ERR! errno 1
npm ERR! motive@0.0.0 start: `node ./bin/www`
npm ERR! Exit status 1
npm ERR!
npm ERR! Failed at the motive@0.0.0 start script.
npm ERR! This is probably not a problem with npm. There is likely additional logging output above.
```
1. Please delete the `node_modules` folder.
2. `npm install`
3. `npm start`
4. Open the browser and go to localhost:8080.
5. The console should show `true` as it gets connected to Metamask.
