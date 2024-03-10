using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Stat")]
    [SerializeField] float Speed = 8;
    [SerializeField] private float MaxHealth = 50;
    private float health;

    [SerializeField] private Rigidbody2D rb;

    [Header("Weapon")]
    [SerializeField] GameObject Pistol;
    [SerializeField] GameObject Shotgun;
    [SerializeField] GameObject AutomaticRifle;

    private float horizontal;
    private float vertical;
    private bool isFacingRight = true;

    private bool isInvincible = false;
    private float iFrameDuration = 0.5f;

    [HideInInspector] public Vector2 moveDir;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetButton("Jump"))
        {
            Time.timeScale = 0;
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            Pistol.SetActive(true);
            Shotgun.SetActive(false);
            AutomaticRifle.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Pistol.SetActive(false);
            Shotgun.SetActive(true);
            AutomaticRifle.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Pistol.SetActive(false);
            Shotgun.SetActive(false);
            AutomaticRifle.SetActive(true);
        }


        //Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * Speed, vertical * Speed);

    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0)
        {
            isFacingRight = !isFacingRight;
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    public void takeDamage(float damage)
    {
        if (isInvincible)
        {
            iFrameDuration -= Time.deltaTime;
            if (iFrameDuration <= 0)
            {
                isInvincible = false;
            }
        }
        else
        {
            health -= damage;
            Debug.Log(health);
            if(health <= 0)
            {
                Destroy(gameObject);
            }
            isInvincible = true;
            iFrameDuration = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isInvincible = false;
            iFrameDuration = 1;
        }
    }
}
