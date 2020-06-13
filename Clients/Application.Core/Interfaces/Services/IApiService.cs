using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Interfaces.Services
{
    public interface IApiService
    {
        Task<string> GetIdentityAsync();
    }
}
