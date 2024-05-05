using UnityEngine;

public class ArcherPresenter : MonoBehaviour
{
    [SerializeField] private DragShooter _dragShooter;
    [SerializeField] private ArrowsFactory _arrowsFactory;
    [SerializeField] private TrajectoryShower _trajectoryShower;
    [SerializeField] private TrajectoryDotsFactory _trajectoryDotsFactory;
    [SerializeField] private ArcherAnimationLauncher _archerAnimationLauncher;

    private void OnDragStarted() => _trajectoryShower.ShowTrajectory();
    private void OnArrowsCreated() => TryInitializeDragShooter();

    private void TryInitializeDragShooter()
    {
        if (_arrowsFactory.TryGetDeactivatedArrow(out Arrow deactivatedArrow))
            _dragShooter.Initialize(deactivatedArrow);
    }

    private void OnDotsCreated(Transform[] createdDotsArray, GameObject dotsContainer)
    {
        _trajectoryShower.Initialize(createdDotsArray, dotsContainer);
        _trajectoryShower.HideTrajectory();
    }
    private void OnDragContinued(Vector3 aimPoint, Vector2 currentForce)
    {
        _trajectoryShower.UpdateTrajectory(aimPoint, currentForce);
        _archerAnimationLauncher.LaunchAimAnimation();
    }

    private void OnDragEnded()  
    {
        _trajectoryShower.HideTrajectory();
        _archerAnimationLauncher.LaunchShootAnimation();
        _arrowsFactory.TryRefreshPool();
        TryInitializeDragShooter();
    }

    private void Start()
    {
        _trajectoryDotsFactory.CreateDots();
        _arrowsFactory.TryCreateArrows();

        _archerAnimationLauncher.InitializeTargetBone();
        _archerAnimationLauncher.LaunchIdleAnimation();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _dragShooter.StartDrag();

        if (Input.GetMouseButtonUp(0))
            _dragShooter.EndDrag();

        if (_dragShooter.Dragging)
            _dragShooter.Drag();

        _archerAnimationLauncher.TryUpdateTargetBoneRotation();
    }

    private void OnEnable()
    {
        _dragShooter.DragContinued += OnDragContinued;
        _dragShooter.DragStarted += OnDragStarted;
        _dragShooter.DragEnded += OnDragEnded;

        _arrowsFactory.ArrowsCreated += OnArrowsCreated;
        _trajectoryDotsFactory.DotsCreated += OnDotsCreated;
    }

    private void OnDisable()
    {
        _dragShooter.DragContinued -= OnDragContinued;
        _dragShooter.DragStarted -= OnDragStarted;
        _dragShooter.DragEnded -= OnDragEnded;

        _arrowsFactory.ArrowsCreated -= OnArrowsCreated;
        _trajectoryDotsFactory.DotsCreated -= OnDotsCreated;
    }
}
