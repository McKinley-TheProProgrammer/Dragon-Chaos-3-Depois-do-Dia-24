using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocaoStamina : MonoBehaviour
{
    
    public Image barra;
    void UsarItem()
    {
        barra.GetComponent<DashMechanic>().barraDeMana.fillAmount += 0.45f;
    }
}
