using System.Windows.Controls;

namespace WindowsTVDesktop.Common
{
    public static class UIHelper
    {
        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="text">文本</param>
        public static void ShowToolTip(string text)
        {
            var tempToolTip = new ToolTip();
            tempToolTip.Content = text;
            tempToolTip.StaysOpen = false;
            tempToolTip.IsOpen = true;
        }
    }
}