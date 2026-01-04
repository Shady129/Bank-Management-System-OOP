using System;
using System.IO;
using System.Collections.Generic;


namespace BankOOPProject.Classes
{
    public class clsBankSystem
    {



        static string filePath = "Clients.txt";

        static List<clsClient> clsClients = new List<clsClient>();


      public static clsClient FindClientByAccountNumber(string accountNumber)
        {

            foreach (clsClient client in clsClients)
            {

                if (client.AccountNumber == accountNumber)
                {

                    return client;
                }


            }
            return null;
        }


        public static clsClient AddNewClient()
        {

            string accountnumber;


            do
            {
                Console.WriteLine("Enter the account number (max 5 digits): ");
                accountnumber = Console.ReadLine();


                if(!accountnumber.All(char.IsDigit) || accountnumber.Length > 5)
                {

                    Console.WriteLine("Account number must be digits only and not more than 5 digits.");
                    continue;
                }
                        

                if (FindClientByAccountNumber(accountnumber) != null)
                {
                    Console.WriteLine("This account number already exists, please enter a new one.");
                }
            }
            while (!accountnumber.All(char.IsDigit) || accountnumber.Length > 5 || FindClientByAccountNumber(accountnumber) != null);


            string pincode;

            do
            {

                Console.WriteLine("Enter the Pin Code:");
                pincode = Console.ReadLine();



                if (!pincode.All(char.IsDigit) || pincode.Length > 4)
                {
                    Console.WriteLine("Pin Code must be digits only and not more than 4 digits.");
                }
            }
            while (!pincode.All(char.IsDigit) || pincode.Length > 4);




            Console.WriteLine("Enter the Name:");
            string name = Console.ReadLine();


            Console.WriteLine("Enter the Phone:");
            string phone = Console.ReadLine();


            double balance = ReadNumber("Enter the balance: ");


            clsClient client = new clsClient(accountnumber, pincode, name, phone, balance);
            clsClients.Add(client);

            Console.WriteLine("Client Added Successfully!");


            return client;


        }




        public static bool DeleteClientByAccountNumber(string accountNumber)
        {

            clsClient client = FindClientByAccountNumber(accountNumber);


            if (client == null)
            {
                Console.WriteLine("Client not found. Cannot delete.");

                return false;
            }

            clsClients.Remove(client);

            Console.WriteLine("Client deleted successfully!");

            return true;

        }


        public static void EditClientByAccountNumber()
        {

            Console.WriteLine("Enter account number to edit: ");
            string accountnumber = Console.ReadLine();

            clsClient client = FindClientByAccountNumber(accountnumber);


            if (client == null)
            {

                Console.WriteLine("Client not found!");
                return;
            }

            Console.WriteLine("\n--- Current Client Info ---");
            client.PrintInfo();


            Console.WriteLine("\nWhat do you want to edit?");
            Console.WriteLine("[1] Pin Code");
            Console.WriteLine("[2] Name");
            Console.WriteLine("[3] Phone");
            Console.WriteLine("[4] (Not Allowed) Balance");
            Console.WriteLine("[5] Cancel");


            Console.WriteLine("Choose an option: ");
            string choice = Console.ReadLine();


            switch (choice)
            {


                case "1":
                    {
                        Console.WriteLine("Enter new Pin Code: ");
                        client.PinCode = Console.ReadLine();
                        Console.WriteLine("Pin Code updated successfully!");
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Enter new Name: ");
                        client.Name = Console.ReadLine();
                        Console.WriteLine("Name updated successfully!");
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Enter new Phone: ");
                        client.Phone = Console.ReadLine();
                        Console.WriteLine("Phone updated successfully");
                        break;


                    }

                case "4":
                    {
                        Console.WriteLine("Balance cannot be edited directly. Use Deposit/Withdraw!");
                        break;
                    }


                case "5":
                    {
                        Console.WriteLine("Edit cancelled.");
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Invalid choice.");
                        break;
                    }

            }

            Console.WriteLine("\n--- Updated Client Info ---");
            client.PrintInfo();
        }



        public static void TransferMoney()
        {

            Console.WriteLine("Enter sender's account number: ");
            string senderAccountNumber = Console.ReadLine();

            Console.WriteLine("Enter receiver's account number: ");
            string receiverAccountNumber = Console.ReadLine();


            if (senderAccountNumber == receiverAccountNumber)
            {
                Console.WriteLine("Sender and receiver account numbers cannot be the same.");

                return;
            }


            clsClient senderClient = FindClientByAccountNumber(senderAccountNumber);
            clsClient receiverClient = FindClientByAccountNumber(receiverAccountNumber);



            if (senderClient == null)
            {

                Console.WriteLine("Sender client not found!");
                return;
            }

            if (receiverClient == null)
            {

                Console.WriteLine("Receiver client not found!");
                return;

            }



            double amount = ReadNumber("Enter amount to transfer:");


            if (amount <= 0)
            {

                Console.WriteLine("The amount must be greater than zero.");
                return;
            }


            bool IsWithdrawn = senderClient.Withdraw(amount);

            if (!IsWithdrawn)
            {

                Console.WriteLine("Transfer failed. Please check sender balance or amount.");
                return;

            }

            receiverClient.Deposit(amount);
            Console.WriteLine("Transfer completed successfully!");


            Console.WriteLine("\n--- Sender Client Info After Transfer ---");
            senderClient.PrintInfo();


            Console.WriteLine("\n--- Receiver Client Info After Transfer ---");
            receiverClient.PrintInfo();

        }



        public static void SaveClientsToFile()
        {
            List<string> lines = new List<string>();

            foreach (clsClient client in clsClients)
            {

                string line =

                 client.AccountNumber + "#" +
                 client.PinCode + "#" +
                 client.Name + "#" +
                 client.Phone + "#" +
                 client.Balance;

                lines.Add(line);

            }

            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Clients saved to file successfully.");
        }


        public static void LoadClientsFromFile()
        {


            clsClients.Clear();


            if (!File.Exists(filePath))
            {

                Console.WriteLine("Clients file not found. You will need to enter clients manually.");
                return;

            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {

                if (string.IsNullOrWhiteSpace(line))

                    continue;


                string[] parts = line.Split('#');

                if (parts.Length != 5)

                    continue;


                double balance;


                if (!double.TryParse(parts[4], out balance))
                {

                    Console.WriteLine($"Invalid balance value in file for account: {parts[0]}");
                    continue;

                }

                clsClient client = new clsClient(

                    parts[0],
                    parts[1],
                    parts[2],
                    parts[3],
                    balance);

                clsClients.Add(client);

            }
            Console.WriteLine("Clients loaded from file successfully.");
        }



       public static void ShowAllClients()
        {


            if (clsClients.Count == 0)
            {

                Console.WriteLine("No clients found.");
            }
            else
            {

                foreach (clsClient client in clsClients)
                {
                    client.PrintInfo();
                }
            }
        }


        public static double ReadNumber(string message)
        {

            double number;
            Console.Write(message);

            while (!double.TryParse(Console.ReadLine(), out number))
            {

                Console.WriteLine("Invalid number, please try again.");
                Console.Write(message);
            }

            return number;
        }
    }
}

