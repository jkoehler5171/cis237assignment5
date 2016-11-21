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
    class WineItemCollection : IWineCollection
    {
        //Private Variables
        BeverageJKoehlerEntities _bevs;
        

        //Constructor for the WineItemCollection
        public WineItemCollection(BeverageJKoehlerEntities Bevs)
        {
            _bevs = Bevs;           
        }

        //Add a new item to the collection
        public void AddNewItem(string id, string description, string pack, string price, string availability)
        {
            //Create a new Beverage Item
            Beverage newBev = new Beverage();

            //Assign information to the new Beverage that was passed in from the user interface.
            newBev.id = id;
            newBev.name = description;
            newBev.pack = pack;
            newBev.price = Convert.ToDecimal(price);

            bool isActive = false;

            if(availability == "True")
            {
                isActive = true;
            }

            newBev.active = isActive;

            //Attempts to add the new beverage based on the information input above
            try
            {
                _bevs.Beverages.Add(newBev);

                _bevs.SaveChanges();

                Console.WriteLine();
                Console.WriteLine(newBev.ToString());
                Console.WriteLine();
                Console.WriteLine("Beverage added!");

            }

            //If it fails, it will let you know.
            catch (Exception e)
            {
                _bevs.Beverages.Remove(newBev);

                Console.WriteLine("Unable to add new Beverage item!");
            }


        }
        

        //Updates a database item based on it's ID.
        public void UpdateItem(string id, string description, string pack, string price, string availability)
        {
            //Checks to see if there is an existing item to update.
            Beverage updatedBev = _bevs.Beverages.Find(id);

            //Information passed in from the User Interface.
            updatedBev.name = description;
            updatedBev.pack = pack;
            updatedBev.price = Convert.ToDecimal(price);

            bool isActive = false;

            if (availability == "True")
            {
                isActive = true;
            }

            updatedBev.active = isActive;

            //Attempts to update an existing database item using the information above.
            try
            {
                _bevs.SaveChanges();

                Console.WriteLine();
                Console.WriteLine(updatedBev.ToString());
                Console.WriteLine();
                Console.WriteLine("Beverage updated!");


            }
            //Let's you know if it didn't work.
            catch (Exception e)
            {
                Console.WriteLine("Unable to update Beverage Item!");
            }

        }


        //Uses an ID to find and remove a Database item.
        public void RemoveItem(string id)
        {
            //Finds the item to be removed by the ID passed in from the user interface.
            Beverage removedBev = _bevs.Beverages.Find(id);

            if (removedBev != null)
            {
                Console.WriteLine();
                Console.WriteLine(removedBev.ToString());
                Console.WriteLine();
                Console.WriteLine("Beverage will be removed!");

                //Removes the item and saves the changes.
                _bevs.Beverages.Remove(removedBev);

                _bevs.SaveChanges();
            }
            else
            {
                Console.WriteLine("No such beverage found!");
            }
        }

        //Get The Print String Array For All Items
        public string[] GetPrintStringsForAllItems()
        {
            //Create and array to hold all of the printed strings
            string[] allItemStrings = new string[_bevs.Beverages.Count()];
            //set a counter to be used
            int counter = 0;            
            
                //For each item in the collection
                foreach (Beverage bev in _bevs.Beverages)
                {
                    //Add the results of calling ToString on the item to the string array.
                    allItemStrings[counter] = bev.ToString();
                        counter++;                    
                }
            
            //Return the array of item strings
            return allItemStrings;
        }

        //Find an item by it's Id
        public string FindById(string id)
        {
            ////Declare return string for the possible found item
            string returnString = null;

            //Searches for an item by its id.
            Beverage foundBev = _bevs.Beverages.Find(id);

            //If it finds something it will return it
            if (foundBev != null)
            {
                returnString = foundBev.ToString();
            }

            //Or just spit out nothing.
            return returnString;

        }

    }
}
