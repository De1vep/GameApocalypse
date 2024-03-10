using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;

    protected Vector2 bulletSpawnPoint;  
    protected float damage;
    protected float range;

    protected float dis;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, 5);        
    }

    protected virtual void Update()
    {
        dis = Vector2.Distance(transform.position, bulletSpawnPoint);
        if (dis >= range)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<EnemyMovement>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
