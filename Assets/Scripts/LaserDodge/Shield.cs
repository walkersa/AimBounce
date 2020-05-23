using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shield;
    private bool shieldActive;

    //called from collision event - attach shield to hand hit (not head) at specific attach point
    public void SpawnShield()
    {
        if (!shieldActive)
        {
            shieldActive = true;
            GameObject newShield = Instantiate(shield, transform.position, Quaternion.identity) as GameObject;
            newShield.transform.SetParent(transform);
            StartCoroutine(ShieldTimer());
        }
    }

    IEnumerator ShieldTimer()
    {
        //in future do check for progress in game and set time shield is active accordingly (shorter the further along player is)
        yield return new WaitForSeconds(10f);

        ShieldCollision currentShield = GetComponentInChildren<ShieldCollision>();
        Destroy(currentShield.gameObject);
        shieldActive = false;

        yield return null;
    }
}
