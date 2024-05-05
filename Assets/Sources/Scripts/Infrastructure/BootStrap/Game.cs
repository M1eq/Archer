public class Game 
{
    private readonly GameStateMachine _gameStateMachine;

    public void ActivateBootstrapState() => _gameStateMachine.Enter<BootstrapState>();

    public Game(GameBootstrapper gameBootstrapper, AssetProvider assetProvider)
    {
        GameSceneFactory gameSceneFactory = new GameSceneFactory(assetProvider.GameAreaPrefab);
        _gameStateMachine = new GameStateMachine(new SceneLoader(gameBootstrapper), gameSceneFactory, assetProvider.SceneNamesConfig);
    }
}
