using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : UIButton, IGameSubmission
{
    private void Start()
    {
        Disable();
    }

    public void Play()
    {
        Enable();
    }

    public void Stop()
    {
        Disable();
    }
}
