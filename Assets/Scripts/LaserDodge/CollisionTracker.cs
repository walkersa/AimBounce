using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionTracker : MonoBehaviour
{
    public UnityEvent UpdateScore;

    public UnityEvent UpdateTool;

    public UnityEvent GivePlayerTip;

    private string assignedTag;


    void Start()
    {
        assignedTag = gameObject.tag;
    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            BulletHit();
            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "Tool" && gameObject.name != "HeadTarget")
        {
            ToolHit();
            Destroy(col.gameObject);
        }
    }

    private void BulletHit()
    {
        if (assignedTag == "Target")
        {
            //punish player for being hit by bullet
            UpdateScore.Invoke();
        }
        else if (assignedTag == "Net")
        {
            //maybe reward player for dodging bullet
        }
    }

    private void ToolHit()
    {
        if (assignedTag == "Target")
        {
            //Equip player with tool
            UpdateTool.Invoke();
        }
        else if (assignedTag == "Net")
        {
            //maybe prompt player to 'hit' these types of object as they might be useful
            GivePlayerTip.Invoke();
        }
    }
}
