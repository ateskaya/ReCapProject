using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection serviceCollection,ICoreModole[] modoles)
        {
            foreach (var modole in modoles)
            {
                modole.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}
