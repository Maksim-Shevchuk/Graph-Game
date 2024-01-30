public partial class RuntimeLevelInfo
{
    private static RuntimeLevelInfo instance = new();
    private float _delta = 0.01f;
    public static RuntimeLevelInfo Instance
    {
        get => instance ??= new();
    }
    public float Delta
    {
        get => _delta;
        set => _delta = value;
    }
}