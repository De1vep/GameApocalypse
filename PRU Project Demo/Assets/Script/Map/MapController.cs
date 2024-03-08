using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> terrains;
    [SerializeField] float radius;
    [SerializeField] LayerMask terrainMask;

    [HideInInspector] public GameObject currentTerrain;
    private Vector2 terrainPosition;
    
    private PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        checkTerrain();
    }

    void checkTerrain()
    {
        if (!currentTerrain)
        {
            return;
        }

        if (pm.moveDir.x > 0 && pm.moveDir.y == 0) //Right
        {
            if (!Physics2D.OverlapCircle(currentTerrain.transform.Find("Right").position, radius, terrainMask))
            {
                terrainPosition = currentTerrain.transform.Find("Right").position;
                SpawnTerrain();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y == 0) //Left
        {
            if (!Physics2D.OverlapCircle(currentTerrain.transform.Find("Left").position, radius, terrainMask))
            {
                terrainPosition = currentTerrain.transform.Find("Left").position;
                SpawnTerrain();
            }
        }
        else if (pm.moveDir.x == 0 && pm.moveDir.y > 0) //Up
        {
            if (!Physics2D.OverlapCircle(currentTerrain.transform.Find("Up").position, radius, terrainMask))
            {
                terrainPosition = currentTerrain.transform.Find("Up").position;
                SpawnTerrain();
            }
        }
        else if (pm.moveDir.x == 0 && pm.moveDir.y < 0) //Down
        {
            if (!Physics2D.OverlapCircle(currentTerrain.transform.Find("Down").position, radius, terrainMask))
            {
                terrainPosition = currentTerrain.transform.Find("Down").position;
                SpawnTerrain();
            }
        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y > 0) //Right Up
        {
            if (!Physics2D.OverlapCircle(currentTerrain.transform.Find("Right Up").position, radius, terrainMask))
            {
                terrainPosition = currentTerrain.transform.Find("Right Up").position;
                SpawnTerrain();
            }
        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y < 0) //Right Down
        {
            if (!Physics2D.OverlapCircle(currentTerrain.transform.Find("Right Down").position, radius, terrainMask))
            {
                terrainPosition = currentTerrain.transform.Find("Right Down").position;
                SpawnTerrain();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y > 0) //Left Up
        {
            if (!Physics2D.OverlapCircle(currentTerrain.transform.Find("Left Up").position, radius, terrainMask))
            {
                terrainPosition = currentTerrain.transform.Find("Left Up").position;
                SpawnTerrain();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0) //Left Down
        {
            if (!Physics2D.OverlapCircle(currentTerrain.transform.Find("Left Down").position, radius, terrainMask))
            {
                terrainPosition = currentTerrain.transform.Find("Left Down").position;
                SpawnTerrain();
            }
        }
    }

    void SpawnTerrain()
    {
        Instantiate(terrains[0], terrainPosition, Quaternion.identity);
    }
}
