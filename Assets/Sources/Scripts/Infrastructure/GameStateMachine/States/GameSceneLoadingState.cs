public class GameSceneLoadingState : IState
{
    private const string GameSceneName = "GameScene";
    private readonly SceneLoader _sceneLoader;

    public GameSceneLoadingState(SceneLoader sceneLoader) => _sceneLoader = sceneLoader;
    public void Enter() => _sceneLoader.LoadScene(GameSceneName);
}
