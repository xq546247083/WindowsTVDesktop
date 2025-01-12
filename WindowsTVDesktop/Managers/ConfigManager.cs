using Newtonsoft.Json;
using System.IO;
using System.Windows;
using WindowsTVDesktop.Models;

namespace WindowsTVDesktop.Managers
{
    internal class ConfigManager
    {
        /// <summary>
        /// 读取配置
        /// </summary>
        /// <returns></returns>
        public static Config GetConfig()
        {
            try
            {
                // 创建文件
                var infoFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");
                if (!File.Exists(infoFilePath))
                {
                    return new Config();
                }

                // 序列化对象
                var strTotal = File.ReadAllText(infoFilePath);
                var config = JsonConvert.DeserializeObject<Config>(strTotal);
                if (config == null)
                {
                    return new Config();
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