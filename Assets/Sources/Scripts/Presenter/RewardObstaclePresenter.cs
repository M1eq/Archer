using UnityEngine;

public class RewardObstaclePresenter : MonoBehaviour
{
    [SerializeField] private RewardObstacle _rewardObstacle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Arrow>(out Arrow arrow))
            _rewardObstacle.ApplyReward(arrow.transform.position);
    }
}
