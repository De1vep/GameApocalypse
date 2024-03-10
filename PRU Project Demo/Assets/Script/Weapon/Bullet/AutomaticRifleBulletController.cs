using UnityEngine;

public class AutomaticRifleBulletController : BulletController
{
    protected AutomaticRifleController controller;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        controller = FindObjectOfType<AutomaticRifleController>();
        bulletSpawnPoint = controller.GunPoint.position;
        damage = controller.damage;
        range = controller.range;

        rb.velocity = transform.right * controller.speed;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90);       
    }
}
