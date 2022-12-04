
using System;
using System.Collections.Generic;

namespace Assemble___Restaurant_System
{
    public static class Price_Module_Functions
    {
        public static void Price()
        {
            {
                // Path of file
                string path = @"Price.txt";

                // Ask for Item with Price (ex. "apple 1.99")
                Console.WriteLine("Add Item with Price: ");

                string input = Console.ReadLine();
                string[] words = input.Split(' ');

                string item = words[0];
                string price = words[1];

                bool exists = false;
                if (File.Exists(path))
                {
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string content;
                        while ((content = sr.ReadLine()) != null)
                        {
                            if (content.Contains(item))
                            {
                                exists = true;
                                Console.WriteLine("Error, item already exists.");
                            }
                        }
                    }
                }

                // If file does not exist, create the file, then add the Item and Price text onto it
                // else simply append

                if (!exists)
                {
                    File.AppendAllText(path, item + " " + price + "\n");
                }


                // Prints out everything from the file line by line
                Console.WriteLine(File.ReadAllText(path));
            }
        }


        public static void Edit_Price()
        {
            string path = @"Price.txt";

            // Ask for the Item the user want to change the price for.

            Console.WriteLine("Enter Item Name to Change its Price: ");

            string input = Console.ReadLine();

            string item = input;


            bool exists = false;
            int index;
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string content;
                    for (index = 0; (content = sr.ReadLine()) != null; ++index)
                    {
                        if (content.Contains(item))
                        {
                            exists = true;
                            break;
                        }
                    }
                }
                if (!exists)
                {
                    throw new Exception("Item does not exist.");
                }
                else
                {
                    string[] lines = File.ReadAllLines(path);
                    Console.WriteLine("Enter the Price to change");
                    string price = Console.ReadLine();
                    lines[index] = item + " " + price;
                    File.WriteAllLines(path, lines);
                }
            }
        }


        public static void Delete_Price()
        {

            string path = @"Price.txt";

            // Ask the user which coupon they want to delete
            Console.WriteLine("Enter Item to Delete: ");

            string item = Console.ReadLine();

            bool exists = false;
            int index;
            if (item == "")
            {
                return;

            }
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string content;
                    for (index = 0; (content = sr.ReadLine()) != null; ++index)
                    {
                        if (content.Contains(item))
                        {
                            exists = true;
                            break;
                        }
                    }
                }
                if (!exists)
                {
                    throw new Exception("Coupon does not exist.");
                }
                else
                {
                    string[] lines = File.ReadAllLines(path);
                    File.Delete(path);
                    for (int i = 0; i < lines.Count(); i++)
                    {
                        if (i != index)
                        {
                            File.AppendAllText(path, lines[i] + "\n");

                        }

                    }
                }
            }

        }

        public static void Coupon()
        {


            // Path of file
            string path = @"Coupon.txt";

            // Ask for Coupon Name (ex. "Dec2019")
            Console.WriteLine("Enter Coupon to Add to system: ");

            string coupon = Console.ReadLine();



            bool exists = false;
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string content;
                    while ((content = sr.ReadLine()) != null)
                    {
                        if (content.Contains(coupon))
                        {
                            exists = true;
                            Console.WriteLine("Error, Coupon already exists.");
                        }
                    }
                }
            }

            // If file does not exist, create the file, then add Coupon text onto it
            // else simply append

            if (!exists)
            {
                File.AppendAllText(path, coupon + "\n");
            }


            // Prints out everything from the file line by line
            Console.WriteLine(File.ReadAllText(path));
        }

        public static void Edit_Coupon()
        {
            string path = @"Coupon.txt";

            // Ask the user which coupon they want to change

            Console.WriteLine("Enter Coupon to Change: ");

            string input = Console.ReadLine();

            string coupon = input;
            string NewCoupon;

            bool exists = false;
            int index;
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string content;
                    for (index = 0; (content = sr.ReadLine()) != null; ++index)
                    {
                        if (content.Contains(coupon))
                        {
                            exists = true;
                            break;
                        }
                    }
                }
                if (!exists)
                {
                    throw new Exception("Coupon does not exist.");
                }
                else
                {
                    string[] lines = File.ReadAllLines(path);
                    Console.WriteLine("Enter New Coupon to change");
                    NewCoupon = Console.ReadLine();
                    lines[index] = NewCoupon;
                    File.WriteAllLines(path, lines);
                }

            }
        }


        public static void Delete_Coupon()
        {
            string path = @"Coupon.txt";

            // Ask the user which coupon they want to delete
            Console.WriteLine("Enter Coupon to Delete: ");

            string coupon = Console.ReadLine();

            bool exists = false;
            int index;
            if (coupon == "")
            {
                return;

            }

            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string content;
                    for (index = 0; (content = sr.ReadLine()) != null; ++index)
                    {
                        if (content.Contains(coupon))
                        {
                            exists = true;
                            break;
                        }
                    }
                }
                if (!exists)
                {
                    throw new Exception("Coupon does not exist.");
                }
                else
                {
                    string[] lines = File.ReadAllLines(path);
                    File.Delete(path);
                    for (int i = 0; i < lines.Count(); i++)
                    {
                        if (i != index)
                        {
                            File.AppendAllText(path, lines[i] + "\n");
                        }
                    }
                }

            }

        }
    }
}