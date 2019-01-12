# MOTIVE: Micropayments fOr Trusted vehIcular serVicEs

Motive is a framework that can be used to build applications that allow vehicles to exchange payment for data and compute services. It has been developed at the USC Viterbi Center for Cyber-Physical Systems and Internet of Things (CCI) & Autonomous Networks Research Group (ANRG).

![MOTIVE Architecture illustration](/documents/Motive-architecture-full.png)

## Video Demo
<a href="http://www.youtube.com/watch?feature=player_embedded&v=qBkDRzxOUrA
" target="_blank"><img src="http://img.youtube.com/vi/qBkDRzxOUrA/0.jpg" 
alt="IMAGE ALT TEXT HERE" width="240" height="180" border="10" /></a>

## More Reading
* “[MOTIVE: Micropayments fOr Trusted vehIcular serVicEs](/documents/Motive.pdf)”. 

## Motivation
Increasingly connected cars are becoming a decentralized data platform. With greater autonomy, they have growing needs for computation and perceiving the world around them through sensors. While today’s generation of vehicle carry all the needed sensor data and computation on-board each vehicle, we envision a future where vehicles can cooperate with each other to increase their perception of the world beyond their own immediate view, resulting in greater safety, coordination and a more comfortable experience for their human occupants.
## Problem
In order for vehicles to obtain data, compute and other services from other vehicles or road-side infrastructure, it is important to be able to make payments for those services and for the services to run seamlessly despite the challenges posed by mobility and ephemeral interactions with a dynamic set of neighboring devices. We present a trusted and decentralized framework that allows vehicles to make peer-to-peer micropayments for data, compute and other services obtained from other vehicles or road-side infrastructure within radio range. The framework utilizes distributed ledger technologies including smart contracts to enable autonomous operation and trusted interactions between vehicles and nearby entities.
## Solution: MOTIVE
The key components of MOTIVE include beaconing, link prediction, scheduling, payment, and ratings. We implemented the beaconing functionality using WiFi's AdHoc feature. Whenever a MOTIVE device comes in contact with another MOTIVE device, the devices establish a link and exchange the provided and required services. The ratings smart contract in Ethereum, which consists of three functions to add a new user to the MOTIVE eco-system, get the rating of an existing user, and rate an user after a transaction. We implemented a client application for handling the \textbf{payment and recording} the transactions using Ethereum and Web3.

## License
Copyright (c) 2019, USC Viterbi Center for Cyber-Physical Systems and Internet of Things (CCI) and Autonomous Networks Research Group (ANRG), USC. See [this](LICENSE.txt) file for more details.
