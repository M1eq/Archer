using TMPro;
using UnityEngine;

public class CoinCountShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinCountText;

    public void ShowCoinCount(int coinCount) => _coinCountText.text = coinCount.ToString();
}
