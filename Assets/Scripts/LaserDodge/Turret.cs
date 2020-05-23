using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public float shotInterval;
    public Vector2 intervalRange;
    public float shotSpeed;
    public Vector2 shotSpeedRange;
    public Transform target;
    public GameObject bullet;
    public GameObject tool;

    private Vector3 shootDirection;

    private float pauseStateForceValue;
    private float pauseStateShootRateValue;

    private TurretManager manager;

    private float timer;

    private bool gameStarted;

    void OnEnable()
    {
        manager = GetComponentInParent<TurretManager>();
        if(manager != null)
        {
            manager.updateBulletSettings += UpdateShootSpeed;
            manager.updateTurretSettings += UpdateTurret;
            manager.startGame += StartTurret;
            manager.saveSettings += SaveCurrentSettings;
            manager.retrieveSettings += RetrieveSettings;
        }
    }

    public void StartTurret(bool value)
    {
        gameStarted = value;
    }

    //tracks the direction vector between turret point and target object (hand or head)
    void Update()
    {
        if (gameStarted)
        {
            shootDirection = transform.TransformDirection(target.position - transform.position);

            timer += Time.deltaTime;
            if (timer >= shotInterval)
            {
                if (shotInterval != 0f)
                {
                    ShootObjectCheck();
                    timer = 0f;
                }
                else
                {
                    timer = 0f;
                    gameStarted = false;
                    //setup restart functionality, called here
                }
            }
        }

    }

    //listening to value changes in the turret manager
    public void UpdateShootSpeed(float newSpeed)
    {
        shotSpeed = newSpeed;
    }

    //listening to value changes in the turret manager
    public void UpdateTurret(float newSpeed)
    {
        shotInterval = newSpeed;
    }

    //saves current shootRate and intervalRate to reuse after pause
    public void SaveCurrentSettings()
    {
        pauseStateForceValue = shotSpeed;
        pauseStateShootRateValue = shotInterval;
    }

    //on resumption of game, game settings are reset here
    public Vector2 RetrieveSettings()
    {
        Vector2 settings = new Vector2(pauseStateForceValue, pauseStateShootRateValue);
        StartTurret(true);
        return settings;
    }

    //at a particular difficulty, mix up the shoot speed
    public void VaryShootSpeed()
    {
        shotSpeed = Random.Range(shotSpeedRange.x, shotSpeedRange.y);
    }

    //at a particular difficulty, mix up the shot interval
    public void VaryInterval()
    {
        shotInterval = Random.Range(shotSpeedRange.x, shotSpeedRange.y);
    }

    //check which object to shoot (bullet or tool)
    private void ShootObjectCheck()
    {
        int probabilityValue = Random.Range(0, 30);
        if(probabilityValue <= 3)
        {
            ShootTool();
        }
        else
        {
            ShootBullet();
        }
    }

    //raycast probably not necessary but this method spawns a new bullet at spawn interval
    private void ShootBullet()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, shootDirection, out hit, 5f))
        {
            Debug.DrawRay(transform.position, shootDirection, Color.red);

            if(hit.collider.tag == "Target" || hit.collider.tag == "Shield")
            {
                GameObject newGO = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
                Bullet newBullet = newGO.GetComponent<Bullet>();
                newBullet.AssignSettings(shotSpeed, shootDirection);
            }
        }
    }

    //raycast probably not necessary but this method spawns a new bullet at spawn interval
    private void ShootTool()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, shootDirection, out hit, 5f))
        {
            Debug.DrawRay(transform.position, shootDirection, Color.red);

            if (hit.collider.tag == "Target" || hit.collider.tag == "Shield")
            {
                GameObject newGO = Instantiate(tool, transform.position, Quaternion.identity) as GameObject;
                Tool newBullet = newGO.GetComponent<Tool>();
                newBullet.AssignSettings(shotSpeed, shootDirection);
            }
        }
    }

    void OnDisable()
    {
        manager.updateBulletSettings -= UpdateShootSpeed;
        manager.updateTurretSettings -= UpdateTurret;
        manager.startGame -= StartTurret;
        manager.saveSettings -= SaveCurrentSettings;
        manager.retrieveSettings -= RetrieveSettings;
    }
}
