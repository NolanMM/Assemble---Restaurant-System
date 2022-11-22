using System;
using System.Collections.Generic;
using static Assemble___Restaurant_System.Inventory_Stub_Class;

namespace Assemble___Restaurant_System
{
    public static class Inventory_Functions
    {
        static public void Checking_Inventory()
        {
            LinkedList<Inventory_Food> list_food = Read_The_Inventory_From_File();
            Console.WriteLine("The Inventory\n");
            foreach (Inventory_Food food in list_food)
            {
                Console.WriteLine("@Name: " + food.getNameFood() + " " + "@Portions:" + food.getPortionFood());
                Console.WriteLine("\n");
            }
        }
        static public LinkedList<Inventory_Food> Read_The_Inventory_From_File()
        {
            LinkedList<Inventory_Food> temp_List_In_Inventory = new LinkedList<Inventory_Food>();
            Inventory_Food inventory_Food_node = new Inventory_Food();

            /* @ Loop through all the line in the file...................................*/
            var lines = File.ReadLines("Inventory.txt");
            foreach (var line in lines)
            {
                /* Store the Name of the food in the Split_List_Item_Food[0] (String)....*/
                /* Store the Portion of the food in the Split_List_Item_Food[1] (String).*/
                string[] Split_List_Item_Food = line.Split('-');

                /* Store information of the food into the node of the list of the food...*/
                inventory_Food_node.setNameFood(Split_List_Item_Food[0]);
                bool temp1 = int.TryParse(Split_List_Item_Food[1], out int Portions);
                if (temp1 == true)
                {
                    inventory_Food_node.setPortionFood(Portions);
                }
                /* | Add the node to the list of the food in the fridge..................*/
                temp_List_In_Inventory.AddFirst(inventory_Food_node);
            }
            return temp_List_In_Inventory;
        }

        static public bool Checking_Specific_Item_In_Inventory()
        {
            string name_item;
            LinkedList<Inventory_Food> list_food = Read_The_Inventory_From_File();
            int number_of_items = list_food.Count();
            bool flag = false;
            Inventory_Food find_item = new Inventory_Food();
            Console.WriteLine("Please enter the name of the item you want to check correctly: ");
            name_item = Console.ReadLine();
            foreach (Inventory_Food food in list_food)
            {
                if (food.getNameFood() == name_item)
                {
                    find_item = food;
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                }
            }
            if (flag == true)
            {
                /* @ Using switch instead of else if statement for practice new method 
                /* @ The Code below equal with 
                /* @ if(find_item.getPortionFood() == 0 ){
                /* @    Console.WriteLine("The item: " +find_item.getNameFood() + " is empty inside the fridge\n"); 
                /* @ }
                /* @ else{ 
                /* @    Console.WriteLine("Found item in the fridge\n");
                /* @    Console.WriteLine("@Name: " + find_item.getNameFood() + " " + "@Portions:" + find_item.getPortionFood());
                /* @ }*/

                switch (find_item.getPortionFood())
                {
                    case 0:
                        Console.WriteLine("The item: " + find_item.getNameFood() + " is empty inside the fridge\n");
                        break;
                    default:
                        Console.WriteLine("Found item in the fridge\n");
                        Console.WriteLine("@Name: " + find_item.getNameFood() + " " + "@Portions:" + find_item.getPortionFood());
                        break;
                }
                
            }
            else
            {
                
                Console.WriteLine("The item not in the list\n");
            }
            return flag;
            
        }
    }
}