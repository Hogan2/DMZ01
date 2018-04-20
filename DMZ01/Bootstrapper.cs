using DMZ01.Views;
using Microsoft.Practices.Unity;
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
    }
}
