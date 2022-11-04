using UnityEngine;

public class PathButton : UIButton
{
    [SerializeField] private PathSelecter PathSelecter;

    private void Start()
    {
        Disable();
    }

    private void OnEnable()
    {
        PathSelecter.OnSelet += Enable;
    }

    private void OnDisable()
    {
        PathSelecter.OnSelet -= Enable;
    }
}