using UnityEngine;
using UnityEngine.UI;

public class WalletPresenter : MonoBehaviour
{
    [SerializeField] private CoinAnimationConfig _coinAnimationConfig;
    [Space(10), SerializeField] private Canvas _uiCanvas;
    [SerializeField] private Image _coinImage;
    [SerializeField] private CoinCountShower _coinCountShower;
    [Space(10), SerializeField] private RewardObstacle[] _rewardObstacles;

    private RewardAnimationLauncher _rewardAnimationLauncher;
    private Wallet _wallet;

    private void OnCoinCountChanged(int coinCount) => _coinCountShower.ShowCoinCount(coinCount);
    private void OnGetMoneyAnimationEnded() => _wallet.TryAddCoin();

    private void TryInitializeWallet()
    {
        if (_wallet == null)
            _wallet = new Wallet();
    }

    private void TryInitializeAnimationLauncher()
    {
        if (_rewardAnimationLauncher == null)
            _rewardAnimationLauncher = new RewardAnimationLauncher(_coinImage.transform, _coinAnimationConfig, _uiCanvas);
    }

    private void OnEnable()
    {
        TryInitializeWallet();
        TryInitializeAnimationLauncher();

        _wallet.CoinCountChanged += OnCoinCountChanged;
        _rewardAnimationLauncher.GetMoneyAnimationEnded += OnGetMoneyAnimationEnded;

        for (int i = 0; i < _rewardObstacles.Length; i++)
            _rewardObstacles[i].Initialize(_rewardAnimationLauncher);
    }

    private void OnDisable()
    {
        _wallet.CoinCountChanged -= OnCoinCountChanged;
        _rewardAnimationLauncher.GetMoneyAnimationEnded -= OnGetMoneyAnimationEnded;
    }
}
