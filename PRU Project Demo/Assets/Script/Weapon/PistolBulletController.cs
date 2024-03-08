using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBulletController : BulletController
{
    private PistolController controller;
    [SerializeField] Rigidbody2D rb;
    private Camera mainCam;
    private Vector3 mousePos;
    float dis;
    private Vector2 bulletSpawnPoint;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        controller = FindObjectOfType<PistolController>();
        bulletSpawnPoint = controller.bulletPos.position;

        rb.velocity = new Vector2(dir.x, dir.y) * controller.speed;
        transform.up = dir;

    }

    private void Update()
    {
        dis = Vector2.Distance(transform.position, bulletSpawnPoint);
        if(dis >= controller.range)
        {
            Destroy(gameObject);
        }
    }

}
