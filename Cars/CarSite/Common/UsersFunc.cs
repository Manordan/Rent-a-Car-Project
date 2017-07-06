using CarSite.Models;
using CarSite.ViewModel;
using CarSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSite.Common
{
    public class UsersFunc
    {
        public UserWitheRolesViewModel UserCreate(User user, string[] roles)
        {
            UserWitheRolesViewModel userWitheRolesViewModel = new UserWitheRolesViewModel();

            List<AuthorizationRole> authorizationRole = new List<AuthorizationRole>();

            foreach (var item in userWitheRolesViewModel.RolesList)
            {

                item.IsChecked = userWitheRolesViewModel.RolesList.Any(r => roles.Contains(item.Name));
                authorizationRole.Add(new AuthorizationRole { Name = item.Name, IsChecked = item.IsChecked });
            }
            userWitheRolesViewModel.User = user;
            userWitheRolesViewModel.RolesList = authorizationRole.ToList();

            return userWitheRolesViewModel;
        }

        public UserWitheRolesViewModel UserEdit(User user, string id)
        {
            CarContext carContext = new CarContext();

            var roles = carContext.Roles.Where(r => r.UserId == id).Select(s => new AuthorizationRole { Name = s.Authorization }).ToList();

            UserWitheRolesViewModel userWitheRolesViewModel = new UserWitheRolesViewModel();
            List<AuthorizationRole> authorizationRole = new List<AuthorizationRole>();

            foreach (var item in userWitheRolesViewModel.RolesList)
            {

                item.IsChecked = userWitheRolesViewModel.RolesList.Any(r => roles.Select(s => s.Name).Contains(item.Name));
                authorizationRole.Add(new AuthorizationRole { Name = item.Name, IsChecked = item.IsChecked });
            }
            userWitheRolesViewModel.User = user;
            userWitheRolesViewModel.RolesList = authorizationRole.ToList();

            return userWitheRolesViewModel;

        }
    }
}