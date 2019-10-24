using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Deactivate", 3.6f);

    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
