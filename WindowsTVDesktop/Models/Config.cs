using WindowsTVDesktop.Enum;

namespace WindowsTVDesktop.Models
{
    public class Config
    {
        public Config()
        {
            AppSize = 100;
            AppInfoList = [];
        }

        public int AppSize
        {
            get; set;
        }

        public List<AppInfo> AppInfoList
        {
            get; set;
        }
    }
}