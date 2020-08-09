using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class IdentityRoleEntity : IdentityRole<Guid>
    {
        /// <summary>
        /// Gets or sets the description of the identity role.
        /// </summary>
        public string Description { get; set; }
    }
}
