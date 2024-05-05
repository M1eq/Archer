using UnityEngine;

[CreateAssetMenu(fileName = "CoinAnimationConfig", menuName = "Configs/CoinAnimationConfig")]
public class CoinAnimationConfig : ScriptableObject
{
    [field: SerializeField] public float TargetScale { get; private set; }
    [field: SerializeField] public float ScaleDuration { get; private set; }
    [field: SerializeField] public float MoveToTargetDuration { get; private set; }
    [field: Space(10), SerializeField] public Coin CoinPrefab { get; private set; }
}
