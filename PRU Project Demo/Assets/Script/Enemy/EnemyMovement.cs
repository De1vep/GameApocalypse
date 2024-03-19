using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] EnemyStat enemyData;

    private Transform PlayerPos;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        PlayerPos = GameObject.Find("Player").transform;

        moveDirection = (PlayerPos.position - transform.position).normalized;
        if (moveDirection.x > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveDirection.x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //When you subtract one position vector from another,
        //you get a new vector that points from the position you subtracted from to the position you subtracted
        if (!GetComponent<EnemyStat>().isDead)
        {
            rb.velocity = moveDirection.normalized * enemyData.currentSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Prop"))
        {
            Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), collision.transform.GetComponent<BoxCollider2D>(), true);
        }
    }
}
