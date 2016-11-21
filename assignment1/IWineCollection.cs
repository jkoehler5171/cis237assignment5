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
    interface IWineCollection
    {
        void AddNewItem(string id, string description, string pack, string price, string availability);

        void UpdateItem(string id, string description, string pack, string price, string availability);

        void RemoveItem(string id);

        string[] GetPrintStringsForAllItems();

        string FindById(string id);
    }
}
