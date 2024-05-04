using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ArrowsFactory : MonoBehaviour
{
    public event UnityAction ArrowsCreated;

    [SerializeField] private GameObject _arrowsContainer;
    [SerializeField] private ArcherConfig _archerConfig;

    private List<Arrow> _pool = new List<Arrow>();

    public bool TryGetDeactivatedArrow(out Arrow deactivatedArrow)
    {
        deactivatedArrow = _pool.First(effectAtPool => effectAtPool.gameObject.activeSelf == false);
        deactivatedArrow.FreezePosition();

        return deactivatedArrow != null;
    }

    public void TryCreateArrows()
    {
        if (_archerConfig != null)
        {
            for (int i = 0; i < _archerConfig.ArrowsInPool; i++)
            {
                Arrow createdObject = Instantiate(_archerConfig.ArrowPrefab, _arrowsContainer.transform);
                createdObject.gameObject.SetActive(false);

                _pool.Add(createdObject);
            }

            ArrowsCreated?.Invoke();
        }
    }

    public void TryRefreshPool()
    {
        int activatedArrows = 0;

        for (int i = 0; i < _pool.Count; i++)
        {
            if (_pool[i].gameObject.activeInHierarchy == true)
                activatedArrows++;
        }

        if (activatedArrows >= _archerConfig.ArrowsForPoolRefresh)
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (_pool[i].gameObject.activeInHierarchy == true)
                    _pool[i].gameObject.SetActive(false);
            }
        }
    }
}
