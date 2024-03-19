using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropController : MonoBehaviour
{
    [System.Serializable]
    public class Drops
    {
        //public string name;
        public GameObject prefab;
        public float rate;
    }

    [SerializeField] public List<Drops> drops;

    public void DropItem()
    {
        float r = Random.Range(0, 100);
        List<Drops> possibleDrop = new List<Drops>();
        foreach (Drops d in drops)
        {
            if (r <= d.rate)
            {
                possibleDrop.Add(d);
            }
        }

        Drops drop = possibleDrop.Where(d => d.rate == possibleDrop.Min(d => d.rate)).FirstOrDefault();
        Instantiate(drop.prefab, transform.position, Quaternion.identity);

    }
}
