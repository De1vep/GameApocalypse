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
				Instantiate(gunData.prefab, gunPoint.position, 
                    Quaternion.Euler(gunPoint.eulerAngles.x, 
                    gunPoint.eulerAngles.y, gunPoint.eulerAngles.z - currentSpread),
                    GameObject.Find("Bullet").transform);			
			}
            else if (i == bulletPerShot - 1)
            {
				Instantiate(gunData.prefab, gunPoint.position, 
                    Quaternion.Euler(gunPoint.eulerAngles.x, 
                    gunPoint.eulerAngles.y, gunPoint.eulerAngles.z + currentSpread),
                    GameObject.Find("Bullet").transform);
			}
            else
            {
                Instantiate(gunData.prefab, gunPoint.position, 
                    Quaternion.Euler(gunPoint.eulerAngles.x,
					gunPoint.eulerAngles.y,
					gunPoint.eulerAngles.z + Random.Range(-currentSpread, currentSpread)),
                    GameObject.Find("Bullet").transform);
            }
        }

    }
}
