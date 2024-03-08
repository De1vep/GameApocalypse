using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : WeaponController
{

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject bullet = Instantiate(prefab, bulletPos.position, Quaternion.identity);
        bullet.GetComponent<PistolBulletController>().BulletDirection(bulletPos.right);
    }
}
