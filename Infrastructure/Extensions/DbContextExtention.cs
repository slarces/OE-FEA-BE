using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Flag_Explorer_App.Infrastructure.Extensions
{
    public static class DbContextExtention
    {
        public static void ApplyConfigurationsFromSpecificAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        {
            modelBuilder
               .HasAnnotation("ProductVersion", "1.0.0")
               .HasAnnotation("Relational:MaxIdentifierLength", 128);

            var configurations = assembly
                .DefinedTypes.Where(t =>
                    t.ImplementedInterfaces.Any(i =>
                       i.IsGenericType &&
                       i.Name.Equals(typeof(IEntityTypeConfiguration<>).Name,
                              StringComparison.InvariantCultureIgnoreCase)
                     ) &&
                     t.IsClass &&
                     !t.IsAbstract &&
                     !t.IsNested)
                 .ToList();


            foreach (var configuration in configurations)
            {
                var entityType = configuration.BaseType?.GenericTypeArguments.SingleOrDefault(t => t.IsClass);

                if (entityType == null) continue;

                var applyConfigMethod = typeof(ModelBuilder).GetMethod("ApplyConfiguration");

                if (applyConfigMethod == null) continue;

                var applyConfigGenericMethod = applyConfigMethod.MakeGenericMethod(entityType);

                var instance = Activator.CreateInstance(configuration);

                if (instance == null) continue;

                applyConfigGenericMethod.Invoke(modelBuilder, [instance]);
            }

        }
    }
}
