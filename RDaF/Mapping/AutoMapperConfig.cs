using AutoMapper;
using System.Reflection;

namespace RDaF.Api.Mapping
{
    public class AutoMapperConfig
    {
        public static IMapper CreateMapper()
        {
            var profileType = typeof(Profile);

            var profiles = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => profileType.IsAssignableFrom(t)
                            && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(Activator.CreateInstance)
                .Cast<Profile>();

            var config = new MapperConfiguration(
                c =>
                {
                    foreach (var profile in profiles)
                    {
                        c.AddProfile(profile);
                    }
                });

            return config.CreateMapper();
        }
    }
}
