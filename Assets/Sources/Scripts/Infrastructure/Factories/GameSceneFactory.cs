using UnityEngine;

public class GameSceneFactory 
{
    private readonly GameObject _gameAreaPrefab;
    private readonly GameObject _hudPrefab;

    public GameSceneFactory(GameObject gameAreaPrefab, GameObject hudPrefab)
    {
        _gameAreaPrefab = gameAreaPrefab;
        _hudPrefab = hudPrefab;
    }

    public void CreateGameArea() => Object.Instantiate(_gameAreaPrefab);
    public void CreateHud() => Object.Instantiate(_hudPrefab);
}
