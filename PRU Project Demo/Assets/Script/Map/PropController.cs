using System.Collections.Generic;
using UnityEngine;

public class PropController : MonoBehaviour
{
    [SerializeField] List<GameObject> props;
    [SerializeField] List<GameObject> propPositions;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var position in propPositions)
        {
            Instantiate(props[Random.Range(0, props.Count)], position.transform);
        }
    }

}
