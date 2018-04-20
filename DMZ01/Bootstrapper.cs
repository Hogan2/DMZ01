using DMZ01.Views;
using Microsoft.Practices.Unity;
using Misson;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace DMZ01
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(MissionModule));
        }
    }
}
