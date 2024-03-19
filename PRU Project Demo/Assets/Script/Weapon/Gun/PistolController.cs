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
        Instantiate(gunData.prefab, gunPoint.position,
            Quaternion.Euler(gunPoint.eulerAngles.x,
            gunPoint.eulerAngles.y, gunPoint.eulerAngles.z),
            GameObject.Find("Bullet").transform);
    }
}
