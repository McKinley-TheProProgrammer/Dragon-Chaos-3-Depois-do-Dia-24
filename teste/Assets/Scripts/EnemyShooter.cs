using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject projetil;
    public Transform quemAtira;
    public Transform posPlayer;
    Vector3 rotAtual;
    public float ritmoDoTiro;
    public bool naMira;

    private void Start()
    {
        rotAtual = transform.rotation.eulerAngles;
        rotAtual.z = 0;
    }
    private void OnTriggerEnter2D(Collider2D mira)
    {
        if(mira.CompareTag("Player"))
            naMira = true;
    }
    private void OnTriggerExit2D(Collider2D mira)
    {
        if (mira.CompareTag("Player"))
            naMira = false;
    }
    // Update is called once per frame
    void Update()
    {
        quemAtira.LookAt(posPlayer);
        if (naMira)
        {
            //GameObject atual = ? 
            ritmoDoTiro -= Time.deltaTime;
            if (ritmoDoTiro <= 0)
            {
                GameObject atual = Instantiate(projetil, quemAtira.position, Quaternion.identity);
                ritmoDoTiro = 2;
                Destroy(atual, 3);
            }
            
        }
        else
            return;
    }
}
