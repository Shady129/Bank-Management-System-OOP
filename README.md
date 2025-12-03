# 🏦 Bank Management System (C# OOP Project)

## 📌 Overview
A simple **Bank Management System** built in **C#** using clean **Object-Oriented Programming (OOP)** concepts.  
The application runs in the console and allows you to manage clients, perform banking transactions, and automatically save all data to a text file.

---

## 🎯 Features

### 👥 Client Management
- ➕ Add New Client  
- 📋 Show All Clients  
- 🔎 Find Client by Account Number  
- ✏️ Edit Client Information  
- ❌ Delete Client  

### 💰 Banking Operations
- 💵 Deposit Money  
- 💳 Withdraw Money  
- 🔄 Transfer Money Between Clients  

### 💾 File Handling
- 📥 Load clients from a text file on startup  
- 📤 Save all updates automatically after each operation  
- 🗂 Keep data persistent between program runs  

---

## 🧱 Project Structure

```
📁 BankManagementSystem
│
├── Program.cs                 # Entry point & main menu
├── clsClient.cs               # Client class (Name, Balance, AccountNumber...)
├── clsBank.cs                 # Bank logic: add, delete, edit, find, transfer
├── clsFileManager.cs          # File read/write helper
├── clients.txt                # Stored client data
│
└── README.md                  # Documentation
```

---

## 🛠️ Technologies Used
- **C#**
- **OOP Principles (Encapsulation – Classes – Methods)**
- **File I/O (Text Files)**
- **Console Application**

---

## 🚀 How to Run

### Clone the repository:
```bash
git clone https://github.com/Shady129/Bank-OOP-Management-System.git
```

### Open the project:
- Open in **Visual Studio**  
- Build & Run → `Ctrl + F5`

---

## 🖥️ Example Output

```
===============================
   Bank Management System
===============================

1. Show All Clients
2. Add New Client
3. Find Client
4. Edit Client
5. Delete Client
6. Deposit
7. Withdraw
8. Transfer
9. Exit

Choose option: _
```

---



