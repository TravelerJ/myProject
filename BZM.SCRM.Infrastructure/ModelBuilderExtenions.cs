using BZM.SCRM.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BZM.SCRM.Infrastructure
{
    public static class ModelBuilderExtenions
    {
        private static IEnumerable<Type> GetMappingTypes(this Assembly assembly, Type mappingInterface)
        {
            return assembly.GetTypes().Where(predicate: x => !x.IsAbstract && x.GetInterfaces().Any(predicate: y => y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() == mappingInterface));
        }

        public static void AddEntityConfigurationsFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var mappingTypes = assembly.GetMappingTypes(mappingInterface: typeof(IEntityMappingConfiguration<>));
            foreach (var config in mappingTypes.Select(selector: Activator.CreateInstance).Cast<IEntityMappingConfiguration>())
            {
                config.Map(builder: modelBuilder);
            }
        }
    }
}
