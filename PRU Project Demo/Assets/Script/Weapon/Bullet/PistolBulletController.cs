using UnityEngine;

public class PistolBulletController : BulletController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        controller = FindObjectOfType<PistolController>();
        bulletSpawnPoint = controller.gunPoint.position;
        rb.velocity = transform.right * controller.currentSpeed;
    }

    protected override void Update()
    {
        base.Update();
        if (dis >= controller.currentRange)
        {
            Destroy(gameObject);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<EnemyStat>().TakeDamage(controller.currentDamage * playerData.currentDamageMultiplier);
            Destroy(gameObject);
        }
    }
}
