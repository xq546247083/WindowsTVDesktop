using WindowsTVDesktop.Enum;

namespace WindowsTVDesktop.Models
{
    public class HotKeyInfo
    {
        public HotKeyInfo(MainHostKey mainHostKey, SubHostKey subHostKey)
        {
            MainHostKey = mainHostKey;
            SubHostKey = subHostKey;
        }

        public MainHostKey MainHostKey
        {
            get; set;
        }

        public SubHostKey SubHostKey
        {
            get; set;
        }

        public int ToHotKeyID()
        {
            return (((byte)MainHostKey.Ctrl) << 8) | (byte)SubHostKey.H;
        }
    }
}