# kaspi.kz-clone
Full backend and frontend clone of the number one fintech app in Kazakhstan kaspi.kz<br/>
Application was built for only practice purposes!

# Briefly about the development process

Backend will be in microservice architecture <br/>
Each microservice will be implemented by CQRS (Command Query Responsibility Segregation) pattern

## For the phase 1
Microservice will interact with web client<br/>
Overall architecture of application
## For the phase 2
Microservice will interact with mobile client in Kotlin <br/>
Overall architecture of application

# Microservice documentation
API endpoints 
## Banking Service

## UsersController

## Get User By Id

### Request: HttpGet
    /api/v1/users/1
### Response:
    Status: 200 Created
    {
    "id": 1,
    "firstName": "John",
    "lastName": "Doe",
    "iin": "001207103076",
    "birthDate": "2000-12-07T16:02:43.381Z",
    "role": "Customer",
    "email": "john_doe@email.com",
    "telephone": "87077177777",
    "photoUrl": "https://api.kaspi-clone.kz/images/1",
    "accounts": [
      {
        "id": 1,
        "balance": 1990.00,
        "currency": "KZT",
        "bankName": "AO Kaspi Bank",
        "iban": "KZ32790C026877647168",
        "bic": "CASPKZKA",
        "iin": "001207103076",
        "customer": "John Doe",
        "userId": 1
      },
      {
        "id": 2,
        "balance": 35000.00,
        "currency": "KZT",
        "bankName": "AO Kaspi Bank",
        "iban": "KZ37097C703741350801",
        "bic": "CASPKZKA",
        "iin": "001207103076",
        "customer": "John Doe",
        "userId": 1
      }
    ]
  }`
