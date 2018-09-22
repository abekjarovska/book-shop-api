# book-shop-api
Online Book Shop


1. Create MySQL Global Gaming database 
 **you can find creation script in database.sql

2. Project Structure:
 ** Entities: project that contains all Models -> mapps all Daabase tables in Entity objects
 ** ServiceExtensions: Added in the API, to extend the api with additional services, configured on peoject startap
 ** Repository: Project that contains all Repositories -> Main logic implemented using MySQl; 
							  Additionally is added agregate repository for Purchase and Purchase Items
 ** Repository wrapper: Wraps all repositories.
 ** Controllers: 
  	BooksController
	api/Books
 	Get() - Returns all available books 
    	api/Books
	Post([FromBody] Books book) - Creates new book	
	
	UsersController
	api/users/{UserId}
	Get(string UserId) - Returns user by user id
	api/users/RegisterUser/{user}
	RegisterUser([FromBody] Users user) - Registers user to the platform
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
	UpdateUser(string OldUserid, [FromBody] Users user) - Updates user details
	api/users/UnRegisterUser/{UserId}
	UnRegisterUser(string UserId) - Unregister user from the platform
	
	PurchaseController
	api/purchase/{userId}
	PurchaseHistory(string Userid) - Lists all items from purchase history for user
	api/purchase/{userid}
	PurchaseBooks(string Userid, [FromBody] IList<PurchaseItems> purchaseItems) - Purchase books from the store
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


