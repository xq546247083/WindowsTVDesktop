using WindowsTVDesktop.Models;
using WindowsTVDesktop.ViewModels;

namespace WindowsTVDesktop.Common
{
    public static class CommonTurn
    {
        public static AppViewModel Turn(this AppInfo appInfo)
        {
            var appViewModel= new AppViewModel();
            appViewModel.Name = appInfo.Name;
            appViewModel.Order = appInfo.Order;
            appViewModel.IconPath = appInfo.IconPath;
            appViewModel.StartPath = appInfo.StartPath;
            appViewModel.StartArgs = appInfo.StartArgs;
            appViewModel.AppType = appInfo.AppType;

            return appViewModel;
        }

        public static AppInfo Turn(this AppViewModel appViewModel)
        {
            var appInfo = new AppInfo();
            appInfo.Name = appViewModel.Name;
            appInfo.Order = appViewModel.Order;
            appInfo.IconPath = appViewModel.IconPath;
            appInfo.StartPath = appViewModel.StartPath;
            appInfo.StartArgs = appViewModel.StartArgs;
            appInfo.AppType = appViewModel.AppType;

            return appInfo;
        }
    }
}