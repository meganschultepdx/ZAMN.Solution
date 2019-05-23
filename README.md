# ZAMN Social Surf

This web application allows the user to check the surf report and weather for three main surf spots on the Oregon coast. It prpovides only the most essential information needed to decide whether the conditions are good for surfing at that particular location at that particular time and day. The information is presented in a visually appealing and uncluttered manner via constantly updating embedded widgets and also via other surfers comments/posts. In addition to the surf report it also includes separate pages for nearby hikes and restaurants; these pages also allow users to add recommendations and comments. 

### Prerequisites

.NET

### Setup/Installing

* In terminal: git clone https://github.com/meganschulte/ZAMN.Solution/
* Start sql server to port 8889
* Import SQL file
* In terminal: dotnet run from ZAMN
* Open browser to localhost:5000
## Specs

| Behavior | Input | Output |
| ------------- |:-------------:| -----:|
| Clink link on home page | GET | Route to appropriate page |
| User is able to check location specific surf report and weather | check location page embedded widgets | widgets diplaying constantly updating Weather/Surf Report feed |
| user is able to view previous user comments | GET | Comments appear in list with name and DateTime stampl on each location's page |
| user is able to add comment to page |user clicks link/button that takes them to form to fill out | Comment is added to list with name and DateTime stampl on each location's page |

## Known Bugs

No known bugs.

## Running the tests

_navigate to ZAMN.Tests, run dotnet test_


## Built With

* _C#, HTML, CSS, bootsrap, MySQL, phpMyAdmin, PowerShell, .NET, magicseaweed and weather widgets_


## Authors

* **Megan Schulte**
* **Neil Bateman**
* **Zsuzsanna Mangu**
* **AJ Ancheta**



## License

Free use allowed by developers
