using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform playerPos;
    [SerializeField] private float spawnTime = 5;
    private float timer = 0;
    private float angle;
    private float disFromPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            //A full circle corresponds to an angle of 2 PI,
            //using the range from 0 to 2 PI ensures that the spawned objects are evenly distributed around the circle
            angle = Random.Range(0, 2 * Mathf.PI);
            disFromPlayer = Random.Range(15, 30);
            //Add playerPos because if not, it will spawn around the origin (0, 0, 0)
            Vector3 spawnPos = playerPos.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), playerPos.position.z) * disFromPlayer;
            Instantiate(prefab, spawnPos, Quaternion.identity);

            timer = spawnTime;
        }
    }

}
