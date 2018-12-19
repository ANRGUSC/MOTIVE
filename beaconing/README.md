# Beaconing

Setting up debian for peer to peer ad-hoc communication based on NodeJS.

## Requirements

Tested with `Node.js v11.x`.

## Configuration

1. Modify wireless controller in `/etc/network/interfaces`:

```
auto wlan0
iface wlan0 inet static
	address 10.1.1.1
	netmask 255.0.0.0
	wireless-channel 1
	wireless-essid D96C3AA7743D4F0BFE9EA149D5249C16
	wireless-mode ad-hoc
```

- Replace `wlan0` with target wireless network interface. 
- Modify IP address and/or netmask for other machines, or as desired, respectively.

2. Modify `var port` in `seller.js` to set desired incoming seller TCP communication port for buyers.

3. Modify `var ip` and `var port` in `buyer.js` to point to seller machine IP address and port.

### Json Payload

A sample JSON file is provided which will be sent over the connection. 

Seller will send the data in `services_provided.json`. Buyer will send the data in `services_needed.json`. 

Modify the contents of file as needed.

## Usage

1. Ensure respective `*.json` files are in the same `./` directory as the `*.js` files, then run on separate machines:

`nodejs seller.js`
`nodejs buyer.js`

`*.json` file names are static - changing it will result in a broken location reference unless source code is updated.

2. Contents in `*.json` files will be sent immediately upon successful connection. 

3. User can then type strings into the console from `buyer.js`, which will be sent to `seller.js` and then return unmodified.

4. Terminate by sending `end` from `buyer.js` or `^C`.

## 	Additional Information

- Manually control wireless interface to simulate connection disconnection:

`ifconfig wlan0 [up/down]`

- Check interface status:

`iwconfig`

- Source and destination IP addresses are configured to known values in this implementation.

v0.1