using WindowsTVDesktop.Enum;

namespace WindowsTVDesktop.Models
{
    public class Config
    {
        public Config()
        {
            ItemSize = 100;
            AppInfoList = [];
        }

        public int ItemSize
        {
            get; set;
        }

        public List<AppInfo> AppInfoList
        {
            get; set;
        }

        public Boolean FullScreen
        {
            get; set;
        }
    }
}