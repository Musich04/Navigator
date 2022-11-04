using UnityEngine;
using System;

public class PointCollider : MonoBehaviour
{
    public event Action OnDown;
    protected bool _isSelected = false;

    protected void Select()
    {
        _isSelected = true;
        OnDown?.Invoke();
    }

    protected virtual void OnMouseDown()
    {
        Select();
    }
}