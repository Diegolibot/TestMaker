using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FirstApp.ViewModels;
using FirstApp.Views;
using Squirrel;

namespace FirstApp
{
    public class Bootstraper : BootstrapperBase
    {
        public Bootstraper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {

            DisplayRootViewFor<ShellViewModel>();

            CheckForUpdates();
        }

        private async Task CheckForUpdates()
        {
            using (var manager = new UpdateManager(@"C:\TestMaker\Databases"))
            {
                await manager.UpdateApp();
            }
        }
    }
}
