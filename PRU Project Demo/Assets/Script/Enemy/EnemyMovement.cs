using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;

    [Header("Enemy stats")]
    [SerializeField] float MaxHealth;
    float Health;
    [SerializeField] float Speed;
    [SerializeField] float Damage;
    private Transform PlayerPos;

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        PlayerPos = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        PlayerPos = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //When you subtract one position vector from another,
        //you get a new vector that points from the position you subtracted from to the position you subtracted
        rb.velocity = (PlayerPos.position - transform.position ).normalized * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Prop"))
        {
            Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), collision.transform.GetComponent<BoxCollider2D>(), true);
        }

        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerMovement>().takeDamage(Damage);
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        Debug.Log(damage);
        if (Health <= 0 ) 
        {           
            Destroy(gameObject);
        }
    }
}
