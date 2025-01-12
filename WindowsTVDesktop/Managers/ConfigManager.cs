using Newtonsoft.Json;
using System.IO;
using System.Windows;
using WindowsTVDesktop.Enum;
using WindowsTVDesktop.Models;

namespace WindowsTVDesktop.Managers
{
    public static class ConfigManager
    {
        private static AppInfo addAppInfo = new AppInfo()
        {
            Name = "新增",
            AppType = AppType.Add,
            IconPath = "Resources/add.png",
            Order = int.MaxValue,
        };

        private static AppInfo configAppInfo = new AppInfo()
        {
            Name = "配置",
            AppType = AppType.Config,
            Order = int.MaxValue,
        };

        private static AppInfo exitAppInfo = new AppInfo()
        {
            Name = "退出",
            AppType = AppType.Exit,
            Order = int.MaxValue,
        };

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <returns></returns>
        public static Config GetConfig()
        {
            try
            {
                var result = new Config();
                result.AppInfoList.Add(addAppInfo);
                result.AppInfoList.Add(configAppInfo);
                result.AppInfoList.Add(exitAppInfo);

                // 创建文件
                var infoFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");
                if (!File.Exists(infoFilePath))
                {
                    return result;
                }

                // 序列化对象
                var strTotal = File.ReadAllText(infoFilePath);
                var config = JsonConvert.DeserializeObject<Config>(strTotal);
                if (config == null)
                {
                    return result;
                }

                return config;
            }
            catch (Exception)
            {
                return new Config();
            }
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <returns></returns>
        public static void Save(Config config)
        {
            if (config == null)
            {
                return;
            }

            try
            {
                // 创建新的文本
                var infoFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");
                var str = JsonConvert.SerializeObject(config);
                File.WriteAllText(infoFilePath, str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}