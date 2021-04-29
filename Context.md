# Project Context
AND Dekker has acquired a new client called Shalek Kavy. They have local coffee shops around England and want to step up their game by going Digital. AND team needs to help them by building their Backend services for their digital store which will power up their mobile apps and website.

# Requirements:
1. The client has a diverse menu of hot beverages. Admin should be able to define the following properties per beverage: 
  - Id
  - Name
  - Description
  - Type - coffee, tea, soft drink 
  - Ingredients
  - Allergens
  - Date Created
  - Date Modified 
2. The API should be able to return all beverages, as well as filter beverages by type
3. The API should also be able to return full details for a specific beverage - this includes, date created, ingredients
---
4. The business decided that they will need to add additional details about the beverages in order to grow their business model further. The details are:
  - Price 
  - Availability - Available, Unavailable
  - Size - Small, Regular, Large 
    - Each size will have allocated pricing:
      - Small = -0.50
      - Regular = 0
      - Large = 1
5. In order to allow clients to customize their beverages the business decided to add add-ons which clients will be able to add on top of the beverage they select for their order. The add-ons will have the following details:
  - Id
  - BeverageId - Beverage this addon relates to
  - Name
  - Availability - Available, Unavailable
  - Type - Add-in, Topping, Flavour, Sweeteners
  - Price 
  - Date Created
  - Date Modified
6. The back-end should provide endpoints to add/delete/update beverages and add-ons. 
7. Before a new Beverage is added or updated it needs to be validated based on the following criteria:
  - Name - REQUIRED
  - Description - REQUIRED
  - Type - Valid type
  - Ingredients - RERQUIRED
  - Allergens - OPTIONAL
  - Price - REQUIRED, Valid Price > 0
  - Availability - Valid availability
  - Size - Valid Size
8. Before a new addon is added it needs to be validated based on the following criteria:
  - BeverageId - Valid and existing beverage
  - Name - REQUIRED
  - Availability - REQUIRED, Valid Availability
  - Type - REQUIRED, Valid Type
  - Price - REQUIRED, Valid price > 0
9. Once the requirements above are met the business feels confident that they can start selling their products so they want to introduce Addiing Orders in their system. 
  - Each order can have multiple items. Each item will need the following details:
    - Id
    - Quantity
    - Size
    - Notes - optional
    - Addons - list of addons user can add to their beverage. 
  - Each addon will have the following details:
    - Id
    - Amount
  - The order should also include address details:
    - Name of recipient 
    - Address Line 1
    - Address Line 2
    - Postcode
    - City
  - The order will also include total amount of the whole order
10. Whenever a new order is requested, the back-end is responsible to make the following validations:
  - All Beverages are valid and available at the time of the order
  - All Add-ons are valid and available at the time of the order
  - Each add-on has a valid quantity > 0
  - All address details are required and filled correctly
  - The total amount send with the request should match the total amount re-calculated by the back-end.
---
11. Authentication - TBC