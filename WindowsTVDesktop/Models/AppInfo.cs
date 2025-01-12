namespace WindowsTVDesktop.Models
{
    /// <summary>
    /// 应用信息
    /// </summary>
    public class AppInfo
    {
        public string Name
        {
            get; 
            set;
        }

        public string Path
        {
            get;
            set;
        }

        public string[] StartArgs
        {
            get;
            set;
        }
    }
}