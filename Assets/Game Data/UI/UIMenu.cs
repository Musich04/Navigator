using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    private IActivity _panel;

    private void Awake()
    {
        _panel = transform.GetChild(0).GetComponent<IActivity>();
    }

    public void ShowPanel() => _panel.Show();
    public void HidePanel() => _panel.Hide();

}
