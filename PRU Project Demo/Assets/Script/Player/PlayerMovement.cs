using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Stat")]
    [SerializeField] PlayerStat playerData;

    [SerializeField] private Rigidbody2D rb;

    [Header("Weapon")]
    [SerializeField] GameObject Pistol;
    [SerializeField] GameObject Shotgun;
    [SerializeField] GameObject AutomaticRifle;

    private float horizontal;
    private float vertical;


    [HideInInspector] public Vector2 moveDir;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * playerData.currentSpeed, vertical * playerData.currentSpeed);
    }

}
