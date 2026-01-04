using BankOOPProject.Classes;
using System;
namespace BankOOPProject
{




    internal class Program
    {

        static string ShowMainMenu()
        {

            Console.WriteLine("=================================");
            Console.WriteLine("BANK MANAGEMENT SYSTEM");
            Console.WriteLine("=================================");
            Console.WriteLine("[1] Show All Clients");
            Console.WriteLine("[2] Add New Client");
            Console.WriteLine("[3] Find Client");
            Console.WriteLine("[4] Delete Client");
            Console.WriteLine("[5] Transfer Money");
            Console.WriteLine("[6] Deposit  amount");
            Console.WriteLine("[7] Withdraw amount");
            Console.WriteLine("[8] Edit Client");
            Console.WriteLine("[9] Exit");

            Console.Write(" Choose an option: ");


            return Console.ReadLine();

        }


        static void Main(string[] args)
        {


            clsBankSystem.LoadClientsFromFile();

            bool Exit = false;

            while (!Exit)
            {

                string choice = ShowMainMenu();



                switch (choice)
                {

                    case "1":
                        {

                            clsBankSystem.ShowAllClients();

                            break;
                        }




                    case "2":
                        {
                            clsBankSystem.AddNewClient();
                            clsBankSystem.SaveClientsToFile();
                            break;


                        }
                    case "3":
                        {

                            string accountnumber;
                            Console.WriteLine("Enter the account number: ");
                            accountnumber = Console.ReadLine();

                            clsClient found = clsBankSystem.FindClientByAccountNumber(accountnumber);

                            if (found != null)
                            {

                                found.PrintInfo();
                            }
                            else
                            {
                                Console.WriteLine("Client Not Found");
                            }

                            break;

                        }
                    case "4":
                        {
                            Console.WriteLine("Enter account number to delete:");
                            string deleteAccountNumber = Console.ReadLine();



                            bool IsDeleted = clsBankSystem.DeleteClientByAccountNumber(deleteAccountNumber);

                            if (IsDeleted == true)
                            {
                                Console.WriteLine("Client deleted successfully.");
                                clsBankSystem.SaveClientsToFile();

                            }
                            else
                            {
                                Console.WriteLine("Client was not deleted.");
                            }


                            break;

                        }
                    case "5":
                        {
                            clsBankSystem.TransferMoney();
                            clsBankSystem.SaveClientsToFile();
                            break;

                        }
                    case "6":
                        {

                            Console.WriteLine("Enter the account number: ");
                            string accountnumber = Console.ReadLine();

                            clsClient client = clsBankSystem.FindClientByAccountNumber(accountnumber);

                            if (client != null)
                            {


                                double amount = clsBankSystem.ReadNumber("Enter amount to deposit: ");


                                client.Deposit(amount);
                                clsBankSystem.SaveClientsToFile();

                            }
                            else
                            {

                                Console.WriteLine("Client Not Found");

                            }
                            break;

                        }
                    case "7":
                        {
                            Console.WriteLine("Enter the account number: ");
                            string accountnumber = Console.ReadLine();


                            clsClient client = clsBankSystem.FindClientByAccountNumber(accountnumber);

                            if (client != null)
                            {


                                double amount = clsBankSystem.ReadNumber("Enter the amount: ");


                                client.Withdraw(amount);
                                clsBankSystem.SaveClientsToFile();

                            }
                            else
                            {
                                Console.WriteLine("Client Not Found");
                            }

                            break;
                        }
                    case "8":
                        {

                            clsBankSystem.EditClientByAccountNumber();
                            clsBankSystem.SaveClientsToFile();
                            break;

                        }

                    case "9":
                        {
                            clsBankSystem.SaveClientsToFile();
                            Exit = true;
                            break;
                           
                        }


                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
            }

            Console.WriteLine();

        }


    }



}
    



