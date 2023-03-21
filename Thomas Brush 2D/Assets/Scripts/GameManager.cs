using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text coinsText;
    public Image healthBar;

    public Image inventoryItemImage;


    //Singleton instansiation
    private static GameManager _instance;
    public static GameManager Instance => _instance;
  

    private void Awake()
    {
        {
            if (_instance != null && _instance != this)
                Destroy(gameObject);
            else
                _instance = this;
        }
    }


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
}
