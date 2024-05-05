using UnityEngine;

public class GameSceneFactory 
{
    private readonly GameObject _gameAreaPrefab;

    public GameSceneFactory(GameObject gameAreaPrefab) => _gameAreaPrefab = gameAreaPrefab;
    public void CreateGameArea() => Object.Instantiate(_gameAreaPrefab);
}
