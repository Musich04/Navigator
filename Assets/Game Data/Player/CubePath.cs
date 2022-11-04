using System.Collections.Generic;
using UnityEngine;

public class CubePath : MonoBehaviour
{
    [SerializeField] private PointDeleter Deleter;
    [SerializeField] private Color SelectedColor;

    private List<PathPoint> _points;

    private void Awake()
    {
        _points = new List<PathPoint>();
    }

    public void Add(PathPoint point)
    {
        if (point == null)
            return;

        if (IsPointExist(point) == true)
            return;

        _points.Add(point);
        point.Add(SelectedColor);
    }

    public void Remove(PathPoint point)
    {
        if (IsPointExist(point) == false)
            return;

        _points.Remove(point);
        point.Remove();
    }

    public bool IsPointExist(PathPoint point)
    {
        if (_points.Exists(x => x.GetInstanceID() == point.GetInstanceID()))
            return true;
        else
            return false;
    }

    public void RemoveAll()
    {
        foreach (PathPoint point in _points)
            point.Remove();

        _points.Clear();
    }

    public List<Vector3> GetPath()
    {
        List<Vector3> path = new List<Vector3>();

        foreach (Point point in _points)
            path.Add(point.GetPoint());

        return path;
    }
}
