using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InventoryManager : MonoBehaviour
{
    public List<Item> itens = new List<Item>();
    [SerializeField]
    int proxItem;
    Image barra;
    public Image itemAtualRef;
    int slotAtual = 0;
    // Start is called before the first frame update
    void Start()
    {
        proxItem = 0;

        itemAtualRef.sprite = null;
        itemAtualRef.color = new Color(itemAtualRef.color.r, itemAtualRef.color.g, itemAtualRef.color.b, 0);
    }

    public void AddItem(Item itemAdicionado)
    {
        if (proxItem < 3)
        {
            itens.Add(itemAdicionado);

            itemAtualRef.sprite = itens[slotAtual].itemSprite;
            itemAtualRef.color = new Color(itemAtualRef.color.r, itemAtualRef.color.g, itemAtualRef.color.b, 1);
            itemAtualRef.preserveAspect = true;
            proxItem++;
           //slotAtual = proxItem;
        }
        else
            proxItem = 0;
    }
    public void TrocarSlot()
    {

        slotAtual++;

        if (slotAtual >= itens.Count)
        {
            slotAtual = 0;
        }
        print("Slot atual: " + slotAtual);
        if (itens.Count > 0)
        {
            itemAtualRef.sprite = itens[slotAtual].itemSprite; //OUT OF RANGE AQUI
            itemAtualRef.color = new Color(255, 255, 255, 255);
        }
        else
            itemAtualRef.color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TrocarSlot();  //OUT OF RANGE AQUI
        }
        if (itens.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.C) && itens[slotAtual].GetComponent<Pocao>()) //OUT OF RANGE AQUI
            {
                print("UBOA");
                itens[slotAtual].GetComponent<Pocao>().UsarPocao();

                itens.Remove(itens[slotAtual]);
                TrocarSlot(); //OUT OF RANGE AQUI
            }
        }
    }

    //public virtual void UsarItem()
    //{
    //    itemAtualRef.GetComponent<Image>().gameObject.SetActive(false);
    //    itens[trocaSlot].gameObject.SetActive(true);
    //    itens[trocaSlot].SendMessage("UsarItem", SendMessageOptions.DontRequireReceiver);
    //    itens[trocaSlot].gameObject.SetActive(false);
    //}

}
