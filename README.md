# MOTIVE: Micropayments fOr Trusted vehIcular serVicEs

MOTIVE is a framework that can be used to build applications that allow vehicles to exchange payment for data and compute services. It has been developed at the USC Viterbi Center for Cyber-Physical Systems and Internet of Things (CCI) & Autonomous Networks Research Group (ANRG).

![MOTIVE Architecture illustration](/documents/Motive-architecture-full.png)

## Video Demo
<a href="http://www.youtube.com/watch?feature=player_embedded&v=qBkDRzxOUrA
" target="_blank"><img src="http://img.youtube.com/vi/qBkDRzxOUrA/0.jpg" 
alt="IMAGE ALT TEXT HERE" width="240" height="180" border="10" /></a>

## More Reading
* “[MOTIVE: Micropayments fOr Trusted vehIcular serVicEs](/documents/Motive.pdf)”. 

## Motivation
Increasingly connected cars are becoming a decentralized data platform. With greater autonomy, they have growing needs for computation and perceiving the world around them through sensors. While today’s generation of the vehicle carries all the necessary sensor data and computation on-board each vehicle, we envision a future where vehicles can cooperate to increase their perception of the world beyond their immediate view, resulting in greater safety, coordination and more comfortable experience for their human occupants.
## Problem
For vehicles to obtain data, compute and other services from other vehicles or road-side infrastructure, it is important to be able to make payments for those services and for the services to run seamlessly despite the challenges posed by mobility and transient interactions with a dynamic set of neighboring devices. We present a trusted and decentralized framework that allows vehicles to make peer-to-peer micropayments for data, compute and other services obtained from other vehicles or road-side infrastructure within radio range. The framework utilizes distributed ledger technologies including smart contracts to enable autonomous operation and trusted interactions between vehicles and nearby entities.
## Solution: MOTIVE
The key components of MOTIVE include beaconing, link prediction, scheduling, payment, and ratings. We implemented the **beaconing** functionality using WiFi's AdHoc feature. Whenever a MOTIVE device comes in contact with another MOTIVE device, the devices establish a link and exchange the provided and required services. The **ratings** smart contract in Ethereum, which consists of three functions to add a new user to the MOTIVE eco-system, get the rating of an existing user, and rate a user after a transaction. We implemented a client application for handling the **payment and recording** of the transactions using Ethereum and Web3.

## Folder Summary
We maintain the software and the demonstration of MOTIVE in different folders. The following list provides a high-level summary of the different folders.

* **[DEMO](/demo/): This folder maintains the stand-alone demonstration application developed for the Windows environment.**
* [demo_source](/demo_source/): This folder contains source codes used to build the demo applications.
* [documents](/documents/): This folder consists of the technical documents explaining the architecture and the research challenges involved in the implementation of MOTIVE.
* [beaconing](/beaconing/): This folder includes the beaconing software developed using WiFi's AdHoc mode. 
* [rating](/rating/): The rating functionalities are implemented using Ethereum and Solidity. This folder consists of the smart contract and the Web3 client library for adding users along with modules for updating and querying the rating of users.
* [payment-and-record](/payment-and-record/): This folder consists of the payment and record modules developed for IOTA.
* [web-app](/web-app/): This folder contains the code for web frontend. We recommend the users to try MOTIVE using the Windows application.

## License
Copyright (c) 2019, USC Viterbi Center for Cyber-Physical Systems and Internet of Things (CCI) and Autonomous Networks Research Group (ANRG), USC. See [this](LICENSE.txt) file for more details.
