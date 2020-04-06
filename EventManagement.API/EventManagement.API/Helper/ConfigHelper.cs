using Event.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.API.Helper
{
    public interface IConfigHelper
    {
        void AddScopedServices();
    }
    public class ConfigHelper : IConfigHelper
    {
        private IServiceCollection _services;
        public ConfigHelper(IServiceCollection services)
        {
            _services = services;
        }

        public void AddScopedServices()
        {
            _services.AddScoped<IUserService, UserService>();
        }
    }
}
