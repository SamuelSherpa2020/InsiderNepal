using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LearnIdentity.Areas.Identity.Data;

// Add profile data for application users by adding properties to the LearnIdentityUser class
public class LearnIdentityUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

