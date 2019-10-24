using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    private float destroyed = 4f;
    // Start is called before the first frame update
    void Start()
    {

        Destroy(this.gameObject, destroyed);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
