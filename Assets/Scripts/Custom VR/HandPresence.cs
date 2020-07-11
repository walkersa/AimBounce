using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{

    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;


    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    private Animator handAnimator;

    private bool canSpawnPad = true;

    #region EVENTS

    public delegate void OnPrimaryButtonPressed();
    public event OnPrimaryButtonPressed PrimaryButtonPressed;

    public delegate void OnSecondaryButtonPressed();
    public event OnPrimaryButtonPressed SecondaryButtonPressed;

    #endregion

    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log("find devices");
        TryInitializeControllers();
    }

    private void TryInitializeControllers()
    {
        FindTrackedDevices();
    }

    private void FindTrackedDevices()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        AssignControllers(devices);
    }

    private void AssignControllers(List<InputDevice> devices)
    {
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject controllerModel = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (controllerModel)
            {
                spawnedController = Instantiate(controllerModel, transform);
            }
            else
            {
                Debug.Log("Did not find corresponding controller model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);

            }

            spawnedHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }

        ShowPlayerSelectedHandModel(showController);
    }

    public void ShowPlayerSelectedHandModel(bool value)
    {

        if (value)
        {
            spawnedHandModel.SetActive(false);
            spawnedController.SetActive(true);
        }
        else
        {
            spawnedController.SetActive(false);
            spawnedHandModel.SetActive(true);
        }
    }

    private void UpdateHandAnimation()
    {
        Debug.Log("animate hand");
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
    }

    private void CheckPrimaryButtonAXPressed()
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonPressed))
        {
            if (primaryButtonPressed)
                PrimaryButtonPressed();
        }

    }

    private void CheckSecondaryButtonBYPressed()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonPressed))
        {
            if (secondaryButtonPressed)
            {
                if (canSpawnPad)
                {
                    SecondaryButtonPressed();
                    canSpawnPad = false;
                }
            }

            if (!secondaryButtonPressed)
                canSpawnPad = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetDevice.isValid)
        {
            TryInitializeControllers();
            
        }
        else
        {
            UpdateHandAnimation();
            CheckPrimaryButtonAXPressed();
            CheckSecondaryButtonBYPressed();
        }

        
    }
}
