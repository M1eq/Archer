using UnityEngine;

public class AssetProvider : MonoBehaviour
{
    public GameObject GameAreaPrefab => _gameAreaPrefab;
    public GameObject HudPrefab => _hudPrefab;

    [SerializeField] private GameObject _gameAreaPrefab;
    [SerializeField] private GameObject _hudPrefab;
}
