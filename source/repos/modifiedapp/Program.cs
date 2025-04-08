
using System;

using System.Collections.Generic;

namespace modifiedapp

{

    class GroceriesItem  //A CLASS IN WHICH THEIR ARE TWO MEMBERS WHICH ARE USED FURTHER IN LIST DYNAMICALLY

    {

        public string name { get; set; }

        public int quantity { get; set; }

        public GroceriesItem(string Name, int Quantity)

        {

            name = Name;

            quantity = Quantity;

        }

    }

    class GroceriesList

    {

        List<GroceriesItem> Items = new List<GroceriesItem>();
        ClassValidator Validator = new ClassValidator();

        public List<GroceriesItem> AddOperation(string name, int quantity)  //THIS IS A ADD OPERATION FOR ADDING THE LIST

        {
            if (!Validator.QuantityCheck(quantity) || !Validator.StringName(name))
            {
                return Items;  // If validation fails, return the current list without making changes
            }
            //Items.Find(x => x.name == name);
            foreach (var Item in Items)

                {

                    if (Item.name == name) //IF ITE IS IN THE LIST THEN INCREEMENT THE QUANTITY

                    {

                        Item.quantity += quantity;

                        Console.WriteLine($"Updated {name}: {Item.quantity}");

                        return Items;

                    }

                }

                Items.Add(new GroceriesItem(name, quantity)); // Add new item IF THEIR IS NO ITEM BEFORE IN THE LIST

                Console.WriteLine($"Added {name}: {quantity}");

                return Items;

            



           

        }

        public List<GroceriesItem> DeleteOperation(string name, int quantity)  //DELETE OPERATION

        {
            if (!Validator.StringName(name))
                return Items;

            for (int i = 0; i < Items.Count; i++)

            {

                if (Items[i].name == name)  //WHEN DELETE ITEM IS FOUND THEN QUANTITY WILL BE DECCREMENTED IF ONLY CONDITION SATISFIES

                {

                    if (Items[i].quantity > quantity) //means the quantity taht is in list should be greater than the entered quantity

                    {

                        Items[i].quantity -= quantity;

                        Console.WriteLine($"Decreased {name} to quantity: {quantity}");

                    }

                    else

                    {

                        Items.RemoveAt(i);  //REMOVE THE WHOLE ITEM

                        Console.WriteLine($"Removed {name} from list.");

                    }

                    return Items;

                }

            }

            Console.WriteLine($"No such item named {name} found.");

            return Items;

        }

        public void MergeList(List<GroceriesItem> newItems)//MERGE THE LIST OF ITEMS

        {

            foreach (var newItem in newItems)  //

            {

                bool found = false;

                for (int i = 0; i < Items.Count; i++)

                {

                    if (Items[i].name == newItem.name)

                    {

                        Items[i].quantity += newItem.quantity;

                        found = true;

                        break;

                    }

                }

                if (!found)

                {

                    Items.Add(newItem);

                }

            }

            Console.WriteLine("Lists merged successfully!");



            PrintList();

        }


        public List<GroceriesItem> SortingOperation(string name, int quantity) //SORTING OPERATION
        {
            Console.WriteLine("choose the order either 1(ascending) or 2(descending)");
            int order = int.Parse(Console.ReadLine());



            int n = Items.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if ((order == 1 && String.Compare(Items[j].name,Items[j + 1].name) > 0) || (order == 2 && String.Compare(Items[j].name, Items[j + 1].name) < 0))
                    {
                        GroceriesItem temp = Items[j];
                        Items[j] = Items[j + 1];
                        Items[j + 1] = temp;
                    }
                }
                


            }
            return Items;
        }

        public void PrintList()  //PRINTING METHOD SIMPLY PRINT THE LIST WHEN I CALL IT IN MAIN FUNC

        {

            Console.WriteLine("Updated Grocery List:");

            foreach (var item in Items)

            {

                Console.WriteLine($"{item.name}: {item.quantity}");

            }

        }

    }

    class Program

    {

        static void Main(string[] args)

        {

            GroceriesList groceryobj = new GroceriesList();

            while (true)

            {

                Console.WriteLine("1. Add an Item");

                Console.WriteLine("2. Delete an Item");

                Console.WriteLine("3. Merge Two Lists");
                Console.WriteLine("4. Sorting the list");
                Console.WriteLine("5. print the list");

                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice, please enter a number.");
                    continue;
                }

                if (choice == 1)

                {

                    Console.Write("Enter grocery name: ");

                    string name = Console.ReadLine();

                    Console.Write("Enter quantity: ");

                    int quantity = int.Parse(Console.ReadLine());

                    groceryobj.AddOperation(name, quantity);

                    groceryobj.PrintList();

                }

                else if (choice == 2)

                {

                    Console.Write("Enter grocery name to delete: ");

                    string name = Console.ReadLine();

                    Console.Write("Enter quantity to reduce: ");

                    int quantity = int.Parse(Console.ReadLine());

                    groceryobj.DeleteOperation(name, quantity);

                    groceryobj.PrintList();

                }

                else if (choice == 3)

                {

                    List<GroceriesItem> newItems = new List<GroceriesItem>();

                    Console.Write("Enter number of items to merge: ");

                    int itemCount = int.Parse(Console.ReadLine());

                    for (int i = 0; i < itemCount; i++)

                    {

                        Console.Write("Enter item name: ");

                        string name = Console.ReadLine();

                        Console.Write("Enter quantity: ");

                        int quantity = int.Parse(Console.ReadLine());

                        newItems.Add(new GroceriesItem(name, quantity));

                    }

                    groceryobj.MergeList(newItems);

                }

                else if (choice == 4)
                {
                    groceryobj.SortingOperation("name", 0);
                    groceryobj.PrintList();

                }

                else if (choice == 5)
                {
                    groceryobj.PrintList();
                }

                else if (choice == 0)

                {

                    break;

                }

                else

                {

                    Console.WriteLine("enter something else! Please try again.");

                }

            }

        }

    }

}


