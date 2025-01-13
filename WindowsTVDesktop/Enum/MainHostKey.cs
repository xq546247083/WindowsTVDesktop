namespace WindowsTVDesktop.Enum
{
    [Flags]
    public enum MainHostKey : byte
    {
        None = 0,
        Alt = 1,
        Ctrl = 2,
        Shift = 4,
        Windows = 8
    }
}