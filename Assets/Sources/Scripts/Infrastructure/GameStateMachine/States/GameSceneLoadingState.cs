public class GameSceneLoadingState : IState
{
    private const string GameSceneName = "GameScene";
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;

    public GameSceneLoadingState(SceneLoader sceneLoader, GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
    }

    public void Enter() => _sceneLoader.LoadScene(GameSceneName, OnGameSceneLoaded);
    private void OnGameSceneLoaded() => _gameStateMachine.Enter<GameSceneInitializingState>();
}
