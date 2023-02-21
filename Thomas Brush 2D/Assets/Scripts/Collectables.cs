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
        if (itemType == ItemType.Coin)
        {
            Debug.Log("I'm a coin");
        }
        else if (itemType == ItemType.Health)
        {
            Debug.Log("I'm health");
        }
        else if (itemType == ItemType.Ammo)
        {
            Debug.Log("I'm ammo");
        }
        else 
        {
            Debug.Log("I'm an inventory item");
        }

        newPlayer = GameObject.Find("Player").GetComponent<NewPlayer>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //if a coin is collected the total goes up
            newPlayer.coinsCollected += 1;
            //the UI shows the correct number of coins collected. 
            newPlayer.UpdateUI();
            Destroy(gameObject);
        }        
    }
}
