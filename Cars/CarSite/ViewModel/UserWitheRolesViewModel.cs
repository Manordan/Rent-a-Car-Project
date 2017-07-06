using CarSite.Models;
using System.Collections.Generic;

namespace CarSite.ViewModel
{

    public class AuthorizationRole
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
    public class UserWitheRolesViewModel
    {

        public UserWitheRolesViewModel()
        {
            RolesList = new[] {
                    new AuthorizationRole { Name="User"},
                    new AuthorizationRole { Name="Manager"},
                    new AuthorizationRole { Name="Admin"}
            };
        }
   
        

        public User User { get; set; }
        public IEnumerable<AuthorizationRole> RolesList { get; set; }
        
      


    }
}
