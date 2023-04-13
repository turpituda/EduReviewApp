# EduReviewApp
This C# ASP.NET Core web API app facilitates the submission and approval of academic papers between students and professors.

# Routes

## Users (only admins can access this endpoints)

+ **​/api​/Users** GET all users
+​ **/api​/Users** POST register a new user
+​ **/api​/Users​/{id}** PUT update a user
+ **​/api​/Users​/{id}** GET one user
+ **​/api​/Users​/{id}** DELETE a user

## Login (allowed anonymus access)

+ **​/api​/Login** POST credentials

## Courses 
+ **​/api​/Courses** GET all courses
+ **​/api​/Courses** POST create a new course
+ **​/api​/Courses​/{id}** PUT update a course
+ **​/api​/Courses​/{id}** GET one course
+ **​/api​/Courses​/{id}** DELETE a course

## Submissions
+ **​/api​/Submissions** GET all submissions
+ **​/api​/Submissions** POST create a new submission
+ **​/api​/Submissions​/{id}** GET a submission

## Submission upload
+ **​/api​/FileUpload​/AddSubmission** POST a submission file