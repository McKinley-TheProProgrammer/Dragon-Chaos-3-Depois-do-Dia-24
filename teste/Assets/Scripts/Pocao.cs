using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pocao : Item
{
    public InventoryManager inventario;
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PegarPocao()
    {
        inventario.itens.Add(this);
        //switch (tipoDePocao)
        //{
        //    case PotionTypes.VIDA:
        //        inventario.itens.Add(this);
        //        break;
        //    case PotionTypes.MANA:
        //        inventario.itens.Add(this);
        //        break;
        //    case PotionTypes.STAMINA:
        //        inventario.itens.Add(this);
        //        break;
        //}
    }

    public void UsarPocao()
    {
        switch (meuTipo)
        {
            case ItemTypes.ADRENALINA:
                PlayerMovement.Instance.attackScript.barraDeAdrenalina.fillAmount += .25f;
                break;
            case ItemTypes.MANA:
                PlayerMovement.Instance.attackScript.barraDeAdrenalina.fillAmount += .25f;
                break;
            case ItemTypes.STAMINA:
                PlayerMovement.Instance.GetComponent<DashMechanic>().barraDeMana.fillAmount += .5f;
                break;
            default:
                break;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inventario.AddItem(gameObject.GetComponent<Pocao>());
            //PegarPocao();
            gameObject.SetActive(false);
        }
    }
}
