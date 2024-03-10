using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] public Camera mainCam;
    [SerializeField] public Transform GunPoint;

    [Header("Weapon stats")]
    [SerializeField] public GameObject prefab;
    [SerializeField] public float damage;
    [SerializeField] public float speed;
    [SerializeField] public float fireRate;
    [SerializeField] public int pierce;
    [SerializeField] public float range;
    [SerializeField] public float spread;

    protected float timer;
    protected bool canFire;
    
    protected Vector3 mousePos;
    protected Vector3 rotation;

    // Update is called once per frame
    protected virtual void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                canFire = true;
            }
        }

        if (canFire && Input.GetMouseButton(0))
        {
            Attack();
            
        }
    }

    protected virtual void Attack()
    {
        timer = fireRate;
        canFire = false;        
    }
   
}
