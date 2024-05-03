using UnityEngine;

public class TrajectoryShower : MonoBehaviour
{
    [SerializeField] private int _dotsNumber;
    [SerializeField] private float _dotSpacing;
    [SerializeField] private GameObject _dotPrefab;
    [SerializeField] private GameObject _dotsContainer;

    private Transform[] _dotsList;
    private Vector2 _position;
    private float _timeStamp;
    private float _dotMaxScale = 0.5f;
    private float _dotMinScale = 0.1f;

    public void ShowTrajectory() => _dotsContainer.gameObject.SetActive(true);
    public void HideTrajectory() => _dotsContainer.gameObject.SetActive(false);

    public void UpdateTrajectory(Vector3 arrowPosition, Vector2 currentForce)
    {
        _timeStamp = _dotSpacing;

        for (int i = 0; i < _dotsNumber; i++)
        {
            _position.x = (arrowPosition.x + currentForce.x * _timeStamp);
            _position.y = (arrowPosition.y + currentForce.y * _timeStamp)-(Physics2D.gravity.magnitude * _timeStamp * _timeStamp) / 2;

            _dotsList[i].position = _position;
            _timeStamp += _dotSpacing;
        }
    }

    private void Start()
    {
        HideTrajectory();
        CreateDots();
    }

    private void CreateDots()
    {
        _dotsList = new Transform[_dotsNumber];
        _dotPrefab.transform.localScale = Vector3.one * _dotMaxScale;

        float scale = _dotMaxScale;
        float scaleFactor = scale / _dotsNumber;

        for (int i = 0; i < _dotsNumber; i++)
        {
            _dotsList[i] = Instantiate(_dotPrefab, null).transform;
            _dotsList[i].parent = _dotsContainer.transform;

            _dotsList[i].localScale = Vector3.one * scale;
            if (scale > _dotMinScale)
                scale -= scaleFactor;
        }
    }
}
