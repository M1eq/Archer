using UnityEngine;

[CreateAssetMenu(fileName = "SceneNameConfig", menuName = "Configs/SceneNameConfig")]
public class SceneNamesConfig : ScriptableObject
{
    [field: SerializeField] public string InitialSceneName { get; private set; }
    [field: SerializeField] public string GameSceneName { get; private set; }
}
