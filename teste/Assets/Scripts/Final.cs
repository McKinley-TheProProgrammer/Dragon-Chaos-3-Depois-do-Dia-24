using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Final : MonoBehaviour
{
    public Animator fadeIn;
    public Animator portao;
    
    public AudioClip roar;
    public AudioSource mainTheme;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.CineEnabled(GameManager.Instance.camera[3]);
            mainTheme.GetComponent<AudioSource>().Stop();
            portao.SetTrigger("Down");
            StartCoroutine(GoToEnd());
        }
        
    }
    IEnumerator GoToEnd()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.SfxPlayer(roar);
        yield return new WaitForSeconds(1.5f);
        fadeIn.SetTrigger("FadeIn");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(2);
            
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
