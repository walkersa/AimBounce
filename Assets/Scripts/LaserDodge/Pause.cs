using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    private bool pauseGame = false;
    public TextMeshProUGUI text;

    public void PauseBottonPressed()
    {
        if (!pauseGame)
        {
            text.text = "Resume Game";
        }
        else
        {
            text.text = "Pause Game";
        }
    }
}
