using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class RewardAnimationLauncher
{
    public event UnityAction GetMoneyAnimationEnded;

    private CoinAnimationConfig _coinAnimationConfig;
    private Transform _targetTransform;
    private Sequence _getMoneySequence;
    private Canvas _parentCanvas;

    public RewardAnimationLauncher(Transform targetTransform, CoinAnimationConfig coinAnimationConfig, Canvas parentCanvas)
    {
        _targetTransform = targetTransform;
        _coinAnimationConfig = coinAnimationConfig;
        _parentCanvas = parentCanvas;
    }

    public void LaunchGetMoneyAnimation(Vector3 position)
    {
        Coin coin = Object.Instantiate(_coinAnimationConfig.CoinPrefab, _parentCanvas.transform);
        coin.transform.localScale = Vector3.zero;
        coin.transform.position = position;

        _getMoneySequence = DOTween.Sequence();
        _getMoneySequence.Append(coin.transform.DOScale(
            _coinAnimationConfig.TargetScale, _coinAnimationConfig.ScaleDuration));

        _getMoneySequence.Append(coin.transform.DOMove(_targetTransform.position, _coinAnimationConfig.MoveToTargetDuration)).
            OnComplete(() => DestroyCoin(coin));
    }

    private void DestroyCoin(Coin coin)
    {
        Object.Destroy(coin.gameObject);
        GetMoneyAnimationEnded?.Invoke();
    }
}
