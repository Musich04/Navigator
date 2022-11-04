using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class Cube : MonoBehaviour
{
    public event Action OnFinish;
    public bool IsEnabled { get; private set; }

    [SerializeField] private CubePath Path;

    private List<Vector3> _path = new List<Vector3>();
    private Vector3 _startPosition;
    private Vector3 _lastPosition;
    private Vector3 _currentPoint;
    private int number = 0;

    private void Start()
    {
        IsEnabled = false;
        _startPosition = FindObjectOfType<StartPoint>().GetPoint();
        _lastPosition = FindObjectOfType<FinishPoint>().GetPoint();
        transform.position = _startPosition;
    }

    private void MoveToPoint(Vector3 position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, 0.1f);
    }

    private void SetPath()
    {
        _path = Path.GetPath();
        _path.Add(_lastPosition);
    }

    private bool IsBusy(Vector3 position)
    {
        if (Vector3.Distance(transform.position, position) >= 0.1f)
            return true;
        else
            return false;
    }
    public void Play()
    {
        SetPath();
        number = 0;
        SetNextPoint(number);
        IsEnabled = true;
    }

    public void Stop()
    {
        IsEnabled = false;
        transform.position = _startPosition;
    }

    private void SetNextPoint(int number)
    {
        _currentPoint = _path[number];
    }

    private void Update()
    {
        if (IsEnabled)
        {
            MoveToPoint(_currentPoint);
            if (IsBusy(_currentPoint))
                return;

            number++;

            if (number < _path.Count)
                SetNextPoint(number);
            else
            {
                Stop();
                OnFinish?.Invoke();
            }
        }
    }
}
