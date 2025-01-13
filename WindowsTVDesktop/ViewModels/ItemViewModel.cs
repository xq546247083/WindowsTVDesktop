using CommunityToolkit.Mvvm.ComponentModel;
using System.IO;

namespace WindowsTVDesktop.ViewModels
{
    public class ItemViewModel : ObservableObject
    {
        public string Name
        {
            get;
            set;
        }

        public string IconPath
        {
            get;
            set;
        }

        public int Order
        {
            get;
            set;
        }

        public string Title
        {
            get
            {
                if (string.IsNullOrEmpty(IconPath))
                {
                    return Name;
                }

                return string.Empty;
            }
        }

        public string IconPathExt
        {
            get
            {
                if (string.IsNullOrEmpty(IconPath))
                {
                    return IconPath;
                }

                return Path.GetFullPath(IconPath);
            }
        }

        /// <summary>
        /// 点击
        /// </summary>
        public virtual void Click()
        {
            
        }
    }
}