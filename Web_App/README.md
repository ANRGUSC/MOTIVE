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
2. Open browser and type `localhost:3000` to go to Home Page.

## Toggle Ethereum Accounts
1.If you want to use another Metamask/Ethereum account linked to your Dashboard :
`routes\index.js`.
2.Change the private key to the account by changing:
`const account = web3.eth.accounts.privateKeyToAccount('--YOUR_INFURA_KEY--');`.
