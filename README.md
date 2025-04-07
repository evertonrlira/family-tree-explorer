- Prerequisites
    - Application runs on Visual Studio 2022 (VS), freely provided here: https://visualstudio.microsoft.com/downloads/
    - Application depends on .NET SDK 8, freely provided at: https://dotnet.microsoft.com/en-us/download/dotnet/8.0
    - Application also depends on NodeJs, freely provided at: https://nodejs.org/en/download


- Structure 
	- Family-Tree-Web-App is a Solution where:
		- Front-end was built using NextJS (Javascript)
		- Back-end was built on ASP.NET Core, following Clean Architecture
	- 'WEB' folder contains the frontend implementation
	- 'API' folder contains the backend implementation
	
    - The 'src' subfolder contains the following project folders:
		- 'FamilyTree.Api': Implementation of the api's outer layer (controllers)
		- 'FamilyTree.Contracts': Defines the format of requests accepted by 'FamilyTree.Api' and response objects
		- 'FamilyTree.Application': Handles requests from 'FamilyTree.Api'
		- 'FamilyTree.Domain': Defines system entities ('Family' and 'Person')
		- 'FamilyTree.Infrastructure': Implements operations depending on access to the database	


- Setup Instructions
    - The backend can be executed from Visual Studio with the following steps:
	    1. Open the '.sln' file in 'API' folder
		2. Hit "start (without debug)"
		
	- The Frontend can be loaded with the following steps:
		1. Open a command prompt (CMD)
		2. Navigate to the 'WEB' folder
		3. Run 'npm install'. In case this fails due to conflicts with the local version of packs, run 'npm install --legacy-peer-deps'
		4. After dependencies are installed, run 'npm run dev'
		5. This should deploy the application. Please follow the url provided in a browser to navigate


- Additional Remarks
	- Persistence was done using SqlLite. The database is cleared and re-seeded every time the application is loaded
	- The constant value for 'x-client-id' header was stored in setting files:
		- "WEB\src\config\settings.js" for frontend
		- "API\src\FamilyTree.Api\appsettings.json" for backend
	- The expected base url for the backend api is also defined as a configuration setting on frontend
