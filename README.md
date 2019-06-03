# SocialCareProject

The project is open-source so can be improved by everyone.
Source code is stored on https://github.com/oleggerus/SocialCareProject.git

## Setup
1. Clone repository from GitGub orother sources.
2. Install .NEt Framework on your Windows machine.
3. Configure MS SQL Server.
4. Open .sln file
5. Restore all nuget packages.
6. Set SocialCareProject as startup project
7. Run application.

## Commit strategy

1. Clone project.
2. Create branch for new functionality.
3. Commit changes and prepare ypur code.
4. Create pull request regrding your changes.

### Adding a Controller

1. Right click Controllers folder in the project > Add > Class
2. Filename for a controller class must end in Controller so Visual Studio can distinguish controllers from regular classes.
3. Our controller must inherit from the MVC controller base class and include using System.Web.Mvc.
Also it should be inherited from BaseCustomerController or BaseAdministrationController depends on its area.
4. Controller must be public so its accessible.
See CustomerArea/Controllers/CustomerController.cs

### Adding Action Method

Methods need to be public so its accessible.
http://localhost:62466/Home/Index via CustomerController.cs

    public class Customer : BaseCustomerController
    {
        public string Index()
        {
            return "Hello";
        }
    }
