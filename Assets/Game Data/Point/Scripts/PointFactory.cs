using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointFactory : MonoBehaviour
{
    public static PointFactory Instance { get; private set; }
    public event Action<GameObject> OnCteated;

    [SerializeField] private GameObject Point;

    private void Awake()
    {
        Instance = this;
    }

    private void OnValidate()
    {
        if (!Point.TryGetComponent(out Point point))
            Point = null;
    }

    public void GetPoint()
    {
        GameObject point = Instantiate(Point.gameObject);
        OnCteated?.Invoke(point);
    }
}
