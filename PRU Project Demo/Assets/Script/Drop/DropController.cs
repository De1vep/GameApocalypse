using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    [System.Serializable]
    public class Drops
    {
        public string name;
        public GameObject prefab;
        public float rate;
    }

    [SerializeField] public List<Drops> drops;

	public void DropItem()
	{
        float r = Random.Range(0, 100);
        List<Drops> possibleDrop = new List<Drops>();
        foreach(Drops d in drops)
        {
            if(r <= d.rate)
            {
				possibleDrop.Add(d);		
            }
        }

        if(possibleDrop.Count > 0)
        {
            Drops d = possibleDrop[Random.Range(0, possibleDrop.Count)];
			Instantiate(d.prefab, transform.position, Quaternion.identity);
        }
	}
}
