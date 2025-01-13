using WindowsTVDesktop.Common;

namespace WindowsTVDesktop.Managers
{
    public static class TaskSchedulerManager
    {
        /// <summary>
        /// 获取是否计划任务自启动
        /// </summary>
        /// <returns></returns>
        public static bool GetIsLaunchOnSysPowerOnByTaskScheduler()
        {
            var taslScheduler = TaskSchedulerHelper.Get(AppGlobal.AppName);

            return taslScheduler != null;
        }

        /// <summary>
        /// 更新是否计划任务自启动
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public static void UpdateIsLaunchOnSysPowerOnByTaskScheduler()
        {
            // 修改是否自启动
            var currentValue = !GetIsLaunchOnSysPowerOnByTaskScheduler();
            if (currentValue)
            {
                TaskSchedulerHelper.AddLuanchTask(AppGlobal.AppName, System.Windows.Forms.Application.ExecutablePath);
            }
            else
            {
                TaskSchedulerHelper.Del(AppGlobal.AppName);
            }
        }
    }
}