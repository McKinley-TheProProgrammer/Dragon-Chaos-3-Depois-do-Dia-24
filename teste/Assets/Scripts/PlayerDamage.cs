using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    //Treme a tela
    public bool imortal;
    public AudioClip death;
    public GameManager playerDies;
    public CameraShake cameraShake;
    Rigidbody2D body;
    float temp = 1;
    bool knockback = false;
    public UnityEvent OnHit;
    public UnityEvent OutHit;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ColisionDeath"))
        {
            gameObject.SetActive(false);
        }
    }


    private void OnDisable()
    {
        if (playerDies)
        {
            playerDies.Coroutine();
            playerDies.SfxPlayer(death);
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (knockback)
        {
            temp -= Time.deltaTime;
            if (temp <= 0)
            {
                OnHit.Invoke();
                temp = 1;
                knockback = false;
            }
        }
        if (!knockback)
        {
            OutHit.Invoke();
        }
    }
}
