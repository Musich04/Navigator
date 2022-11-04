using System.Collections;
using UnityEngine;
using System;

public class PointStateMashine : MonoBehaviour
{
    public event Action<PathPoint> OnSelectPoint;

    private PlayerState _state;
    private RayCreator _rayCreator;
    private PathPoint _selectedPoint;

    private void Awake()
    {
        _rayCreator = new RayCreator();
        _state = new SelectionState();
    }

    private void SetCreation(GameObject point)
    {
        SelectPoint(point.GetComponent<SimplePoint>());
        _state = new CreationPointState(point);
        Debug.Log("Point Creating State");
        ((CreationPointState)_state).OnExit += SetSelection;
    }

    private void SetSelection()
    {
        _state = new SelectionState();
        Debug.Log("Selection State");
        ((SelectionState)_state).OnSelected += SelectPoint;
        ((SelectionState)_state).OnRemove += RemovePoint;
    }

    private void TryHit()
    {
        RaycastHit hit = _rayCreator.SetHit();
        _state.ExecuteHit(hit);
    }

    private void SelectPoint(PathPoint point)
    {
        if (_selectedPoint != null)
            if (_selectedPoint.GetInstanceID() != point.GetInstanceID())
                _selectedPoint.Cancel();

        point.Select();
        _selectedPoint = point;
        OnSelectPoint?.Invoke(point);
    }

    private void RemovePoint()
    {
        if (_selectedPoint != null)
            _selectedPoint.Cancel();

        _selectedPoint = null;
        OnSelectPoint?.Invoke(null);
    }

    private void Update()
    {
        TryHit();
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
            _state.Accept();

        if (Input.GetMouseButtonDown(1))
            _state.Remove();
    }

    private void Start()
    {
        PointFactory.Instance.OnCteated += SetCreation;
    }

    private void OnDisable()
    {
        PointFactory.Instance.OnCteated -= SetCreation;
    }
}