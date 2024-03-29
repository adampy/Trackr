# Trackr Client
The client app I submitted for my A-Level Computer Science Non-Exam-Assessment (AQA 2021). The client app that accompanies the API - a Python Quart app - which was designed to be provisioned on Heroku. The client only works for a single college/school, and therefore all form titles and pictures are specific to my college.

# Overview
This is a client program, called Trackr, that I created for my A-Level CS NEA admission alongside the API. When both are running together, Trackr can be used to allow teachers to log on, create students and create groups/classes for the students to be part of and assign homework tasks to these classes. The students camn log on and see the groups they are part of as well as their homeworks. Teachers can mark the homeworks using the application and store their students marks on the application. Once teachers have marked theses pieces of classwork, students can log on and see the mark that they have been awarded.

# Installation
**API**
1. Create a Heroku account
2. Fork the [API repository](https://github.com/adampy/quartapp)
3. Create a new Heroku app and link it to your new fork
4. On the same app, provision a new PostgreSQL database
5. Set an environment variable, `DATABASE_URL`, in Heroku, to your DB URI
6. Set another environent variable, `ADMIN`, to an arbitrary code that only the the admin staff will remember/have access to
6. Start the Dyno

**Client**
1. Clone the repository
2. Open in Visual Studio, and install the Newtonsoft package
3. Provide the Dyno's URL to the client app's `WebRequestHandler.apiRoot`


# Skills I learnt
- The role interfaces play within OOP code and the UI
- Singly linked lists in practice
- Creating custom UI elements
- Web request and JSON handling (asynchronous code) in C# using Newtonsoft
- Designing, creating, and managing a RESTful API built using Flask
- Database provision, the use of foreign keys, and join tables
- How sensitive data is managed and the importance of keeping up to date with security practises
  - Salting passwords before hashing them with a secure hash to prevent the use of rainbow tables
  - Using SHA256 which is cryptographically secure as of early 2021
  - Preventing timing attacks on the admin code
- RESTful API constraints including HATEOAS

# Features I would have implemented if I had more time
- Notification system which notifies the user when they have had homework assigned or marked
- File system, potentially using Amazon S3 buckets, that would allow students to upload files for the teacher to see
- Allow multiple schools to use the system - at the moment it is bespoke
