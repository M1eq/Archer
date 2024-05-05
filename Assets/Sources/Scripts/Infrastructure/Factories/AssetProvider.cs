using UnityEngine;

public class AssetProvider : MonoBehaviour
{
    public SceneNamesConfig SceneNamesConfig => _sceneNamesConfig;
    public GameObject GameAreaPrefab => _gameAreaPrefab;

    [SerializeField] private SceneNamesConfig _sceneNamesConfig;
    [SerializeField] private GameObject _gameAreaPrefab;
}
