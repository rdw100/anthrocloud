# AnthroCloud
This is source code for a capstone project.  The second semester capstone course research topic is Software Modernization for Cloud-based Pediatric Anthropometry.  The software is called AnthroCloud.  This project will create a modern cloud-based WHO 2006 Child Growth Standard-compliant anthropometric calculator designed to provide a more flexible, maintainable, and portable solution to meet the changing needs of users.

## Design
The section lays out technical design used to create the AnthroCloud solution.

### Architecture
The solution conforms to the architectural design below.  The solution will not compile if a dependency violation exists.  Arrows between components are read as “Uses” statements.  No single upstream component can perform an End-Run and circumvent the architecture without breaking the build.  For example, presentation layer cannot access the data layer directly.  This ensures the software is consistent with the intended design and meets requirements.
![AnthroCloud Solution Dependency Validation PNG for Architecture Components](https://github.com/rdw100/AnthroCloud/blob/master/AnthroCloud/AnthroCloud.UI.Web/Documentation/SolutionArchitecture.PNG?raw=true)

### Physical
The physical view of the software is represented as a deployment diagram.  The web application is rendered to the client’s web browser over HTTP.  Requests pass through the web application, then web service and finally the database. The deployment diagram identifies the elements comprising the physical view of the system.   
![Deployment Diagram](https://github.com/rdw100/AnthroCloud/blob/master/AnthroCloud/AnthroCloud.UI.Web/Documentation/Deployment.png?raw=true)

 ### Rationale
 Layered architectural and interactive system patterns were selected for the design.  The table below describes technology by layer used for the AnthroCloud software solution.
 
 | Layer         | Technologies                                                  |
 | ------------- | ------------------------------------------------------------- |
 | Presentation	 | .NET Core, Blazor Server App, ASP.NET Core MVC, Google Charts, HTML5, Javascript
 | Service	     | ASP.NET Core Web API |
 | Business	     | C# |
 | Data	         | Entity Framework Core |
 | Database	     | Azure SQL Database |

### Rest API
The AnthroCloud RESTful API is designed to support retrieval operations.  The REST guidelines in Table 11 suggest HTTP calls to make to the server.  The calls are safe as they do not change the state of data.

 | Resource Type | HTTP Verb | Resource API	                      | Description                                             |
 | ------------- | --------- | ---------------------------------- | ------------------------------------------------------- |
 | Anthro        | GET	     | /ANTHRO/AGE/{birth}/{visit}        | Returns a human readable string in either Months or Year-Month (TotalMonths) format. |
 | Anthro	     | GET	     | /ANTHRO/AGE/DAYS/{birth}/{visit}   | Returns string of age in total days.                    |
 | Anthro	     | GET       | /ANTHRO/AGE/MONTHS/{birth}/{visit} | Returns string of age in total months.                  |
 | Anthro	     | GET	     | /ANTHRO/AGE/YEARS/{birth}/{visit}  | Returns string of age in total years.                   |
 | Anthro        | GET       | /ANTHRO/BMI/{weight}/{height}      | Returns BMI rounded to tenths.                          |
 | Chart         | GET       | BFA/{id}/{x}/{y}                   | Returns a list of age-based indicator table data for measurement of body mass index by age used to create a WHO chart. |
 | Chart         | GET       | HCFA/{id}/{x}/{y}                  | Returns a list of age-based indicator table data for measurement of Head circumference-for-age used to create a WHO chart.  Data point (x,y) is insert if new; otherwise updated. |
 | Chart         | GET       | LHFA/{id}/{x}/{y}                  | Returns a list of age-based indicator table data for measurement of Length/height-for-age used to create a WHO chart.  Data point (x,y) is insert if new; otherwise updated. |
 | Chart         | GET       | MUAC/{id}/{x}/{y}                  | Returns a list of age-based indicator table data for measurement of Arm circumference-for-age used to create a WHO chart.  Data point (x,y) is insert if new; otherwise updated. |
 | Chart         | GET       | SSFA/{id}/{x}/{y}                  | Returns a list of age-based indicator table data for measurement of Subscapular skinfold-for-age used to create a WHO chart.  Data point (x,y) is insert if new; otherwise updated.
 | Chart         | GET       | TSFA/{id}/{x}/{y}                  | Returns a list of age-based indicator table data for measurement of Triceps skinfold-for-age used to create a WHO chart.  Data point (x,y) is insert if new; otherwise updated. |
 | Chart         | GET       | WFA/{id}/{x}/{y}                   | Returns a list of age-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart.  Data point (x,y) is insert if new; otherwise updated. |
 | Chart         | GET       | WFH/{id}/{x}/{y}                   | Returns a list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (2 to 5 years).  Data point (x,y) is insert if new; otherwise updated. |
 | Chart         | GET       | WFL/{id}/{x}/{y}                   | Returns a list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (Birth to 2 years).  Data point (x,y) is insert if new; otherwise updated. |
 | Chart         | GET       | BFA/{id}/{x}/{y}/{z}               | Returns Body mass index (BMI) for age indicator chart data as a JSON serialized DataTable structure to pass into Chart.js DataTable constructor. |
 | Chart         | GET       | HCFA/{id}/{x}/{y}/{z}              | Returns Head circumference-for-age indicator chart data as a JSON serialized DataTable structure to pass into Chart.js DataTable constructor. |
 | Chart         | GET       | LHFA/{id}/{x}/{y}/{z}              | Returns Length/height-for-age indicator chart data as a JSON serialized DataTable structure to pass into Chart.js DataTable constructor. |
 | Chart         | GET       | MUAC/{id}/{x}/{y}/{z}              | Returns Arm circumference-for-age indicator chart data as a JSON serialized DataTable structure to pass into Chart.js DataTable constructor. |
 | Chart         | GET       | SSFA/{id}/{x}/{y}/{z}              | Returns Subscapular skinfold-for-age indicator chart data as a JSON serialized DataTable structure to pass into Chart.js DataTable constructor. |
 | Chart         | GET       | TSFA/{id}/{x}/{y}/{z}              | Returns Triceps skinfold-for-age indicator chart data as a JSON serialized DataTable structure to pass into Chart.js DataTable constructor. |
 | Chart         | GET       | WFA/{id}/{x}/{y}/{z}               | Returns Gets Weight-for-age indicator chart data as a JSON serialized DataTable structure to pass into Chart.js DataTable constructor. |
 | Chart         | GET       | WFH/{id}/{x}/{y}/{z}               | Returns Gets Weight-for-height indicator chart data as a JSON serialized DataTable structure to pass into Chart.js DataTable constructor. |
 | Chart         | GET       | WFL/{id}/{x}/{y}/{z}               | Returns Gets Weight-for-height indicator chart data as a JSON serialized DataTable structure to pass into Chart.js DataTable constructor. |
 | Stats     	 | GET       | STATS/{indicator}/{measurement}/{ageInDays}/{id} | Returns a tuple of both calculated Zscore and Percentile values. |
 | Stats         | POST      | STATS/[FromBody]{inputs} | Returns computed statistics {outputs}. |
 | Stats         | POST      | STATS/MEASURED/[FromBody]{inputs} | Returns computed statistics {outputs}. |
 | Stats         | POST      | STATS/HCA/[FromBody]{inputs} | Returns computed statistics {outputs}. |
 | Stats         | POST      | STATS/MUAC/[FromBody]{inputs} | Returns computed statistics {outputs}. |
 | Stats         | POST      | STATS/TSF/[FromBody]{inputs} | Returns computed statistics {outputs}. |
 | Stats         | POST      | STATS/SSF/[FromBody]{inputs} | Returns computed statistics {outputs}. |


 ### Demo
 The animated gif below demonstrates ASP.NET MVC application execution. 
 ![ASP.NET MVC Demo](https://github.com/rdw100/AnthroCloud/blob/master/AnthroCloud/AnthroCloud.UI.Web/Documentation/toQO8tLp8W.gif?raw=true)

 The animated gif below demonstrates Blazor Server application execution.
 ![Blazor Server App Demo](https://github.com/rdw100/AnthroCloud/blob/master/AnthroCloud/AnthroCloud.UI.Blazor/wwwroot/img/stp0eKMSiY.gif?raw=true)
