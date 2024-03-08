using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    protected Vector3 dir;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, 5);       
    }

    public virtual void BulletDirection(Vector3 direction)
    {
        dir = direction;
    }
}
