using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class WalletAnimationLauncher
{
    public event UnityAction GetMoneyAnimationEnded;

    private Transform _targetTransform;
    private Sequence _getMoneySequence;
    private GameObject _coinPrefab;

    public WalletAnimationLauncher(Transform targetTransform)
    {
        _targetTransform = targetTransform;
    }

    public void LaunchGetMoneyAnimation()
    {
        GameObject coin = Object.Instantiate(_coinPrefab);
        coin.transform.localScale = Vector3.zero;

        _getMoneySequence = DOTween.Sequence();
        _getMoneySequence.Append(coin.transform.DOScale(1f, 0.25f));
        _getMoneySequence.Append(coin.transform.DOMove(
            _targetTransform.position, 0.5f)).OnComplete(() => DestroyCoin(coin));
    }

    private void DestroyCoin(GameObject coin)
    {
        Object.Destroy(coin);
        GetMoneyAnimationEnded?.Invoke();
    }
}
