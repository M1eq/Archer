public class GameSceneLoadingState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneNamesConfig _sceneNamesConfig;
    private readonly SceneLoader _sceneLoader;

    public GameSceneLoadingState(SceneLoader sceneLoader, GameStateMachine gameStateMachine, SceneNamesConfig sceneNamesConfig)
    {
        _gameStateMachine = gameStateMachine;
        _sceneNamesConfig = sceneNamesConfig;
        _sceneLoader = sceneLoader;
    }

    public void Enter() => _sceneLoader.LoadScene(_sceneNamesConfig.GameSceneName, OnGameSceneLoaded);
    private void OnGameSceneLoaded() => _gameStateMachine.Enter<GameSceneInitializingState>();
}
