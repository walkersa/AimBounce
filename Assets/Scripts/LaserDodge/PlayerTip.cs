using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTip : MonoBehaviour
{
    private string tip;
    private TextMeshProUGUI tmText;
    private bool tipShowing;

    //add this method to any event that needs to speak to the tip text, like the collision tracker, tool etc
    public void ShowTip(string newTip)
    {
        if (!tipShowing)
        {
            tip = newTip;
            tmText = GetComponent<TextMeshProUGUI>();

            if (tmText == null)
            {
                Debug.LogError("no textmeshpro component found");
            }
            else
            {
                tmText.text = tip;
            }

            
            StartCoroutine(TipCounter());
        }
    }

    IEnumerator TipCounter()
    {
        
        yield return new WaitForSeconds(5f);

        tmText.text = "";
        tipShowing = false;

        yield return null;
    }
}
