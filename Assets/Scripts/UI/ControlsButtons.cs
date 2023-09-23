using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsButtons : MonoBehaviour
{
    public void OpenControlsMenu()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ActivateControlsState();
        }
    }
}
