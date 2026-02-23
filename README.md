Calculator API

A RESTful calculator API** built in **C# / .NET 7**, designed to perform basic arithmetic operations (`+`, `-`, `*`, `/`) with **error handling**, **validation**, and a clean, testable architecture using SOLID principles.  

This API is intended to be used by a frontend (e.g., Angular / TypeScript) to build a full-featured calculator.

---

## Features

- Basic arithmetic operations: Addition, Subtraction, Multiplication, Division
- Strong typing and validation with FluentValidation
- Error handling:
  - Division by zero
  - Invalid operation types
  - Invalid numeric inputs
- Factory pattern is used to dynamically select the correct arithmetic operation. Each operation is implemented as a strategy-like class with a common interface, making it easy to extend and maintain.
- Unit-testable and maintainable service layer
- Ready for integration with a frontend calculator UI

---

## Technology Stack

- Backend: .NET 7, C# 11
- Validation: FluentValidation
- Testing:** xUnit, Moq
- Design Patterns:Strategy, Factory, Dependency Injection
- API Type: RESTful, JSON

---

API Endpoint

 Calculate

**POST** `/api/calculator/calculate`

**Request Body**

`json
{
  "left": 10,
  "right": 5,
  "operation": "Addition" 
}
{
  "left": 10,
  "right": 5,
  "operation": "Subtraction" 
}
{
  "left": 10,
  "right": 5,
  "operation": "Multiplication" 
}
{
  "left": 10,
  "right": 5,
  "operation": "Division" 
} `

**## (Frontend) Tech**


React – UI components and state-driven rendering

TypeScript – Type safety for better maintainability

Redux Toolkit – Centralized state management for display, memory, and history

React-Redux Hooks – useAppDispatch and useAppSelector for interacting with the store

CSS / App Styling – Simple styles for layout, buttons, display, and history panel

API Integration – calculate function handles arithmetic operations asynchronously

**## Feature **
React – UI components and state-driven rendering

TypeScript – Type safety for better maintainability

Redux Toolkit – Centralized state management for display, memory, and history

React-Redux Hooks – useAppDispatch and useAppSelector for interacting with the store

CSS / App Styling – Simple styles for layout, buttons, display, and history panel

API Integration – calculate function handles arithmetic operations asynchronously
**
## NOTE**
RUN
**npm install** then
**npm run dev **

