using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_CRUD.Infrastructure.Interfaces;
using Dotnet_CRUD.Shared.ResponseDataHandler;

namespace Dotnet_CRUD.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfraStructure(this IServiceCollection services)
        {
            services.AddTransient<ICharacterRepository, CharactersRepository>();

        }
        public static void AddResponseConfig(this IServiceCollection services)
        {
            services.AddSingleton<IResponseHandler, ResponseDataHandler>();
        }

    }
}