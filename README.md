1. AddUser(Only Admin Account)
-> can be used to add new Driving Licence to the Smart Contract. If the private key / ethereum address of the JS File is Changed the Contract will throw an error as new Numbers can only be added by the admin(creator of the smart contract).
-> executed by node adduser.js


2. AddRating
-> can be used to add rating for a driver's licence number , accepts three parameters :
#Licence number of the user who is rating
#Licence nummber of the user to be rated
#Rating from 0-5
-> executed by node addrating.js

3. GetRating
-> can be used to return the rating for a particular licence number , accepts one parameter:
#Licence number of the user whose rating is to be fetched.
-> executed by node getrating.js
