using UnityEngine;
using System;

public class CreationPointState : PlayerState
{
    public event Action OnExit;
    private GameObject _point;
    
    public CreationPointState(GameObject pointObj) : base()
    {
        _point = pointObj;
    }

    public override void ExecuteHit(RaycastHit hit)
    {
        if (hit.collider.name == "Field")
            _point.transform.localPosition = hit.point;
    }

    public override void Accept()
    {
        _point = null;
        OnExit?.Invoke();
        OnExit = null;
    }

    public override void Remove()
    {
        Destroy(_point);
        Accept();
    }

    private void OnDestroy()
    {
        OnExit = null;
    }
}
