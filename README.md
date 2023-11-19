# Logwarts
Email : tarunnair200029@gmail.com / tarunjarvis5@gmail.com

## UI
 ![Alt text](https://github.com/tarunjarvis5/DyteAssignment/blob/master/UI.PNG "Title")

## Setup
1) **SQL Server Management Studio**:
 https://www.microsoft.com/en-us/sql-server/sql-server-downloads
 https://learn.microsoft.com/en-us/sql/ssms/sql-server-management-studio-ssms?view=sql-server-ver16
    
     Create new database 
 ![Alt text](https://codingsight.com/wp-content/uploads/2020/11/image-196.png "Title")
 
    Go to *appsettings.json* in the code project and change the values for "server" and "database"
    Example : 
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "server=(LocalDb)\\aspcoreapp; database=Dyte; trusted_connection=true"
        },
    ```
    
2) **Code setup**:
    Download and install visual studio community https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false
    **Install the following workloads :**
    - ASP.Net and web developement
    - Node.js development
    
    Now you can open the **Logwarts.sln** file to open the project in Visual studio and hit on execute.

## Execution

**Database code first migration**
After opening the solution code in visual studio.
- Open **Package Manager Console** , by navigating to View -> Other Windows
- Ensure , Package Source is set to ALL and Default Project is Logwarts
- The type the following commands in sequence:
    ```
    Add-Migration
    Update-Database
    ```
The project runs on **port 3000 , the logs can be ingested via Post Request** to "https://localhost:3000/app/ingest"

**Example Javascript code to post 1000 request**
```javascript
const sendRequests = async () => {
    const requests = [];

    for (let i = 0; i < 1000; i++) {
        requests.push(
            fetch('https://localhost:3000/app/ingest', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                        level: "Warn",
                        message: "Message",
                        resourceId: "resource",
                        timestamp: "2023-09-15T08:00:00Z",
                        traceId: "tracer",
                        spanId: "spaneId",
                        commit: "743Commt",
                        metadata: {
                            parentResourceId: "56Resource"
                        }
                }),
            })
        );
    }

    try {
        const responses = await Promise.all(requests);
        const data = await Promise.all(responses.map((res) => res.json()));
        console.log('All requests completed successfully', data);
    } catch (error) {
        console.error('Error in one or more requests', error);
    }
};
```

## Objectives and Achievements

- Ingests logs at port 3000 over HTTP
- Follows the same input format for the payload 
 ```json
 {
	"level": "error",
	"message": "Failed to connect to DB",
    "resourceId": "server-1234",
	"timestamp": "2023-09-15T08:00:00Z",
	"traceId": "abc-xyz-123",
    "spanId": "span-456",
    "commit": "5e5342f",
    "metadata": {
        "parentResourceId": "server-0987"
    }
}
 ```
 - Is scalable, the choice of database used is RDBMS **SQLServer**
 (Other more scalable options are ElasticSearch , Solr , Sphinx , etc)
- Uses Entity Framework Core, handling database I/O operations.
- The solution also provides a **User Interface** to query data.
- It inlcudes multi-filtering where it takes into account mulitple filters together (Bonus functionality)
- The solution also include **filtering with time stamp**, allowing users to specify the **To and From date time**
- The filtering instead of direct comparison, uses contains allowing users to fetch all the records without providing the whole text or field data. (Additional functionality)
- SQL Server with EF Core can fetch millions of records per minute

## Features not included

- Removal of unwanter filters from UI
- RealTime updation of UI (Can we done using **gRPC**, did not include as having real time data every second would cause the UI to populate every second)
- Database Indexing
- Role based functionality

## Code Structure Explaination

![Alt text](https://github.com/tarunjarvis5/DyteAssignment/blob/master/BackEndCodeStructure.PNG "Title")
![Alt text](https://github.com/tarunjarvis5/DyteAssignment/blob/master/JSCodeStructure.PNG "Title")

The front end **ReactJs being a Single Page Application** the code is divided into two main components , Pages where all the different pages which will be used for routing are defined and Components where all the reusable components which are used inside the different pages are defined

The backend uses ASP.Net Core, the coding pattern used in this project follow **MVC(Model-View-Controller)** , with an additional **ViewModel layer** which avoid the exact structure of the database to be viewed or sent to the client app.
Instead of traditional **Repository pattern**, the code uses **DataProviders**, which allow simple abstraction and avoid additional layer of code, which makes it slower, as use of generic variable as avoided.
**The code also includes an extra layer of abstraction to avoid the use of all the DataBaseContext functionality like, Remove and Update etc, as these functionalities can be used to tamper with the logs ingested.**

## Resources Used :
https://stackoverflow.com/questions/40714583/how-to-specify-a-port-to-run-a-create-react-app-based-project
https://stackoverflow.com/questions/72654483/controller-not-working-except-weatherforecast-in-net-core-with-react
https://bard.google.com/
https://chat.openai.com

    