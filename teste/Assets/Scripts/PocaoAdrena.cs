using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocaoAdrena : MonoBehaviour
{
    
    public Image barra;
    void UsarItem()
    {
        barra.GetComponent<AttackMechanic>().barraDeAdrenalina.fillAmount += 0.2f;
    }
}
