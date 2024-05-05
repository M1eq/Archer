public class BootstrapState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneNamesConfig _sceneNamesConfig;
    private readonly SceneLoader _sceneLoader;

    public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, SceneNamesConfig sceneNamesConfig)
    {
        _gameStateMachine = gameStateMachine;
        _sceneNamesConfig = sceneNamesConfig;
        _sceneLoader = sceneLoader;
    }

    public void Enter() => _sceneLoader.LoadScene(_sceneNamesConfig.InitialSceneName, OnInitialSceneLoaded);
    private void OnInitialSceneLoaded() => _gameStateMachine.Enter<GameSceneLoadingState>();
}
