using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : WeaponController
{
    [SerializeField] protected int bulletPerShot;
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        base.Attack();

        for (int i = 0; i < bulletPerShot; i++)
        {
            if (i == 0)
            {
                Instantiate(prefab, GunPoint.position, Quaternion.Euler(GunPoint.eulerAngles.x, GunPoint.eulerAngles.y, GunPoint.eulerAngles.z - spread));
            }
            else if (i == bulletPerShot - 1)
            {
                Instantiate(prefab, GunPoint.position, Quaternion.Euler(GunPoint.eulerAngles.x, GunPoint.eulerAngles.y, GunPoint.eulerAngles.z + spread));
            }
            else
            {
                Instantiate(prefab, GunPoint.position, Quaternion.Euler(GunPoint.eulerAngles.x, GunPoint.eulerAngles.y, GunPoint.eulerAngles.z + Random.Range(-spread, spread)));
            }
        }

    }
}
