# SOLID Principles in C#

This project demonstrates the **SOLID principles** in object-oriented programming using C# with a payment processing example.

##  Project Overview
The project shows how different payment methods (Esewa, Khalti, Bank Transfer) can be implemented using **interfaces** and **dependency inversion** to achieve loosely coupled and scalable code.

##  Implemented SOLID Principles
1. **S - Single Responsibility Principle (SRP)**  
   - Each class has one job (e.g., `EsewaPayment` only handles Esewa payments).  

2. **O - Open/Closed Principle (OCP)**  
   - New payment methods can be added without modifying existing code.  

3. **L - Liskov Substitution Principle (LSP)**  
   - Any `IPayment` implementation should be replaceable in `PaymentProcessor` without breaking functionality.  
   - Example: `BankTransferPayment` throws an exception for amounts > 10000, which **violates LSP**.  

4. **I - Interface Segregation Principle (ISP)**  
   - Instead of forcing a large interface (Pay, Refund, Schedule), smaller, focused interfaces are created:  
     - `IPayment`  
     - `IRefundable`  
     - `ISchedulable`  

5. **D - Dependency Inversion Principle (DIP)**  
   - `PaymentProcessor` depends on the abstraction `IPayment` rather than concrete classes like `EsewaPayment`.  
   - This makes the code flexible and easy to extend.
