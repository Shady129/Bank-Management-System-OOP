# 🏦 Bank Management System (C# Console Application)

A console-based banking management system built using C# and Object-Oriented Programming (OOP).
The project simulates a simple real-world bank system where clients can be managed, balances updated,
and data stored persistently using text files.

============================================================

✨ FEATURES

- 👤 Add new clients with validation
- 🔍 Find clients by account number
- 📋 Show all clients
- ✏️ Edit client information (except balance)
- ❌ Delete clients
- 💰 Deposit money
- 💸 Withdraw money
- 🔁 Transfer money between clients
- 💾 Save and load data from text file
- 🛡️ Input validation (account number and pin code)

============================================================

🧠 VALIDATION RULES

Account Number:
- Digits only
- Maximum 5 digits
- Must be unique

Pin Code:
- Digits only
- Maximum 4 digits

============================================================

🛠️ TECHNOLOGIES USED

- C#
- .NET Console Application
- Object-Oriented Programming (OOP)
- Collections (List<T>)
- File Handling (System.IO)

============================================================

📂 PROJECT STRUCTURE

BankOOPProject
│
├── Program.cs
│   - Handles the main menu and user interaction
│
├── clsBankSystem.cs
│   - Core system logic (add, delete, edit, transfer, file handling)
│
├── clsClient.cs
│   - Client model (properties, deposit, withdraw)
│
└── Client.txt
    - Stores client data persistently

============================================================

💾 DATA STORAGE FORMAT

Each client is stored in the text file using the following format:

AccountNumber#PinCode#Name#Phone#Balance

Each line represents one client.

============================================================

🧪 MANUAL TESTING (SUMMARY)

- Add client with valid data
- Prevent duplicate account numbers
- Validate account number and pin code input
- Deposit and withdraw with valid and invalid amounts
- Transfer money between two different accounts
- Prevent transfer to the same account
- Load data correctly on program start
- Save data on every update and on exit

============================================================

🚀 HOW TO RUN

1. Open the project in Visual Studio
2. Make sure it is set as a Console Application
3. Run the project
4. Follow the on-screen menu instructions

============================================================

📌 FUTURE IMPROVEMENTS

- Add login system (Admin / Client)
- Encrypt pin codes
- Replace text file with a database
- Add transaction history
- Improve console user experience

============================================================

👨‍💻 AUTHOR

Developed as a learning project to practice clean code,
object-oriented programming, console application design,
and input validation.

⭐ If you like this project, feel free to star it on GitHub!
