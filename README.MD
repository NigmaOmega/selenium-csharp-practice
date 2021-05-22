# Test case information

## DemoBlaze site

### Cart feature

Setup:

- User login successfully

Test cases:

Test case 1: AddProductToCart_Successfully

- HomePage
  - Go to Home Page
  - Go to Product Details Page with product name
- Product Details Page
  - Add product to cart
  - Go to Cart Page with
- Cart Page
  - Verify product is added into cart

### HomePage feature

Setup:

- User login successfully

Test cases:

Test case 1: DisplayListItem_FollowingCategory_Correctly

- HomePage
  - Go to Home Page
  - Select category
  - Verify product information is display correctly by category
    - Name
    - Price
    - Description

### Login feature

Setup:

- Home Page
  - Go to Home Page
  - Open login popup

Test cases:

Test case 1: Login_Successfully

- Home Page
  - Login with valid username and password
  - Verify user is logged in

Test case 2: Login_WithoutUsername_ErrorMessage

- Home Page
  - Login with empty username and a password
  - Verify error message should be shown "Please fill out Username and Password."

Test case 3: Login_WithoutPassword_ErrorMessage

- Home Page
  - Login with valid username and empty password
  - Verify error message should be shown "Please fill out Username and Password."

Test case 4: Login_WithIncorrectPassword_ErrorMessage

- Home Page
  - Login with valid username and empty password
  - Verify error message should be shown "Wrong password."

Test case 5: Login_WithNotExistUsername_ErrorMessage

- Home Page
  - Login with not exist username and a password
  - Verify error message should be shown "User does not exist."

### Product Details feature

Setup:

- Home Page
  - Go to Home Page
  - Open login popup

Test case 1: AccessProductDetails_Successfully

- Home Page
  - Go to Home Page
  - Access product details with product information
  - Verify product details is shown correctlly

### SignUp feature

Test cases 1: SignUp_Successfully

- Home Page
  - Go to Home Page
  - Open Sign up Popup
- Sign Up Page
  - Sign up with valid username and password
- Home Page
  - Verify message is shown "Sign up successful."

Test cases 2: SignUp_WithoutUsername_ErrorMessage

- Home Page
  - Go to Home Page
  - Open Sign up Popup
- Sign Up Page
  - Sign up with empty username and valid password
- Home Page
  - Verify message is shown "Please fill out Username and Password."

Test cases 3: SignUp_WithoutPassword_ErrorMessage

- Home Page
  - Go to Home Page
  - Open Sign up Popup
- Sign Up Page
  - Sign up with valid username and empty password
- Home Page
  - Verify message is shown "Please fill out Username and Password."

Test cases 4: SignUp_WithExistanceUsername_ErrorMessage

- Home Page
  - Go to Home Page
  - Open Sign up Popup
- Sign Up Page
  - Sign up with exist username and valid password
- Home Page
  - Verify message is shown "Please fill out Username and Password."

## SauceDemo site

### The Cart feature

Setup:

- Login Page
  - Go to Login Page
  - Login with valid username and password

Test case 1: AccessToCart_Successfully

- Cart Page
  - Go to Cart Page
  - Verify Page is display successfully

Test case 2: AddItemIntoCart_Successfully

- Inventory Page
  - Go to Inventory Page
  - Add to cart an product
- Cart Page
  - Go to Cart Page
  - Verify the item is added in the cart

Test case 3: RemovetemFromCart_Successfully

- Inventory Page
  - Go to Inventory Page
  - Add to cart an product
- Cart Page
  - Go to Cart Page
  - Remove the product in cart
  - Verify the product is removed

Test case 4: ContinueShopping_Successfully

- Inventory Page
  - Go to Inventory Page
  - Add to cart an product
- Cart Page
  - Go to Cart Page
  - Click on Continue Shopping button
  - Verify the Inventory Page is displayed

Test case 4: Checkout_Successfully

- Inventory Page
  - Go to Inventory Page
  - Add to cart an product
- Cart Page
  - Go to Cart Page
  - Click on Checkout button
  - Verify the Check Out Step One Page is displayed successfully

### Checkout feature

Setup:

- Login Page
  - Go to Login Page
  - Login with valid username and password

Test case 1: OrderItem_Successfully

- Inventory Page
  - Go to Inventory Page
  - Add a product into cart
- Cart Page
  - Go to Cart Page
  - Checkout
- Step One Page
  - Fill valid data and continue
