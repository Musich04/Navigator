using UnityEngine;

public class PointDeleterButton : UIButton
{
    [SerializeField] private PointDeleter Deleter;

    private void Start()
    {
        Disable();
    }

    private void SelectState(bool value)
    {
        if (value == true)
            Enable();
        else
            Disable();
    }

    private void OnEnable()
    {
        Deleter.OnSet += SelectState;
    }

    private void OnDisable()
    {
        Deleter.OnSet -= SelectState;
    }
}
