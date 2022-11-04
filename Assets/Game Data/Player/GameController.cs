using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] private PointsSystem PointsSystem;
    private IEnumerable<IGameSubmission> _submissions;
    private List<Cube> _cubes = new List<Cube>();
    private Timer _timer = new Timer();

    private List<Cube> FindCubes()
    {
        IEnumerable<Cube> cubes = FindObjectsOfType<MonoBehaviour>().OfType<Cube>();
        return new List<Cube>(cubes);
    }
    private IEnumerable<IGameSubmission> FindSumbissionObjects() => FindObjectsOfType<MonoBehaviour>().OfType<IGameSubmission>();

    private void Start()
    {
        _submissions = FindSumbissionObjects();
        _cubes = FindCubes();

        foreach (var cube in _cubes)
            cube.OnFinish += CheckCubes;
    }

    private void CheckCubes()
    {
        if (_cubes.All(x => x.IsEnabled == false))
        {
            StopAll();

            float time = Mathf.Ceil((float)_timer.CalcDifference());
            PointsSystem.CalcPoints(time);
        }
    }

    public void Play()
    {
        _timer.StartTimer();

        foreach (var submission in _submissions)
            submission.Play();

        foreach (var cube in _cubes)
            cube.Play();
    }

    public void StopAll()
    {
        _timer.StopTimer();

        foreach (var submission in _submissions)
            submission.Stop();

        foreach (var cube in _cubes)
            cube.Stop();
    }

    private void OnDestroy()
    {
        foreach (var cube in _cubes)
            cube.OnFinish -= CheckCubes;
    }
}
