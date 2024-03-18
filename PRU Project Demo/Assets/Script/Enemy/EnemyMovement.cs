using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] EnemyStat enemyData;

    private Transform PlayerPos;

    // Start is called before the first frame update
    void Start()
    {
		if (GameObject.Find("Player").transform == null)
		{
			return;
		}
		PlayerPos = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if(GameObject.Find("Player").transform == null)
        {
            return;
        }
        PlayerPos = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //When you subtract one position vector from another,
        //you get a new vector that points from the position you subtracted from to the position you subtracted
        if(PlayerPos != null)
        {
			rb.velocity = (PlayerPos.position - transform.position).normalized * enemyData.currentSpeed;
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
