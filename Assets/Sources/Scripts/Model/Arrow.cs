using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private BoxCollider2D _collider;

    public void Push(Vector2 force) => _rigidbody.AddForce(force, ForceMode2D.Impulse);
    public void UnfreezePosition() => _rigidbody.isKinematic = false;

    public void FreezePosition()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = 0f;
        _rigidbody.isKinematic = true;
    }
}
