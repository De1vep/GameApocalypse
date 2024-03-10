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
        Instantiate(prefab, GunPoint.position, Quaternion.Euler(GunPoint.eulerAngles.x, GunPoint.eulerAngles.y, GunPoint.eulerAngles.z));
    }
}
