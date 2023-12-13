using Godot;

public partial class GraphContainerController
{
    private static GraphContainerController instance;
    private GraphContainerModel model = GraphContainerModel.Instance;
    private GraphContainerController() { }

    public void OnRestartPressed()
    {
        model.RestartGame();
    }

    public void OnNextPressed()
    {
        model.LoadNextLevel();
    }

    public static GraphContainerController Instance { get => instance ??= new(); }
}