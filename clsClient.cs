using System;
using System.Collections.Generic;


namespace BankOOPProject.Classes
{
    public class clsClient
    {
        string _AccountNumber;
        string _PinCode;
        string _Name;
        string _Phone;
        double _Balance;

        public string AccountNumber
        {
            get
            {
                return _AccountNumber;
            }
        }
        public string PinCode
        {

            get { return _PinCode; }

            set { _PinCode = value; }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        public double Balance
        {
            get { return _Balance; }
            private set { _Balance = value; }
        }


        public clsClient(string accountnumber, string pincode, string name, string phone, double balance)
        {
            _AccountNumber = accountnumber;
            _PinCode = pincode;
            _Name = name;
            _Phone = phone;
            _Balance = balance;
        }



        public void PrintInfo()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Account Number :  ".PadRight(20) + AccountNumber);
            Console.WriteLine("PinCode        :  ".PadRight(20) + PinCode);
            Console.WriteLine("Name           :  ".PadRight(20) + Name);
            Console.WriteLine("Phone          :  ".PadRight(20) + Phone);
            Console.WriteLine("Balance        :  ".PadRight(20) + Balance);


            Console.WriteLine("-------------------------------------");
        }



        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("The amount must be greater than zero");
                return;
            }

            _Balance += amount;


            Console.WriteLine($"Deposit successful.");
            Console.WriteLine($"New Balance = {Balance}");

        }

        public bool Withdraw(double amount)
        {

            if (amount <= 0)
            {
                Console.WriteLine("The amount must be greater than zero");
                return false;
            }
            else if (amount > Balance)
            {
                Console.WriteLine("Insufficient balance.");
                return false;
            }
            else
            {
                _Balance -= amount;

                Console.WriteLine($"Withdrawn amount = {amount}");
                Console.WriteLine($" New Balance = {Balance}");

                return true;

            }

        }
    }
}
