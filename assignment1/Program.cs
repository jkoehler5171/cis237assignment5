//Jordan Koehler
//TR 3:30- 5:45
//November 21st 2016
//
//General Note: I based this off of your version of program one, with comments and all. I have deleted comments where they were attached to related code
//But I have not updated any other ones, so it may be a bit out of date in places.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates a new connection to the Database
            BeverageJKoehlerEntities bevEntities = new BeverageJKoehlerEntities();

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            //Create an instance of the WineItemCollection class
            IWineCollection wineItemCollection = new WineItemCollection(bevEntities);        
        

            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 7)
            {
                switch (choice)
                {
                    case 1:
                        //Check the Database Connection.
                        
                        if (bevEntities != null)
                        {
                            //Display Success Message
                            userInterface.DisplayImportSuccess();
                        }
                        else
                        {
                            //Display Fail Message
                            userInterface.DisplayImportError();
                        }
                        break;

                    case 2:
                        //Print Entire List Of Items
                        string[] allItems = wineItemCollection.GetPrintStringsForAllItems();
                        if (allItems.Length > 0)
                        {
                            //Display all of the items
                            userInterface.DisplayAllItems(allItems);
                        }
                        else
                        {
                            //Display error message for all items
                            userInterface.DisplayAllItemsError();
                        }
                        break;

                    case 3:
                        //Search For An Item
                        string searchQuery = userInterface.GetSearchQuery();
                        string itemInformation = wineItemCollection.FindById(searchQuery);
                        if (itemInformation != null)
                        {
                            userInterface.DisplayItemFound(itemInformation);
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;

                    case 4:
                        //Add A New Item To The List
                        string[] newItemInformation = userInterface.GetNewItemInformation();
                        if (wineItemCollection.FindById(newItemInformation[0]) == null)
                        {
                            wineItemCollection.AddNewItem(newItemInformation[0], newItemInformation[1], newItemInformation[2], newItemInformation [3], 
                                newItemInformation[4]);
                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;
                        //Update an existing item in the database
                    case 5:
                        string[] updatedItemInformation = userInterface.GetNewItemInformation();
                        if (wineItemCollection.FindById(updatedItemInformation[0]) == null)
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        else
                        {
                            wineItemCollection.UpdateItem(updatedItemInformation[0], updatedItemInformation[1], updatedItemInformation[2],
                                updatedItemInformation[3], updatedItemInformation[4]);
                            
                        }
                        break;
                        //Remove an existing item from the database
                    case 6:
                        string itemToRemove = userInterface.DisplayItemRemovalDialogue();

                        wineItemCollection.RemoveItem(itemToRemove);

                        break;
                    
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
