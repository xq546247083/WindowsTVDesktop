using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
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
            var iconList = ExtractIconList(path);

            // 获取排序号
            var config = ConfigManager.GetConfig();
            var desktopList = config.AppInfoList.Where(r => r.AppType == AppType.Desktop);
            var currentOrder = desktopList.Count() == 0 ? 1 : desktopList.Max(r => r.Order) + 1;

            var appInfo = new AppInfo();

            appInfo.Name = appName;
            appInfo.StartPath = path;
            appInfo.IconPath = iconList.FirstOrDefault() ?? string.Empty;
            appInfo.AppType = AppType.Desktop;
            appInfo.Order = currentOrder;

            return appInfo;
        }

        private static List<string> ExtractIconList(string file)
        {
            var result = new List<string>();
            var appName = Path.GetFileNameWithoutExtension(file);

            var iconTotalCount = PrivateExtractIcons(file, 0, 0, 0, null, null, 0, 0);
            var hIcons = new IntPtr[iconTotalCount];
            var ids = new int[iconTotalCount];

            var successCount = PrivateExtractIcons(file, 0, 1024, 1024, hIcons, ids, iconTotalCount, 0);
            for (var i = 0; i < successCount; i++)
            {
                if (hIcons[i] == IntPtr.Zero)
                {
                    continue;
                }

                using (var ico = Icon.FromHandle(hIcons[i]))
                {
                    var iconPath = $"Resources/{appName}_{i}.png";
                    using (var myIcon = ico.ToBitmap())
                    {
                        myIcon.Save($"./{iconPath}");
                        result.Add(iconPath);
                    }
                }
                DestroyIcon(hIcons[i]);
            }

            return result;
        }

        [DllImport("User32.dll")]
        private static extern bool DestroyIcon(
           IntPtr hIcon //A handle to the icon to be destroyed. The icon must not be in use.
        );

        [DllImport("User32.dll")]
        private static extern int PrivateExtractIcons(
            string lpszFile, //文件名可以是exe,dll,ico,cur,ani,bmp
            int nIconIndex,  //从第几个图标开始获取
            int cxIcon,      //获取图标的尺寸x
            int cyIcon,      //获取图标的尺寸y
            IntPtr[] phicon, //获取到的图标指针数组
            int[] piconid,   //图标对应的资源编号
            int nIcons,      //指定获取的图标数量，仅当文件类型为.exe 和 .dll时候可用
            int flags        //标志，默认0就可以，具体可以看LoadImage函数
        );
    }
}