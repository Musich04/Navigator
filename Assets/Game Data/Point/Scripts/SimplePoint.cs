using UnityEngine;

public class SimplePoint : PathPoint
{
    private bool _isAdded = false;
    private Material _material;
    private Color _origin = Color.black;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    public override void Add(Color color)
    {
        if (!_isAdded)
        {
            _origin = color;
            _material.color = _origin;
            _isAdded = true;
        }
    }

    public override void Remove()
    {
        _origin = Color.black;
        _material.color = _origin;
        _isAdded = false;
    }

    public override void Select()
    {
        _material.color = Color.green;
    }

    public override void Cancel()
    {
        _material.color = _origin;
    }
}
