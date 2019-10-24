using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum ItemTypes { ADRENALINA, MANA, STAMINA }
public class Item : MonoBehaviour
{
    public int maxUse;
    public float cooldown;
    public Sprite itemSprite;
    public Image barra;
    public float quantia;
    public int slotItem;
    public ItemTypes meuTipo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
