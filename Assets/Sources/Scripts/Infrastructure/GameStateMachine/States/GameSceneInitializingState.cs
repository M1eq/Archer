public class GameSceneInitializingState : IState
{
    private readonly GameSceneFactory _gameSceneFactory;

    public GameSceneInitializingState(GameSceneFactory gameSceneFactory) => _gameSceneFactory = gameSceneFactory;
    public void Enter() => _gameSceneFactory.CreateGameArea();
}
