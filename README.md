# Amount to Words Converter

This is a simple ASP.NET Core MVC application that accepts a numeric amount (with optional decimal values) and converts it into its string representation in words.

## Features
- Convert numbers up to billions into words.
- Supports handling decimal places (cents) for monetary amounts.
- Omits the cents part if no cents are provided (i.e., if the amount is an integer).
- User-friendly front-end using Bootstrap for styling.
- Dependency Injection is used to inject the number-to-words conversion logic.

## Technologies Used
- **ASP.NET Core MVC** for the web application framework.
- **C#** for the backend logic.
- **Bootstrap 4** for front-end design.
- **Dependency Injection** for registering services.
- **.NET Core** for the platform.

## Getting Started

### Prerequisites
- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet) (version 8)
- Visual Studio 2022 (or any IDE that supports .NET Core development)

### Project Setup

1. **Clone the repository:**
    ```bash
    https://github.com/guimcouto76/spinutech.git
    ```

2. Navigate to the project directory:
    ```bash
    cd amount-to-words-converter
    ```

3. Open the project in Visual Studio or your preferred IDE.

4. Restore NuGet packages:
- If using Visual Studio, the packages will restore automatically on build.
- Alternatively, use the command line:
    ```bash
    dotnet run
    ```

5. Run the application:
- Run the project directly from Visual Studio using Ctrl+F5.
- Or run it from the command line:
    ```bash
    dotnet run
    ```
6. **Navigate to the application**: Open your browser and go to http://localhost:{port}, where {port} is the port number specified by ASP.NET Core.

## Usage

1. Enter a numeric value (up to trillions) into the input field.
2. Click the **Convert** button.
3. The application will display the original number and its corresponding string representation in words.
    - If the number includes decimal values, the cents will be represented as "xx/100".
    - If there are no decimal values, the cents part will be omitted.

## Project Structure

AmountToWordsConverter/  
│  
├── Controllers/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└── HomeController.cs *(Handles HTTP requests and logic for amount conversion)*  
│  
├── Interfaces/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└── INumberToWordsConverter.cs  *(Interface for number-to-words conversion service)*  
│  
├── Models/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└── AmountModel.cs *(Model to store the amount and its string representation)*  
│  
├── Services/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└── NumberToWordsConverter.cs *(Service that converts numbers to words)*  
│  
├── Views/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└── Home/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└── Index.cshtml *(View for displaying the input form and result)*  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└── Shared/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├──_Layout.cshtml *(Layout page used to render consistent page structure)*  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└──Error.cshtml *(Error page for handling and displaying friendly error messages)*  
│  
├── appsettings.json *(Application settings)*  
└── Program.cs *(Configures services and application startup for .NET 8)*  

## Extensibility

- **Trillions and beyond**: The application currently supports numbers up to billions. You can extend it to handle higher magnitudes (trillions, quadrillions, quintillions, etc.) by modifying the NumberToWordsConverter.
- **Localization**: The conversion logic can be adapted for other languages by modifying the number-to-words mapping.


## Unit Tests
The project includes unit tests to ensure that both the NumberToWordsConverter service and the AmountController behave as expected.

### Test Frameworks Used
- xUnit: A widely used unit testing framework for .NET.
- Moq: A popular mocking framework for .NET, used to mock dependencies in unit tests (e.g., the INumberToWordsConverter service).

### Test Coverage
1. NumberToWordsConverter Service Tests:
    - These tests validate the logic of converting numbers into their word representation.
    - Key scenarios covered:
        - Positive numbers
        - Numbers with decimal values (cents)
        - Large numbers (up to trillions)
        - Negative numbers

2. AmountController Tests:
    - These tests ensure that the controller processes both GET and POST requests correctly and interacts with the INumberToWordsConverter service.
    - Mocking is used to simulate the behavior of the converter service without testing its implementation.

### How to Run Tests
To run the unit tests:
1. Open Visual Studio and navigate to the Test Explorer window.
2. Click Run All to execute all the tests.
3. You can also run the tests from the command line using:
```bash
dotnet test
```
All the tests should pass if the logic is implemented correctly, providing confidence that the service and controller are working as expected.

## Author

- **Name**: Guilherme Couto
- **Phone**: [321-312-9692](tel:321-312-9692)
- **Email**: [guimcouto76@gmail.com](mailto:guimcouto76@gmail.com)