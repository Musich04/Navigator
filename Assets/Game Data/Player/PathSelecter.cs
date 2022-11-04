using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathSelecter : MonoBehaviour
{
    public event Action OnSelet;
    [SerializeField] private PointStateMashine PointMashine;
    [SerializeField] private List<CubePath> PathList;

    private CubePath _currentPath;
    private PathPoint _point;

    public void Select(int number)
    {
        _currentPath = PathList[number];
        OnSelet?.Invoke();
    }

    public void AddPoint()
    {
        foreach (var path in PathList)
            if (path.IsPointExist(_point))
                return;

        _currentPath.Add(_point);
    }

    public void DeletePoint()
    {
        foreach (var path in PathList)
            if (path.IsPointExist(_point))
                path.Remove(_point);
    }

    public void DeletePath()
    {
        _currentPath.RemoveAll();
    }

    private void SetPoint(PathPoint point)
    {
        _point = point;
    }

    private void OnEnable()
    {
        PointMashine.OnSelectPoint += SetPoint;
    }

    private void OnDisable()
    {
        PointMashine.OnSelectPoint -= SetPoint;
    }
}
