using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{

    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float jumpPower = 10f;

    public int coinsCollected;
    private int maxHealth = 100;
    public int health = 100;
    public int ammo;

    public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();
    public Sprite keySprite;
    public Image inventoryItemImage;
    public Sprite keyGemSprite;
    public Sprite inventoryItemBlank;

    public Text coinsText;
    public Image healthBar;
    [SerializeField] private Vector2 healthBarOrigSize;

    void Start()
    {
        healthBarOrigSize = healthBar.rectTransform.sizeDelta;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, 0);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpPower;
        }
    }

    public void UpdateUI()
    {
        //changes coinstext int to a string so it can be displayed in the UI
        coinsText.text = coinsCollected.ToString();
        //set the health bar to a percentage of its original width
        healthBar.rectTransform.sizeDelta = new Vector2(healthBarOrigSize.x * ((float)health / (float)maxHealth), healthBar.rectTransform.sizeDelta.y);

    }

    public void AddInventoryItem(string inventoryName, Sprite image)
    {
        inventory.Add(inventoryName, image);
        //changes the blank sprite to the key sprite
        inventoryItemImage.sprite = inventory[inventoryName];
    }

    public void RemoveInventoryItem(string inventoryName)
    {
        inventory.Remove(inventoryName);
        //changes the key sprite to the blank sprite
        inventoryItemImage.sprite = inventoryItemBlank;
    }
}
