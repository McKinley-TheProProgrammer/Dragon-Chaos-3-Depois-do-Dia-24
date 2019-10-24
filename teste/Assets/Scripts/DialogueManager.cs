using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Animator npcAnima;
    public GameManager cutscene;
    public GameObject textname;
    public GameObject textdialog;
    public GameObject butao;
    public GameObject boxText;
    public Text textoNome;
    public Text textoDialogo;
    public GameObject player;
    public NPCTrigger[] quemFala, special;
    
    public int npcPoint;
    private Queue<string> sentencas;
	// Use this for initialization
	void Start () {
        sentencas = new Queue<string>();
       
	}
	
	public void ComecarDialogo(Dialogue dialogo)
    {
        

        textoNome.text = dialogo.nome;

        sentencas.Clear();

        foreach(string frase in dialogo.sentencas)
        {
            sentencas.Enqueue(frase);
        }

        DisplayNextFrase();
    }
    public void DisplayNextFrase()
    {
        /* if(sentencas.Count == 3)
        {
            GameManager.Instance.CineEnabled();
        }
        if(sentencas.Count == 0)
        {
             if (npcPoint != 0)
                 EndDialogo(npcPoint);
             else if(npcPoint == 0)
                    EndDialogo(npcPoint++);
                 
            //EndDialogo(npcPoint++);
            return; 
        }*/
        //player.GetComponent<PlayerMovement>().activatePhys += 1;
        if (special[0] && !special[0].GetComponent<NPCTrigger>().notSpecialAnymore)
        {
            switch (sentencas.Count)
            {

                case 4:
                    GameManager.Instance.CineEnabled(GameManager.Instance.camera[0]);
                    break;

            }
        }

        if (sentencas.Count == 0)
        {
            EndDialogo(npcPoint);
           //EndDialogo(npcPoint++);
            return;
        }
        string sentenda = sentencas.Dequeue();
        StopAllCoroutines();
        StartCoroutine(SentencadeMorte(sentenda));
    }

    IEnumerator SentencadeMorte(string sentenca)
    {
        textoDialogo.text = "";
        foreach (char letra in sentenca.ToCharArray())
        {
            textoDialogo.text += letra;
            yield return null;
        }
    }
    public void EndDialogo(int npcPointer)
    {
        special[0].GetComponent<NPCTrigger>().notSpecialAnymore = true;
        special[0].GetComponent<Animator>().SetBool("Talking", false);
        GameManager.Instance.CineDisabled(GameManager.Instance.camera[0]);
        GameManager.Instance.CineDisabled(GameManager.Instance.camera[1]);
        GameManager.Instance.CineDisabled(GameManager.Instance.camera[2]);
        GameManager.Instance.CineDisabled(GameManager.Instance.camera[3]);
        player.GetComponent<PlayerMovement>().inDialog = false;
        textname.SetActive(false);
        textdialog.SetActive(false);
        butao.SetActive(false);
        boxText.SetActive(false);
        Debug.Log("Fim da Conversa");
    }
}
