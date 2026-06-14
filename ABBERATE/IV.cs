using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static Dictionary<string, string> LoginPasswordEmployees =
            new Dictionary<string, string>()
            {
                { "admin", "admin" },
                { "user1", "password1" },
                { "jepetek", "WoreMyWhore12" },
                { "deZolance", "LotteEE" },
                { "user2", "password2" },
                { "VolunteerAutumn", "12212010M" }
            };

        static void Main()
        {
            while (true)
            {
                string loggedInUser = Login();

                if (loggedInUser == null)
                    continue;

                if (loggedInUser == "admin")
                    AdminMenu();
                else
                    UserMenu(loggedInUser);
            }
        }

        static string Login()
        {
            Console.WriteLine("\n=== LOGIN ===");

            Console.Write("Login: ");
            string login = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (LoginPasswordEmployees.TryGetValue(login, out string storedPassword))
            {
                if (storedPassword == password)
                {
                    Console.WriteLine("Login successful!");
                    return login;
                }
            }

            Console.WriteLine("Invalid login or password.");
            return null;
        }

        static void AdminMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== ADMIN MENU ===");
                Console.WriteLine("1. View all accounts");
                Console.WriteLine("2. Add account");
                Console.WriteLine("3. Remove account");
                Console.WriteLine("4. Change password");
                Console.WriteLine("5. Find password");
                Console.WriteLine("6. Logout");

                Console.Write("Choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        foreach (var item in LoginPasswordEmployees)
                        {
                            Console.WriteLine($"{item.Key} : {item.Value}");
                        }
                        break;

                    case 2:
                        Console.Write("New login: ");
                        string newLogin = Console.ReadLine();

                        if (LoginPasswordEmployees.ContainsKey(newLogin))
                        {
                            Console.WriteLine("Login already exists.");
                            break;
                        }

                        Console.Write("New password: ");
                        string newPassword = Console.ReadLine();

                        LoginPasswordEmployees.Add(newLogin, newPassword);

                        Console.WriteLine("Account added.");
                        break;

                    case 3:
                        Console.Write("Login to remove: ");
                        string removeLogin = Console.ReadLine();

                        if (removeLogin == "admin")
                        {
                            Console.WriteLine("Cannot remove admin account.");
                            break;
                        }

                        if (LoginPasswordEmployees.Remove(removeLogin))
                            Console.WriteLine("Account removed.");
                        else
                            Console.WriteLine("Login not found.");

                        break;

                    case 4:
                        Console.Write("Login: ");
                        string changeLogin = Console.ReadLine();

                        if (LoginPasswordEmployees.ContainsKey(changeLogin))
                        {
                            Console.Write("New password: ");
                            LoginPasswordEmployees[changeLogin] = Console.ReadLine();
                            
                            if (string.IsNullOrEmpty(LoginPasswordEmployees[changeLogin]))
                            {
                                Console.WriteLine("Password cannot be empty.");
                                break;
                            }

                            Console.WriteLine("Password changed.");
                        }
                        else
                        {
                            Console.WriteLine("Login not found.");
                        }

                        break;

                    case 5:
                        Console.Write("Login: ");
                        string searchLogin = Console.ReadLine();

                        if (LoginPasswordEmployees.TryGetValue(searchLogin, out string password))
                            Console.WriteLine($"Password: {password}");
                        else
                            Console.WriteLine("Login not found.");

                        break;

                    case 6:
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void UserMenu(string username)
        {
            Console.WriteLine($"\nWelcome, {username}!");
            Console.WriteLine("You do not have administrator privileges.");
            Console.WriteLine("Press ENTER to logout...");
            Console.ReadLine();
        }
    }
}

// I think I cooked lmao
