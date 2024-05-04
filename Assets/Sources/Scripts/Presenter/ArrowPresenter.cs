using UnityEngine;

public class ArrowPresenter : MonoBehaviour
{
    [SerializeField] private Arrow _arrow;

    private void Update() => _arrow.TryUpdateRotationAngle();
    private void OnCollisionEnter2D(Collision2D collision) => _arrow.FreezePosition();
}
