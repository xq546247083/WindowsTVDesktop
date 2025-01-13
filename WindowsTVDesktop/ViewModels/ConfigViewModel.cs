using WindowsTVDesktop.Enum;
using WindowsTVDesktop.Managers;

namespace WindowsTVDesktop.ViewModels
{
    public class ConfigViewModel : ItemViewModel
    {
        public object Data
        {
            get; set;
        }

        public string? DataDescription
        {
            get
            {
                if (ConfigType == ConfigType.AutoStart ||
                        ConfigType == ConfigType.FullScreen)

                {
                    return (bool)Data ? "是" : "否";
                }

                return string.Empty;
            }
        }

        public ConfigType ConfigType
        {
            get;
            set;
        }

        /// <summary>
        /// 点击
        /// </summary>
        public override void Click()
        {
            if (ConfigType == ConfigType.Close)
            {
                AppGlobal.CloseConfigWindow();
            }
            else if (ConfigType == ConfigType.AutoStart)
            {
                TaskSchedulerManager.UpdateIsLaunchOnSysPowerOnByTaskScheduler();
            }
            else if (ConfigType == ConfigType.FullScreen)
            {
                var config = ConfigManager.GetConfig();
                config.FullScreen = !config.FullScreen;
                ConfigManager.Save(config);
            }
            else if (ConfigType == ConfigType.AddItemSize)
            {
                var config = ConfigManager.GetConfig();
                config.ItemSize = config.ItemSize + 20;
                if (config.ItemSize >= 500)
                {
                    config.ItemSize = 500;
                }

                ConfigManager.Save(config);
            }
            else if (ConfigType == ConfigType.SubItemSize)
            {
                var config = ConfigManager.GetConfig();
                config.ItemSize = config.ItemSize - 20;
                if (config.ItemSize <= 20)
                {
                    config.ItemSize = 20;
                }

                ConfigManager.Save(config);
            }
        }
    }
}