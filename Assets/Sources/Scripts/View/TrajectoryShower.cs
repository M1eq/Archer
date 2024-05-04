using UnityEngine;

public class TrajectoryShower : MonoBehaviour
{
    [SerializeField] private ArcherConfig _archerConfig;

    private GameObject _dotsContainer;
    private Transform[] _dotsArray;
    private Vector2 _dotPosition;
    private float _timeStamp;

    public void ShowTrajectory() => _dotsContainer.gameObject.SetActive(true);
    public void HideTrajectory() => _dotsContainer.gameObject.SetActive(false);

    public void Initialize(Transform[] createdDotsArray, GameObject dotsContainer)
    {
        _dotsArray = createdDotsArray;
        _dotsContainer = dotsContainer;
    }

    public void UpdateTrajectory(Vector3 arrowPosition, Vector2 currentForce)
    {
        _timeStamp = _archerConfig.SpacingBetweenDots;

        for (int i = 0; i < _dotsArray.Length; i++)
        {
            _dotPosition.x = (arrowPosition.x + currentForce.x * _timeStamp);
            _dotPosition.y = (arrowPosition.y + currentForce.y * _timeStamp) - (Physics2D.gravity.magnitude * _timeStamp * _timeStamp) / 2;

            _dotsArray[i].position = _dotPosition;
            _timeStamp += _archerConfig.SpacingBetweenDots;
        }
    }
}
