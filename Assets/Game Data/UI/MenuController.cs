using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour, IGameSubmission
{
    private UIMenu _menu;

    private void Awake()
    {
        _menu = GetComponent<UIMenu>();
    }

    public void Play()
    {
        _menu.HidePanel();
    }

    public void Stop()
    {
        _menu.ShowPanel();
    }
}
