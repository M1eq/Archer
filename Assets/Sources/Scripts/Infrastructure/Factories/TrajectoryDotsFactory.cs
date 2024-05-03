using UnityEngine;
using UnityEngine.Events;

public class TrajectoryDotsFactory : MonoBehaviour
{
    public event UnityAction<Transform[], GameObject> DotsCreated;

    [SerializeField] private ArcherConfig _archerConfig;
    [SerializeField] private GameObject _dotsContainer;

    private Transform[] _createdDotsArray;

    public void CreateDots()
    {
        _createdDotsArray = new Transform[_archerConfig.DotsCount];
        _archerConfig.DotPrefab.transform.localScale = Vector3.one * _archerConfig.DotMaxScale;

        float maxScale = _archerConfig.DotMaxScale;
        float scaleFactor = maxScale / _archerConfig.DotsCount;

        for (int i = 0; i < _archerConfig.DotsCount; i++)
        {
            _createdDotsArray[i] = Instantiate(_archerConfig.DotPrefab, null).transform;
            _createdDotsArray[i].parent = _dotsContainer.transform;
            _createdDotsArray[i].localScale = Vector3.one * maxScale;

            if (maxScale > _archerConfig.DotMinScale)
                maxScale -= scaleFactor;
        }

        DotsCreated?.Invoke(_createdDotsArray, _dotsContainer);
    }
}
