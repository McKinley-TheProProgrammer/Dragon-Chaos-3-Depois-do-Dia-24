using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTrigger : MonoBehaviour
{
    public GameObject caixaDeTexto;
    public GameObject instrucao;
    public GameObject textoNome;
    public GameObject textoDialogo;
    public GameObject butao;
    public Dialogue dialogo;
    public GameObject player;
    public bool podeFalar;
    public bool saiuDoCampo = false;
    public bool cineActive;
    public bool notSpecialAnymore;
    public int npcIdentifier;

    void Conversa()
    {
        Debug.Log("Ativou");

        FindObjectOfType<DialogueManager>().ComecarDialogo(dialogo);
        FindObjectOfType<DialogueManager>().npcAnima.SetBool("Talking",true);
        textoDialogo.SetActive(true);
        textoNome.SetActive(true);
        butao.SetActive(true);
        caixaDeTexto.SetActive(true);
        player.GetComponent<PlayerMovement>().inDialog = true;
        if (cineActive == false)
        {
            Debug.Log("LOOG");
            notSpecialAnymore = false;
            cineActive = true;
            //FindObjectOfType<DialogueManager>().cutscene.CineEnabled();
            //GameManager.Instance.CineEnabled();

        }
    }
    void OnTriggerExit2D(Collider2D trigo)
    {
        instrucao.GetComponent<Text>().text = "APERTE F";
        instrucao.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D trigo)
    {
        
        Debug.Log(trigo.transform.name);
        if (gameObject.tag == "NPCAutomatico" && trigo.gameObject.CompareTag("Player"))
        {
            Conversa();
            GameManager.Instance.CineEnabled(GameManager.Instance.camera[1]);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            instrucao.GetComponent<Text>().text = "APERTE 'Z' PARA ATACAR";
        }
        if (gameObject.tag == "ColissionInstruction" && trigo.gameObject.CompareTag("Player"))
        {
            Conversa();
            GameManager.Instance.CineEnabled(GameManager.Instance.camera[2]);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            instrucao.GetComponent<Text>().text = "ENQUANTO ESTIVER SE MOVENDO, APERTE 'ESPAÇO' PARA USAR O SEU DASH";
        }
        instrucao.SetActive(true);
    }
    void OnTriggerStay2D(Collider2D trigo)
    {
        if (trigo.gameObject.CompareTag("Player") && saiuDoCampo == false && player.GetComponent<PlayerMovement>().isOnLand == true)
        {
            Debug.Log("Entrou");
            
            if (Input.GetKeyDown(KeyCode.F))
           {
                Conversa();
           }
        }
        
    }

}
