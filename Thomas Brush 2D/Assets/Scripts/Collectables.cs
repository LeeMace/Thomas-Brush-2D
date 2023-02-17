using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    
    enum ItemType { Coin, Health, Ammo}
    [SerializeField] private ItemType itemType;


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
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("Player").GetComponent<NewPlayer>().coinsCollected += 1;
            Destroy(gameObject);
        }        
    }
}
