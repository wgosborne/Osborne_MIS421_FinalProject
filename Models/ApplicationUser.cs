using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace _521Final.Models
{
    public class ApplicationUser : IdentityUser //control dot to add reference to MS.Ext.Ident.Stores.dll??
    {
        //prop from AspNetUsers in database you want

        //can we add an Id

        [Required]
        public string? Name { get; set;}
        public string Role { get; set; }

    }
}
