using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    
    enum ItemType { Coin, Health, Ammo}
    [SerializeField] private ItemType itemType;

    NewPlayer newPlayer;

    void Start()
    {
        newPlayer = GameObject.Find("Player").GetComponent<NewPlayer>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
        if (itemType == ItemType.Coin)
        {
            //if a coin is collected the total goes up
            newPlayer.coinsCollected += 1;         
        }
        else if (itemType == ItemType.Health)
        {
                //cannot go over 100 health
                if (newPlayer.health < 100)
                {
                    newPlayer.health += 1;
                }
        }
        else if (itemType == ItemType.Ammo)
        {
            
        }
        else 
        {
            
        }
            //the UI shows the correct number of coins collected. 
            newPlayer.UpdateUI();
            Destroy(gameObject);
        }        
    }
}
