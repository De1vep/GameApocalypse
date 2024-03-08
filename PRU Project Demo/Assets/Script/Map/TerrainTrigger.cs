using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTrigger : MonoBehaviour
{
    MapController controller;
    [SerializeField] GameObject targetTerrain;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Map Controller").GetComponent<MapController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            controller.currentTerrain = targetTerrain;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(controller.currentTerrain == targetTerrain)
            {
                controller.currentTerrain = null;
            }
        }
    }
}
