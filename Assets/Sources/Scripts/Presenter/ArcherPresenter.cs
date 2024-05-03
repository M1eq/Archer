using UnityEngine;

public class ArcherPresenter : MonoBehaviour
{
    [SerializeField] private Arrow _arrow;
    [SerializeField] private DragShooting _dragShooting;

    private void OnDragStarted()
    {

    }

    private void OnDragContinued()
    {

    }

    private void OnDragEnded()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _dragShooting.StartDrag();

        if (Input.GetMouseButtonUp(0))
            _dragShooting.EndDrag();

        if (_dragShooting.Dragging)
            _dragShooting.Drag();
    }

    private void OnEnable()
    {
        _dragShooting.DragStarted += OnDragStarted;
        _dragShooting.DragContinued += OnDragContinued;
        _dragShooting.DragEnded += OnDragEnded;
    }

    private void OnDisable()
    {
        _dragShooting.DragStarted -= OnDragStarted;
        _dragShooting.DragContinued -= OnDragContinued;
        _dragShooting.DragEnded -= OnDragEnded;
    }
}
