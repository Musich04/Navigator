using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDeleter : MonoBehaviour
{
    public event System.Action<bool> OnSet;
    [SerializeField] private PointStateMashine InputMouse;

    private Point _point;

    private void Start()
    {
        OnSet?.Invoke(false);
    }

    public void Delete()
    {
        Destroy(_point.gameObject);
        _point = null;
        OnSet?.Invoke(false);
    }

    private void SetPoint(Point point)
    {
        if (point == null)
            _point = null;
        else
            _point = point;

        if (_point == null)
            OnSet?.Invoke(false);
        else
            OnSet?.Invoke(true);
    }

    private void OnEnable()
    {
        InputMouse.OnSelectPoint += SetPoint;
    }

    private void OnDisable()
    {
        InputMouse.OnSelectPoint -= SetPoint;
    }
}
