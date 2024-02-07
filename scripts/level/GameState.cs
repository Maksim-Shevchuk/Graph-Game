using System;

[Serializable]
public partial class GameState 
{
    private bool _isEasyModeEnabled;

    public bool IsEasyModeEnabled 
    {
        get => _isEasyModeEnabled;
        set => _isEasyModeEnabled = value;
    }

    public GameState(bool isEasyModeEnabled)
    {
        _isEasyModeEnabled = isEasyModeEnabled;
    }
}