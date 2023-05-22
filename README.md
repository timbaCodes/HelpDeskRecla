# HelpDeskRecla
Graded Assignment
EPI - GL4
Naoufel KHAYATI 1
Graded Assignment - ASP.NET Core
"Development of a HelpDesk Web Application"
A HelpDesk, also known as IT support, is a service center composed of qualified IT technicians who are attentive to users' requests regarding hardware and/or software issues (such as PC problems, printers, disks, cameras, servers, messaging, internet connection, etc.).
The primary objective of an IT support is to facilitate the daily operations of a company in managing and utilizing its IT infrastructure. The role of this support is to resolve IT issues and ensure maximum operational continuity.
This assignment is proposed within this context.
The goal is to develop a HelpDesk Web application that allows users to submit complaints to technicians who will be responsible for resolving the problems.

Required Task
There are two roles: User and Technician.
1.1. User
The user is responsible for CRUD operations on complaints. For example, once logged into the application using their account, they can:
Create a new complaint and describe the nature of the problem (the complaint should have a unique code).
Track the status of their complaint (not yet processed, in progress, resolved, no solution, etc.).
Edit or delete a complaint only if its status is "not yet processed." Otherwise, they cannot edit or delete it.
Once their complaint has been marked as "processed," they can approve it (if everything is OK) or disapprove it (if they are not satisfied).
1.2. Technician
Once authenticated, the technician should be able to:
View all complaints and filter them by user and status.
Graded Assignment
Naoufel KHAYATI 2
Update the status of the complaint (in progress, problem resolved, etc.).
Record the corrective actions taken (repair of defective hardware, software installation, on-site visit, remote computer control, scheduling a meeting, etc.).
Close a complaint once it has been approved by the requester.
Note:
A complaint can only be related to a single user. However, a user can submit multiple complaints.
A technician can handle multiple complaints. A complaint is only assigned to a single technician.
A complaint displayed on the technician's screen should clearly indicate the name of the user who created it.
Technologies to Use
It is recommended to work with all or some of the following:
ASP.NET Core 6.0 using the MVC model
C# language
Entity Framework
SQL Server DBMS