- Step Two Page
  - Verify Checkout Step Two Page is display successfully
  - Verify product information is shown successfully
  - Finish
- Complete Page
  - Verify Complete Page is displayed successfully
  - Verify Items is orderd Successfully

Test case 2: CancelItemInStepOneCheckOut_Successfully

- Inventory Page
  - Go to Inventory Page
  - Add a product into cart
- Cart Page
  - Go to Cart Page
  - Checkout
- Step One Page
  - Cancel
- Cart Page
  - Verify Cart PAge is displayed successfully

Test case 2: CancelItemInStepTwoCheckOut_Successfully

- Inventory Page
  - Go to Inventory Page
  - Add a product into cart
- Cart Page
  - Go to Cart Page
  - Checkout
- Step One Page
  - Fill valid data and continue
- Step Two Page
  - Cancel
- Inventory Page
  - Verify Inventory Page is display successfully

### Inventory feature

Setup:

- Login Page
  - Go to Login Page
  - Login with valid username and password

Test case 1: AccessInventoryPage_Successfully

- Inventory Page
  - Go to Inventory Page
  - Verify this page is visible

Test case 2: DisplayValidInventoryItems_Successfully

- Inventory Page
  - Go to Inventory Page
  - Verify this page have correct number of item is 6
  - Verify this page have valid information of inventory item

Test case 3: SortProducByNameAToZ_Successfully

- Inventory Page
  - Go to Inventory Page
  - Sort products by name A to Z
  - Verify items is sort by Name A to Z

Test case 4: SortProducByNameZToA_Successfully

- Inventory Page
  - Go to Inventory Page
  - Sort products by name Z to A
  - Verify items is sort by Name Z to A

Test case 5: SortProducByPriceLowToHigh_Successfully

- Inventory Page
  - Go to Inventory Page
  - Sort products by price low to high
  - Verify items is sort by price low to high

Test case 6: SortProducByPriceHighToLow_Successfully

- Inventory Page
  - Go to Inventory Page
  - Sort products by price high to low
  - Verify items is sort by price high to low

Test case 7: AddProductToCart_Successfully

- Inventory Page
  - Go to Inventory Page
  - Add a product to cart
  - Verify the item is added to cart

Test case 8: RemoveProductFromCart_Successfully

- Inventory Page
  - Go to Inventory Page
  - Add a product to cart
  - remove the product from cart
  - Verify the item is remove from cart

### Inventory Item feature

Setup:

- Login Page
  - Go to Login Page
  - Login with valid username and password
- Inventory Page
  - Go to Inventory Page
  - Go to Inventory Details Page of a valid product

Test case 1: AccessInventoryItem_Successfully

- Inventory Item Page
  - Verify page displays correct item
  - Verify page displays content correctly

Test case 2: AddToCartItem_Successfully

- Inventory Item Page
  - Add to cart item
  - Verify the item is added to cart

Test case 3: RemoveItemFromCart_Successfully

- Inventory Item Page
  - Add to cart item
  - Remove that item from cart
  - Verify the item is added to cart

Test case 4: BackToInventoryPage_Successfully

- Inventory Item Page
  - Back to Inventory Page
- Inventory Page
  - Verify this page is visible

### The Login feature

Test case 1: Login_Successfully

- Login Page
  - Go to Login Page
  - Login with valid username and password
- Inventory Page
  - Verify this page is visible

Test case 2: Login_WithLockOutUser_ErrorMessageShown

- Login Page
  - Go to Login Page
  - Login with locked username
  - Verify error message is "Epic sadface: Sorry, this user has been locked out."

Test case 3: Login_WithEmptyUsername_ErrorMessageShown

- Login Page
  - Go to Login Page
  - Login with empty username
  - Verify error message is "Epic sadface: Username is required"

Test case 4: Login_WithEmptyPassword_ErrorMessageShown

- Login Page
  - Go to Login Page
  - Login with empty password
  - Verify error message is "Epic sadface: Password is required"

Test case 5: Login_WithIncorrectPassword_ErrorMessageShown

- Login Page
  - Go to Login Page
  - Login with incorrect password
  - Verify error message is "Epic sadface: Username and password do not match any user in this service"

Test case 5: Login_WithInvalidEmail_ErrorMessageShown

- Login Page
  - Go to Login Page
  - Login with invalid username
  - Verify error message is "Epic sadface: Username and password do not match any user in this service"

