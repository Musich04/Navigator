using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;

    private float _totalPoints;

    public void CalcPoints(float time)
    {
        _totalPoints = time;
        Text.text = _totalPoints.ToString();
    }
}
