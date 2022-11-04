using UnityEngine;

public class PointPathButton : UIButton
{
    [SerializeField] private PointDeleter Deleter;
    [SerializeField] private PathSelecter PathSelecter;
    private bool _isPointSelected = false;
    private bool _isPathSelected = false;
    
    private void Start()
    {
        Disable();
    }

    private void SetPoint(bool value)
    {
        _isPathSelected = value;
        SetState();
    }

    private void SetPath()
    {
        _isPointSelected = true;
        SetState();
    }

    private void SetState()
    {
        if (_isPointSelected && _isPathSelected)
            Enable();
        else
            Disable();
    }

    private void OnEnable()
    {
        Deleter.OnSet += SetPoint;
        PathSelecter.OnSelet += SetPath;
    }

    private void OnDisable()
    {
        Deleter.OnSet -= SetPoint;
        PathSelecter.OnSelet -= SetPath;
    }
}