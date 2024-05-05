using UnityEngine;

public class RewardObstacle : MonoBehaviour
{
    private RewardAnimationLauncher _rewardAnimationLauncher;

    public void ApplyReward(Vector3 position) => _rewardAnimationLauncher.LaunchGetMoneyAnimation(position);

    public void Initialize(RewardAnimationLauncher rewardAnimationLauncher) => 
        _rewardAnimationLauncher = rewardAnimationLauncher;
}
