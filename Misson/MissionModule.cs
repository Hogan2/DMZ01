using Misson.Views;
using Prism.Modularity;
using Prism.Regions;

namespace Misson
{
    public class MissionModule : IModule
    {
        RegionManager _regionManager;
        public MissionModule(RegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("GMapRegion", typeof(GMapCtrl));
        }
    }
}
