using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] private Transform crosshairTarget;
    [SerializeField] private TPS_Camera tpsCam;
    [SerializeField] private FPS_Camera fpsCam;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform bulletSpawn;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.LookAt(crosshairTarget);
    }

    public void Shoot()
    {
        Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
    }
}
