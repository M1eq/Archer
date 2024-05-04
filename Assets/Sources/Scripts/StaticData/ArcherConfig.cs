using UnityEngine;

[CreateAssetMenu(fileName = "ArcherConfig", menuName = "Configs/ArcherConfig")]
public class ArcherConfig : ScriptableObject
{
    [field: Header("Стрела")]
    [field: Space(10), SerializeField] public int PushForce { get; private set; } = 4;
    [field: SerializeField] public int ArrowsInPool { get; private set; }
    [field: Space(5), SerializeField] public Arrow ArrowPrefab { get; private set; }

    [field: Space(10), Header("Траектория")]
    [field: Space(10), SerializeField] public int DotsCount { get; private set; }
    [field: SerializeField] public float SpacingBetweenDots { get; private set; }
    [field: SerializeField] public float DotMinScale { get; private set; }
    [field: SerializeField] public float DotMaxScale { get; private set; }
    [field: Space(5), SerializeField] public TrajectoryDot DotPrefab { get; private set; }
}
