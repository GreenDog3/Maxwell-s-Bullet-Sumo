using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultySwitch : MonoBehaviour
{
    public void SetDifficulty(bool isHard)
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.hardModeActive = isHard; return;
        }
    }
}
