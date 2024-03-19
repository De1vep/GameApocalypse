using UnityEngine;

public class ExpGem : MonoBehaviour
{
    [SerializeField] public int expMin;
    [SerializeField] public int expMax;

    private float exp;
    private Transform PlayerPos;
    private bool isColected = false;

    private void Awake()
    {
        exp = Random.Range(expMin, expMax + 1);
    }

    private void Update()
    {
        PlayerPos = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        if (PlayerPos != null && isColected)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = (PlayerPos.position - transform.position).normalized * 9;
        }

    }

    public void Collect()
    {
        isColected = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStat stat = FindObjectOfType<PlayerStat>();
            if (stat != null)
            {
                stat.IncreaseExp(exp);
                Destroy(gameObject);
            }
        }
    }
}
