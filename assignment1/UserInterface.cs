//Jordan Koehler
//TR 3:30- 5:45
//November 21st 2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class UserInterface
    {
        const int maxMenuChoice = 7;
        //---------------------------------------------------
        //Public Methods
        //---------------------------------------------------

        //Display Welcome Greeting
        public void DisplayWelcomeGreeting()
        {
            Console.WriteLine("Welcome to the wine program");
        }

        //Display Menu And Get Response
        public int DisplayMenuAndGetResponse()
        {
            //declare variable to hold the selection
            string selection;

            //Display menu, and prompt
            this.displayMenu();
            this.displayPrompt();

            //Get the selection they enter
            selection = this.getSelection();

            //While the response is not valid
            while (!this.verifySelectionIsValid(selection))
            {
                //display error message
                this.displayErrorMessage();

                //display the prompt again
                this.displayPrompt();

                //get the selection again
                selection = this.getSelection();
            }
            //Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        //Get the search query from the user
        public string GetSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to search for?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        //Get New Item Information From The User.
        public string[] GetNewItemInformation()
        {
            Console.WriteLine();
            Console.WriteLine("What is the new items Id?");
            Console.Write("> ");
            string id = Console.ReadLine();
            Console.WriteLine("What is the new items Description?");
            Console.Write("> ");
            string description = Console.ReadLine();
            Console.WriteLine("What is the new items Pack?");
            Console.Write("> ");
            string pack = Console.ReadLine();
            Console.WriteLine("What is the items Price?");
            Console.Write("> ");
            string price = Console.ReadLine();
            Console.WriteLine("Is the item Available?");
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
            string availability = "False";
            int choice = Convert.ToInt32(Console.ReadLine());
            if(choice == 1)
            {
               availability = "True";
            }    

            return new string[] { id, description, pack, price, availability };
        }

        //Display Import Success
        public void DisplayImportSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("Wine list has been imported successfully from the database");
        }

        //Display Import Error
        public void DisplayImportError()
        {
            Console.WriteLine();
            Console.WriteLine("There was an error connecting to the database");
        }

        //Display All Items
        public void DisplayAllItems(string[] allItemsOutput)
        {
            Console.WriteLine();
            foreach (string itemOutput in allItemsOutput)
            {
                Console.WriteLine(itemOutput);
            }
        }

        //Display All Items Error
        public void DisplayAllItemsError()
        {
            Console.WriteLine();
            Console.WriteLine("There are no items in the list to print");
        }

        //Display Item Found Success
        public void DisplayItemFound(string itemInformation)
        {
            Console.WriteLine();
            Console.WriteLine("Item Found!");
            Console.WriteLine(itemInformation);
        }

        //Display Item Found Error
        public void DisplayItemFoundError()
        {
            Console.WriteLine();
            Console.WriteLine("A Match was not found");
        }

        //Display Add Wine Item Success
        public void DisplayAddWineItemSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The Item was successfully added");
        }

        //Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError()
        {
            Console.WriteLine();
            Console.WriteLine("An Item With That Id Already Exists");
        }

        //Displays the options for updating an item.
        public string[] DisplayItemUpdateOptions()
        {            
            Console.WriteLine();
            Console.WriteLine("Enter the id of the item you wish to update");
            Console.Write("> ");
            string id = Console.ReadLine();
            Console.WriteLine("Enter a new description");
            Console.Write("> ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter a new pack size");
            Console.Write("> ");
            string pack = Console.ReadLine();
            Console.WriteLine("Enter a new price");
            Console.Write("> ");
            string price = Console.ReadLine();
            Console.WriteLine("Is the item Available?");
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
            string availability = "False";
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                availability = "True";
            }

            return new string[] { id, description, pack, price, availability };
        }

        //Displays the dialogue about removing an item.
        public string DisplayItemRemovalDialogue()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the ID of the item you wish to remove");
            return Console.ReadLine();
        }


        //---------------------------------------------------
        //Private Methods
        //---------------------------------------------------

        //Display the Menu
        private void displayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Check Wine Database Connection");
            Console.WriteLine("2. Print The Entire List Of Items");
            Console.WriteLine("3. Search For An Item");
            Console.WriteLine("4. Add New Item To The List");
            Console.WriteLine("5. Update an item in the list");
            Console.WriteLine("6. Remove an item from the list");
            Console.WriteLine("7. Exit Program");
        }

        //Display the Prompt
        private void displayPrompt()
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
        }

        //Display the Error Message
        private void displayErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine("That is not a valid option. Please make a valid choice");
        }

        //Get the selection from the user
        private string getSelection()
        {
            return Console.ReadLine();
        }

        //Verify that a selection from the main menu is valid
        private bool verifySelectionIsValid(string selection)
        {
            //Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                //Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                //If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= maxMenuChoice)
                {
                    //set the return value to true
                    returnValue = true;
                }
            }
            //If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                //set return value to false even though it should already be false
                returnValue = false;
            }

            //Return the reutrnValue
            return returnValue;
        }
    }
}
