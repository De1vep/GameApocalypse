using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] public GunScriptableObject gunData;
    [SerializeField] public Transform gunPoint;

    [HideInInspector] public float currentDamage;
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public float currentFireRate;
    [HideInInspector] public int currentPierce;
    [HideInInspector] public float currentRange;
    [HideInInspector] public float currentSpread;

    private Camera mainCam;

    protected float timer;
    protected bool canFire;

    protected Vector3 mousePos;
    protected Vector3 rotation;

    private void Awake()
    {
        gunData = CharacterSelect.GetGunData();

        CharacterSelect.instance.DestroySingleton();

        currentDamage = gunData.damage;
        currentSpeed = gunData.speed;
        currentFireRate = gunData.fireRate;
        currentPierce = gunData.pierce;
        currentRange = gunData.range;
        currentSpread = gunData.spread;

        mainCam = Camera.main;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (FindObjectOfType<PlayerMovement>().isDead)
        {
            return;
        }

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        if (rotZ > 90 || rotZ < -90)
        {
            transform.rotation = Quaternion.Euler(0, 180, 180 - rotZ);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }


        if (!canFire)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
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

        timer = currentFireRate;
        canFire = false;
    }

}
