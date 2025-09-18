# BuberDinner API
This document provides an overview of the BuberDinner API, including its endpoints, request and response formats, and authentication methods.

Table of contents
- [BuberDinner API](#buberdinner-api)
  - [Authentication](#authentication)
    - [Register](#register)
    - [Register Response](#register-response)

## Authentication

### Register
```json
{
  "url": "/auth/register",
  "method": "POST",
  "request": {
    "firstName": "string",
    "lastName": "string",
    "email": "string",
    "password": "string"
  },
  "response": {
    "token": "string"
  }
}
```
### Register Response
```json
{
  "status": 200,
  "token": "string"
}
```