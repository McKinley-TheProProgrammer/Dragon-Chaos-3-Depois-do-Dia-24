using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duracao,float magnitude)
    {
        Vector3 posOriginal = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duracao)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, posOriginal.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
    }
   
}
