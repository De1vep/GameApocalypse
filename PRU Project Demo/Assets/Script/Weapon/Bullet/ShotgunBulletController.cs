using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShotgunBulletController : BulletController
{
    protected ShotgunController controller;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        
        controller = FindObjectOfType<ShotgunController>();
        bulletSpawnPoint = controller.GunPoint.position;
        damage = controller.damage;
        range = controller.range;

        rb.velocity = transform.right * controller.speed;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90);        
    }   
}
