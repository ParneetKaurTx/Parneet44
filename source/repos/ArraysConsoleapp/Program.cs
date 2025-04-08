// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void Main()
    {
        List<String> Array_of_Str = [];
        while (true)
        {
            Console.WriteLine("1. Prints the List");
            Console.WriteLine("2. Search the element in list");
            Console.WriteLine("3. Sort the list");
            Console.WriteLine("4. Merge the list");
            Console.WriteLine("0. Exit the program");





            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                Array_of_Str = GetPrintList();
            }
            else if (option == 2)
            {
                SearchElement(Array_of_Str);
            }
            else if (option == 3)
            {
                Array_of_Str = SortArray(Array_of_Str);
                PrintArray(Array_of_Str);
            }
            else if (option == 4)
            {
                Array_of_Str = MergeLists(Array_of_Str);
                PrintArray(Array_of_Str);
            }
            else if (option == 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("enter any other choice");
            }


        }







    }

    static string[] GetPrintList()
    {
        string[] Array_of_Str = new string[4];

        int n = Array_of_Str.Length;
        Console.WriteLine("enter your respective four strings:");

        for (int i = 0; i < n; i++)
        {
            Array_of_Str[i] = Console.ReadLine();
            Console.WriteLine("Your string of Arrays are: " + Array_of_Str[i]);
        }

        Console.Write("Your str of array is: [");
        for (int j = 0; j < n; j++)
        {
            Console.Write(Array_of_Str[j]);
            if (j < Array_of_Str.Length - 1) Console.Write(", ");
        }
        Console.WriteLine("]");

        return Array_of_Str;
    }


    static void SearchElement(string[] Array_of_Str)
    {
        Console.WriteLine("please enter your target:");
        string target = Console.ReadLine();
        for (int i = 0; i < Array_of_Str.Length; i++)
        {
            if (Array_of_Str[i] == target)
            {
                Console.WriteLine($"Found at {i}");
                return;
            }
        }
        Console.WriteLine("Not found");

    }

    static string[] SortArray(string[] Array_of_str)
    {
        Console.WriteLine("choose the order either 1(ascending) or 2(descending)");
        int order = int.Parse(Console.ReadLine());



        int n = Array_of_str.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if ((order == 1 && Array_of_str[j].CompareTo(Array_of_str[j + 1]) > 0) || (order == 2 && Array_of_str[j].CompareTo(Array_of_str[j + 1]) < 0))
                {
                    string temp = Array_of_str[j];
                    Array_of_str[j] = Array_of_str[j + 1];
                    Array_of_str[j + 1] = temp;
                }
            }
        }





        return Array_of_str;

    }


    static void PrintArray(string[] Array_of_Str)
    {
        Console.Write("Array: [ ");
        for (int i = 0; i < Array_of_Str.Length; i++)
        {
            Console.Write(Array_of_Str[i]);
            if (i < Array_of_Str.Length - 1) Console.Write(", ");
        }
        Console.WriteLine(" ]");
    }



    static string[] MergeLists(string[] Array_of_Str)
    {
        // Step 1: Ask user for second list input
        Console.WriteLine("Enter values for the second list:");
        string[] secondList = GetPrintList();  // Get user input for second list

        // Step 2: Create a new array to hold merged values
        int totalLength = Array_of_Str.Length + secondList.Length;
        string[] mergedList = new string[totalLength];

        // Step 3: Copy first list into merged list
        for (int i = 0; i < Array_of_Str.Length; i++)
        {
            mergedList[i] = Array_of_Str[i];
        }

        // Step 4: Copy second list into merged list
        for (int i = 0; i < secondList.Length; i++)
        {
            mergedList[Array_of_Str.Length + i] = secondList[i];
        }

        // Step 5: Sort the merged list and return it
        return SortArray(mergedList);
    }






}
