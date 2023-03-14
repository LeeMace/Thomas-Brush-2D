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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == NewPlayer.Instance.gameObject)
        {
            Debug.Log("I am a door. The player is touching me with a key. I will open but take his key. ");

            if (NewPlayer.Instance.inventory.ContainsKey(requiredInventoryItemString))
            {
                NewPlayer.Instance.RemoveInventoryItem(requiredInventoryItemString);
                Destroy(gameObject);
            }
        }
    }


}
