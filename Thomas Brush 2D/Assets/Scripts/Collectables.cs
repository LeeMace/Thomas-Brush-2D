using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    
    enum ItemType { Coin, Health, Ammo, InventoryItem}
    [SerializeField] private ItemType itemType;

    [SerializeField] private string inventoryStringName;
    [SerializeField] private Sprite inventorySprite;
    void Start()
    {

    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
        if (itemType == ItemType.Coin)
        {
            //if a coin is collected the total goes up
            NewPlayer.Instance.coinsCollected += 1;         
        }
        else if (itemType == ItemType.Health)
        {
                //cannot go over 100 health
                if (NewPlayer.Instance.health < 100)
                {
                    NewPlayer.Instance.health += 1;
                }
        }
        else if (itemType == ItemType.Ammo)
        {
            
        }
        else if(itemType == ItemType.InventoryItem)
            {
                NewPlayer.Instance.AddInventoryItem(inventoryStringName , inventorySprite);
            }
        else 
        {
            
        }
            //the UI shows the correct number of coins collected. 
            NewPlayer.Instance.UpdateUI();
            Destroy(gameObject);
        }        
    }
}
