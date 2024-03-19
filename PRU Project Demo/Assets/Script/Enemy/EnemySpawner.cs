using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject boss;
    [SerializeField] private Transform playerPos;
    [SerializeField] private float spawnTime = 5;
    [Header("Time till boss")]
    [SerializeField] private int minute = 2;
    [SerializeField] private int second = 0;

    private float timer = 0;
    private float angle;
    private float disFromPlayer;
    private bool spawnBoss = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerMovement>().isDead)
        {
            return;
        }

        if(GameManager.instance.minute == minute && GameManager.instance.sencond == second && !spawnBoss)
        {
            angle = Random.Range(0, 2 * Mathf.PI);
            disFromPlayer = Random.Range(15, 30);
            //Add playerPos because if not, it will spawn around the origin (0, 0, 0)
            Vector3 spawnPos = playerPos.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), playerPos.position.z) * disFromPlayer;
            Instantiate(boss, spawnPos, Quaternion.identity, GameObject.Find("Enemy").transform);
            spawnBoss = true;
        }

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            //A full circle corresponds to an angle of 2 PI,
            //using the range from 0 to 2 PI ensures that the spawned objects are evenly distributed around the circle
            angle = Random.Range(0, 2 * Mathf.PI);
            disFromPlayer = Random.Range(15, 30);
            //Add playerPos because if not, it will spawn around the origin (0, 0, 0)
            Vector3 spawnPos = playerPos.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), playerPos.position.z) * disFromPlayer;
            Instantiate(prefab, spawnPos, Quaternion.identity, GameObject.Find("Enemy").transform);

            timer = spawnTime;
        }
    }

}
