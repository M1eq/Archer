using UnityEngine.Events;

public class Wallet 
{
    public event UnityAction<int> CoinCountChanged;

    private int _coinCount;

    public void TryAddCoin()
    {
        if (_coinCount + 1 < int.MaxValue)
        {
            _coinCount++;
            CoinCountChanged?.Invoke(_coinCount);
        }
    }
}
