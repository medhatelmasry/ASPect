# ASPect

## Table of Contents

- [Introduction](#01)
- [Install](#02)
- [Usage](#03)
- [Architecture](#04)
- [Features](#05)
- [Preview](#06)
- [Tools](#07)
- [Contributor](#8)

#

## <span id="01">Introduction</span>

The project was created for BCIT COMP4870 courses. The project is intened to help instructors assign and manage students projects in a way that students can also evaluate their teammates under student project dashboard.

The front-end will be separated into two parts where a React client application for student project management, and Blazor for instructors side management.

#

## <span id="02">Install</span>

To run the project locally, first clone this project in your local machine. The the react and blazor application can be run separately.

```code
git clone https://github.com/medhatelmasry/ASPect.git
```

Run the blazor application

```code
cd BlazorClient
dotnet watch run
```

Run the react application

```code
cd ReactClient/ClientApp
npm start
```

#

## <span id="03">Usage</span>

The project is also deployed on azure with the following links

**React Client**: https://aspectclient.z5.web.core.windows.net/

**Blazor Client**: https://blaspect.azurewebsites.net/

**MVC App**: https://openaspect.azurewebsites.net/

#

## <span id="04">Architecture</span>

<img src="https://cdn.discordapp.com/attachments/786151530478436380/831766887666548756/unknown.png" />

#

## <span id="05">Features</span>

### Students

- Students register with email & password using ASP.NET Identity Framework
- Students need to navigate into their project creation screen for a particular course, they need a list of courses they are associated with
- Students should tell the instructor which team he/she want to join and the instructor creates teams
- Students can submit and edit weekly update for specific project only if they are currently in that week
- Students can access a dated log of previously completed
- Student can reset password

### Instructors

- Instructors register with email & password
- Instructor creates student roles (ex COMP3717-2021-Fall)
- Instructor can re-organize team members in a project
- Instructors assign students to roles.
- Instructors can set up student access to the system
- Instructor publish project requirements with dated milestones & deadlines
- Instructor can view and edit teams by course and project
- Instructors can track progress of all projects
- Instructor can move a student from a team to another team
- Instructor can reset password

### Superuser

- Super user can setup instructor access to the system
- Manage authorization roles - assign instructors to roles
- Default superuser is username: admin password: admin, seeded in the database
- Instructions for people who download open-source how to make themselves the super user

#

## <span id="06">Preview</span>

_Student List View for Instructors_

<img src="https://cdn.discordapp.com/attachments/786151530478436380/831772387304407040/1.png" width="80%"/>

<br />

_Instructor Reset Password View_

<img src="https://cdn.discordapp.com/attachments/786151530478436380/831772387535487007/2.png" width="80%"/>

<br />

_Student Applciation Login View_

<img src="https://cdn.discordapp.com/attachments/786151530478436380/831772388550508544/3.png" width="80%"/>

<br />

_Assignments screen_

<img src="https://cdn.discordapp.com/attachments/814651656075608105/832159866193838080/Screen_Shot_2021-04-15_at_12.45.07_AM.png" width="80%"/>

<br />

_Viewing Requirements of an Assignment_

<img src="https://cdn.discordapp.com/attachments/814651656075608105/832159782990643200/unknown.png" width="80%"/>

<br />

#

## <span id="07">Tools</span>

- C#
- React
- Blazor
- .NET Web API
- SQLite
- Figma

#

## <span id="08">Contributors</span>

###

<div>
    <a href="https://github.com/Tblack10"><img src="https://avatars.githubusercontent.com/u/22111795?v=4" width="100px" height="100px" style="border-radius:50%"/></a>
    <a href="https://github.com/sung981216"><img src="https://avatars.githubusercontent.com/u/56126874?v=4" width="100px" height="100px" style="border-radius:50%"/></a>
    <a href="https://github.com/jstyle5"><img src="https://avatars.githubusercontent.com/u/54833010?v=4" width="100px" height="100px" style="border-radius:50%"/></a>
    <a href="https://github.com/yogiduzit"><img src="https://avatars.githubusercontent.com/u/40650969?v=4" width="100px" height="100px" style="border-radius:50%"/></a>
    <a href="https://github.com/John9V"><img src="https://avatars.githubusercontent.com/u/56142023?v=4" width="100px" height="100px" style="border-radius:50%"/></a>
    <a href="https://github.com/rickywychoi"><img src="https://avatars.githubusercontent.com/u/36054824?v=4" width="100px" height="100px" style="border-radius:50%"/></a>
    <a href="https://github.com/Danielhongjin"><img src="https://avatars.githubusercontent.com/u/37917799?v=4" width="100px" height="100px" style="border-radius:50%"/></a>
    <a href="https://github.com/Dkim257"><img src="https://avatars.githubusercontent.com/u/43056313?v=4" width="100px" height="100px" style="border-radius:50%"/></a>
    <a href="https://github.com/Maxumane"><img src="https://avatars.githubusercontent.com/u/60531843?v=4" width="100px" height="100px" style="border-radius:50%"/></a>
    <a href="https://github.com/AbeerHaroon"><img src="https://avatars.githubusercontent.com/u/43453761?v=4" width="100px" height="100px" style="border-radius:50%"/></a>
    <a href="https://github.com/AlirezaKakan"><img src="https://avatars.githubusercontent.com/u/45620847?v=4" width="100px" height="100px" style="border-radius:50%"/></a>
    <a href="https://github.com/wizard-adamkay"><img src="https://avatars.githubusercontent.com/u/37917852?v=4" width="100px" height="100px" style="border-radius:50%"/></a>
    <a href="https://github.com/yang052513"><img src="https://avatars.githubusercontent.com/u/52589538?v=4" width="100px" height="100px" style="border-radius:50%"/></a>
    <a href="https://github.com/CiroGuangchengWen"><img src="https://avatars.githubusercontent.com/u/54955984?v=4" width="100px" height="100px" style="border-radius:50%"/></a>
</div>
