using DevicesManager.Application.Interfaces;
using DevicesManager.Application.Services;
using DevicesManager.Domain.Core.Interfaces.Repositories;
using DevicesManager.Domain.Core.Interfaces.Services;
using DevicesManager.Domain.Services.Services;
using DevicesManager.Infrastruture.CrossCutting.Adapter.Interfaces;
using DevicesManager.Infrastruture.CrossCutting.Adapter.Maps;
using DevicesManager.Infrastruture.Repository.Repositories;
using NUnit.Extension.DependencyInjection;
using NUnit.Extension.DependencyInjection.Abstractions;
using NUnit.Extension.DependencyInjection.Unity;
using Unity;

[assembly: NUnitTypeInjectionFactory(typeof(UnityInjectionFactory))]
[assembly: NUnitTypeDiscoverer(typeof(IocRegistrarTypeDiscoverer))]
namespace DevicesManager.Presentation.Test
{
    public class IOC : RegistrarBase<IUnityContainer>
    {
        protected override void RegisterInternal(IUnityContainer container)
        {
            #region IOC Application
            container.RegisterType<IDeviceApplicationService, DeviceApplicationService>();
            #endregion

            #region IOC Services
            container.RegisterType<IDeviceService, DeviceService>();
            #endregion

            #region IOC Repositories
            container.RegisterType<IDeviceRepository, DeviceRepository>();
            #endregion

            #region IOC Mapper
            container.RegisterType<IDeviceMapper, DeviceMapper>();
            #endregion
        }
    }
}
