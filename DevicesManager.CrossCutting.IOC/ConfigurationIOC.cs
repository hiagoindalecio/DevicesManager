using Autofac;
using DevicesManager.Application.Interfaces;
using DevicesManager.Application.Services;
using DevicesManager.Domain.Core.Interfaces.Repositories;
using DevicesManager.Domain.Core.Interfaces.Services;
using DevicesManager.Domain.Services.Services;
using DevicesManager.Infrastruture.CrossCutting.Adapter.Interfaces;
using DevicesManager.Infrastruture.CrossCutting.Adapter.Maps;
using DevicesManager.Infrastruture.Repository.Repositories;

namespace DevicesManager.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC Application
            builder.RegisterType<DeviceApplicationService>().As<IDeviceApplicationService>();
            #endregion

            #region IOC Services
            builder.RegisterType<DeviceService>().As<IDeviceService>();
            #endregion

            #region IOC Repositories
            builder.RegisterType<DeviceRepository>().As<IDeviceRepository>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<DeviceMapper>().As<IDeviceMapper>();
            #endregion
        }
    }
}
