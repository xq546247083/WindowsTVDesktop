using WindowsTVDesktop.Enum;

namespace WindowsTVDesktop.Models
{
    /// <summary>
    /// 应用信息
    /// </summary>
    public class AppInfo
    {
        public AppInfo()
        {
            AppType = AppType.Desktop;
        }

        public string Name
        {
            get;
            set;
        }

        public int Order
        {
            get;
            set;
        }

        public string IconPath
        {
            get;
            set;
        }

        public string StartPath
        {
            get;
            set;
        }

        public string StartArgs
        {
            get;
            set;
        }

        public AppType AppType
        {
            get;
            set;
        }
    }
}