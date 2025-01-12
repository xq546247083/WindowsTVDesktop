using System.Drawing;
using System.IO;
using WindowsTVDesktop.Enum;
using WindowsTVDesktop.Managers;
using WindowsTVDesktop.Models;

namespace WindowsTVDesktop.Common
{
    public static class AppHelper
    {
        public static AppInfo ReadApp(string path)
        {
            var appName = Path.GetFileNameWithoutExtension(path);
            var iconPath = $"./Resources/{appName}.ico";

            // 保存图标
            var ico = Icon.ExtractAssociatedIcon(path);
            if (ico != null)
            {
                using (var fileStream = new FileStream(iconPath, FileMode.Create))
                {
                    ico.Save(fileStream);
                }
            }

            // 获取排序号
            var config = ConfigManager.GetConfig();
            var desktopList = config.AppInfoList.Where(r => r.AppType == AppType.Desktop);
            var currentOrder = desktopList.Count() == 0 ? 1 : desktopList.Max(r => r.Order) + 1;

            var appInfo = new AppInfo();

            appInfo.Name = appName;
            appInfo.StartPath = path;
            appInfo.IconPath = ico != null ? $"Resources/{appName}.ico" : string.Empty;
            appInfo.AppType = AppType.Desktop;
            appInfo.Order = currentOrder;

            return appInfo;
        }
    }
}