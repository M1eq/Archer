using UnityEngine;

public class ArcherPresenter : MonoBehaviour
{
    [SerializeField] private Arrow _arrow;
    [SerializeField] private DragShooting _dragShooting;
    [SerializeField] private ArrowsFactory _arrowsFactory;
    [SerializeField] private TrajectoryShower _trajectoryShower;
    [SerializeField] private TrajectoryDotsFactory _trajectoryDotsFactory;

    private void OnDotsCreated(Transform[] createdDotsArray, GameObject dotsContainer)
    {
        _trajectoryShower.Initialize(createdDotsArray, dotsContainer);
        _trajectoryShower.HideTrajectory();
    }
    private void OnDragStarted()
    {
        _trajectoryShower.ShowTrajectory();
    }

    private void OnDragContinued(Vector3 aimPoint, Vector2 currentForce)
    {
        _trajectoryShower.UpdateTrajectory(aimPoint, currentForce);
    }

    private void OnDragEnded()  
    {
        _trajectoryShower.HideTrajectory();
    }
    private void Start()
    {
        _trajectoryDotsFactory.CreateDots();
        _arrowsFactory.TryCreateArrows();
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

        _trajectoryDotsFactory.DotsCreated += OnDotsCreated;
    }

    private void OnDisable()
    {
        _dragShooting.DragStarted -= OnDragStarted;
        _dragShooting.DragContinued -= OnDragContinued;
        _dragShooting.DragEnded -= OnDragEnded;

        _trajectoryDotsFactory.DotsCreated -= OnDotsCreated;
    }
}
