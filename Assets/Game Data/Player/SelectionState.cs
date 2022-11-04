using UnityEngine;
using System;

public class SelectionState : PlayerState
{
    public event Action<PathPoint> OnSelected;
    public event Action OnRemove;
    private PathPoint _point;
    private RaycastHit _hit;

    public override void ExecuteHit(RaycastHit hit)
    {
        _hit = hit;
    }

    public override void Accept()
    {
        if (_hit.collider.TryGetComponent(out PathPoint point))
        {
            _point = point;
            OnSelected?.Invoke(_point);
        }
    }

    public override void Remove()
    {
        _point = null;
        OnRemove?.Invoke();
    }


    private void OnDestroy()
    {
        OnRemove?.Invoke();
        OnSelected = null;
        OnRemove = null;
    }
}
