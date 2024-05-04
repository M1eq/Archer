using UnityEngine;
using UnityEngine.Events;

public class DragShooter : MonoBehaviour
{
    public bool Dragging => _dragging;

    public event UnityAction<Vector3, Vector2> DragContinued;
    public event UnityAction DragStarted;
    public event UnityAction DragEnded;

    [SerializeField] private ArcherConfig _archerConfig;
    [SerializeField] private Transform _aimPoint;

    private bool _dragging;
    private float _distance;
    private Camera _mainCamera;
    private Arrow _arrow;
    private Vector2 _startDragPoint;
    private Vector2 _endDragPoint;
    private Vector2 _shootForce;
    private Vector2 _direction;

    public void Initialize(Arrow deactivatedArrow)
    {
        _arrow = deactivatedArrow;
        _arrow.transform.localScale = Vector3.one;
        _arrow.transform.position = _aimPoint.position;
        _arrow.transform.rotation = Quaternion.identity;
    }

    public void StartDrag()
    {
        _dragging = true;
        DragStarted?.Invoke();

        _arrow.FreezePosition();
        _startDragPoint = new Vector2(_aimPoint.position.x, _aimPoint.position.y);
    }

    public void EndDrag()
    {
        _dragging = false;
        DragEnded?.Invoke();

        _arrow.gameObject.SetActive(true);
        _arrow.UnfreezePosition();
        _arrow.Push(_shootForce);
    }

    public void Drag()
    {
        _endDragPoint = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        _distance = Vector2.Distance(_startDragPoint, _endDragPoint);
        _direction = (_startDragPoint - _endDragPoint).normalized;
        _shootForce = _direction * _distance * _archerConfig.PushForce;

        DragContinued?.Invoke(_aimPoint.position, _shootForce);
    }

    private void Start() => _mainCamera = Camera.main;
}
