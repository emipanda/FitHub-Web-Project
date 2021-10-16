using System;
using System.Collections.Generic;
using System.Text;

//a class to know what is te state of the user
namespace WebApp2021.Models
{
    public enum UserState
    {
        NotLoggedIn,
        RegularUser,
        RegularUserForbidden,
        Manager
    }
}
