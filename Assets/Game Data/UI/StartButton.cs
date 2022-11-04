using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : UIButton, IGameSubmission
{
    public void Play()
    {
        Disable();
    }

    public void Stop()
    {
        Enable();
    }
}
