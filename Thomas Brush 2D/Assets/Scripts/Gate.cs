using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private string requiredInventoryItemString;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("the player is touching me");

            if (GameObject.Find("Player").GetComponent<NewPlayer>().inventory.ContainsKey(requiredInventoryItemString))
            {
                GameObject.Find("Player").GetComponent<NewPlayer>().RemoveInventoryItem(requiredInventoryItemString);
                Destroy(gameObject);
            }
        }
    }


}
