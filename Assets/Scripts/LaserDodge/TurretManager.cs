using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurretManager : MonoBehaviour
{

    public delegate void UpdateBulletSettings(float newValue);
    public event UpdateBulletSettings updateBulletSettings;

    public delegate void UpdateTurretSettings(float newValue);
    public event UpdateTurretSettings updateTurretSettings;

    public delegate void SaveSettings();
    public event SaveSettings saveSettings;

    public delegate Vector2 RetrieveSettings();
    public event RetrieveSettings retrieveSettings;

    public delegate void GameStart(bool newValue);
    public event GameStart startGame;


    //called from start button press
    public void StartGame(bool value)
    {
        startGame(value);
    }

    //called on button press (physical or controller)
    public void PauseGame()
    {
        saveSettings();
        UpdateForceValue(0f);
        UpdateShootRateValue(0f);
    }

    //called on button press (physical or controller)
    public void ResumeGame()
    {
        Vector2 retrievedValues = retrieveSettings();
        UpdateForceValue(retrievedValues.x);
        UpdateShootRateValue(retrievedValues.y);
    }


    //data fed into this method from the UI settings
    public void UpdateForceValue(float newValue)
    {
        updateBulletSettings(newValue);
    }

    //data fed into this method from the UI settings
    public void UpdateShootRateValue(float newValue)
    {
        updateTurretSettings(newValue);
    }

    //subscribes via Unity Event to the Score
    public void GameOver()
    {
        UpdateForceValue(0);
        UpdateShootRateValue(0);
    }


}
