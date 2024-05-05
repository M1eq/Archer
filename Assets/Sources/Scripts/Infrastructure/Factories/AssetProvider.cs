using UnityEngine;

public class AssetProvider : MonoBehaviour
{
    public SceneNamesConfig SceneNamesConfig => _sceneNamesConfig;
    public GameObject GameAreaPrefab => _gameAreaPrefab;
    public GameObject HudPrefab => _hudPrefab;

    [SerializeField] private SceneNamesConfig _sceneNamesConfig;
    [SerializeField] private GameObject _gameAreaPrefab;
    [SerializeField] private GameObject _hudPrefab;
}
