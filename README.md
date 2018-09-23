# Online Book Shop API


## Getting Started

These instructions will get you a copy of the project up and running on your local machine. Please follow the steps bellow to run the application locally.

### Prerequisites
```
MySQL server 8
.NET Core 2.1
```

Please create MySQL Global Gaming database (you can find creation script in database.sql)


## Project Structure:
 ### Entities
 Project that contains all Models. All Daabase tables are mapped in Entity objects.
 ### ServiceExtensions
 Added in the API, to extend the api with additional services, configured on project startap
 ### Repository
 Project that contains all Repositories. Main logic implemented using MySQl. Additionally here it is added agregate repository for Purchase and Purchase Items.
 ### Repository wrapper
 Wraps all repositories.
 
 ### Controllers
 #### BooksController
 ```
 api/Books 
 Get() 
 (Returns all available books)
 
 api/Books 
 Post([FromBody] Books book) 
 (Creates new book)
 ```
#### UsersController
 ```
api/users/{UserId} 
Get(string UserId) 
(Returns user by user id)
 
 api/users/RegisterUser/{user} 
 RegisterUser([FromBody] Users user) 
 (Registers user to the platform)
 
 [FromBody]:
		{
		UserId:"holina",
		Name: "Horhe Linard",
		Address: "S.Pietru 11",
		City: "Sliema",
		ZIP: "1000",
		Country: "Malta",
		email: "holina@gmail.com",
		Registred: "1"
 		}
                

api/users/UpdateUser/{OldUserid}
UpdateUser(string OldUserid, [FromBody] Users user) 
(Updates user details)

api/users/UnRegisterUser/{UserId}
UnRegisterUser(string UserId)
(Unregister user from the platform)
 ```
#### PurchaseController

```
 api/purchase/{userId}
 PurchaseHistory(string Userid) 
 (Lists all items from purchase history for user)
 
 api/purchase/{userid}
 PurchaseBooks(string Userid, [FromBody] IList<PurchaseItems> purchaseItems)
 (Purchase books from the store)
 
 [FromBody]:
 	[
		{
		PurchaseItemId: "0",
		Purchase: "0",
		Book: "AA123",
		qty: "1",
		UnitPrice: "0",
		Note: ""
		},
		{
		PurchaseItemId: "0",
		Purchase: "0",
		Book: "PTR234",
		qty: "1",
		UnitPrice: "0",
		Note: ""
		}
	]
 ```
	
	

## Logging
Custom logger service is implemented for the needs of this solution, achieved by using NLog, a logging platform which will help us create and log our massages.
