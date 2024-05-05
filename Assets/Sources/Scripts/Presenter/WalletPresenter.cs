using UnityEngine;

public class WalletPresenter : MonoBehaviour
{
    [SerializeField] private CoinCountShower _coinCountShower;

    private Wallet _wallet;

    private void OnCoinCountChanged(int coinCount) => _coinCountShower.ShowCoinCount(coinCount);

    private void OnEnable()
    {
        if (_wallet == null)
            _wallet = new Wallet();

        _wallet.CoinCountChanged += OnCoinCountChanged;
    }

    private void OnDisable()
    {
        _wallet.CoinCountChanged -= OnCoinCountChanged;
    }
}
