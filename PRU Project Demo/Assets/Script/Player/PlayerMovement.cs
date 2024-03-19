using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Stat")]
    [SerializeField] PlayerStat playerData;

    [SerializeField] private Rigidbody2D rb;

    private float horizontal;
    private float vertical;
    [HideInInspector] public bool isDead = false;


    [HideInInspector] public Vector2 moveDir;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * playerData.currentSpeed, vertical * playerData.currentSpeed);
    }

}
