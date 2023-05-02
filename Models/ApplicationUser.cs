using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace _521Final.Models
{
    public class ApplicationUser : IdentityUser //control dot to add reference to MS.Ext.Ident.Stores.dll??
    {
        //prop from AspNetUsers in database you want
        [Required]
        public string? Name { get; set;}


    }
}
