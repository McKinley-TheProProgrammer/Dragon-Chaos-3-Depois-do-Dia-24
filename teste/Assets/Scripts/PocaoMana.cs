using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocaoMana : MonoBehaviour
{
    
    public Image barra;
    void UsarItem()
    {
        barra.GetComponent<DashMechanic>().barraDeMana.fillAmount += 0.15f;
    }
}
