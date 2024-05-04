using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private BoxCollider2D _collider;

    private bool _freezed = true;

    public void Push(Vector2 force) => _rigidbody.AddForce(force, ForceMode2D.Impulse);

    public void UnfreezePosition()
    {
        _rigidbody.isKinematic = false;
        _freezed = false;
    }

    public void FreezePosition()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = 0f;
        _rigidbody.isKinematic = true;
        _freezed = true;
    }

    public void TryUpdateRotationAngle()
    {
        if (_freezed == false)
        {
            float angle = Mathf.Atan2(_rigidbody.velocity.y, _rigidbody.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
