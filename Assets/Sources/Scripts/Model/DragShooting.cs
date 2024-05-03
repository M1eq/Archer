using UnityEngine;
using UnityEngine.Events;

public class DragShooting : MonoBehaviour
{
    public bool Dragging => _dragging;

    public event UnityAction<Vector3, Vector2> DragContinued;
    public event UnityAction DragStarted;
    public event UnityAction DragEnded;

    [SerializeField] private Transform _archerTransform;
    [SerializeField] private Arrow _arrow;

    private bool _dragging;
    private float _distance;
    private Camera _mainCamera;
    private Vector2 _startDragPoint;
    private Vector2 _endDragPoint;
    private Vector2 _direction;
    private Vector2 _shootForce;

    private float _pushForce = 4;

    public void StartDrag()
    {
        _dragging = true;
        DragStarted?.Invoke();

        _arrow.FreezePosition();
        _startDragPoint = new Vector2(_archerTransform.position.x, _archerTransform.position.y);
    }

    public void EndDrag()
    {
        _dragging = false;
        DragEnded?.Invoke();

        _arrow.UnfreezePosition();
        _arrow.Push(_shootForce);
    }

    public void Drag()
    {
        _endDragPoint = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        _distance = Vector2.Distance(_startDragPoint, _endDragPoint);
        _direction = (_startDragPoint - _endDragPoint).normalized;
        _shootForce = _direction * _distance * _pushForce;

        DragContinued?.Invoke(_archerTransform.position, _shootForce);
    }

    private void Start() => _mainCamera = Camera.main;
}
