using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    //[SerializeField] protected GunScriptableObject gunData;

    protected Vector2 bulletSpawnPoint;
    protected WeaponController controller;
    protected PlayerStat playerData;

    protected float dis;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        playerData = FindObjectOfType<PlayerStat>();

        Destroy(gameObject, 5);

        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    protected virtual void Update()
    {
        dis = Vector2.Distance(transform.position, bulletSpawnPoint);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
