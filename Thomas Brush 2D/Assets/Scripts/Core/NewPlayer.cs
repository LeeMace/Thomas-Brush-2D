using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPlayer : PhysicsObject
{
    [Header("Attributes")]

    public int attackPower = 25;
    [SerializeField] private float attackDuration;
    [SerializeField] private float jumpPower = 10f;
    [SerializeField] private float maxSpeed = 1;

    [Header("Inventory")]

    public int coinsCollected;
    private int maxHealth = 100;
    public int health = 100;
    public int ammo;

    [Header("References")]

    [SerializeField] private GameObject attackBox;
    public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();
    public Sprite inventoryItemBlank;
    public Sprite keyGemSprite;
    public Sprite keySprite;
    private Vector2 healthBarOrigSize;


    //Singleton instansiation
    private static NewPlayer instance;
    public static NewPlayer Instance
    {
        get 
        {
            if (instance == null) instance = GameObject.FindObjectOfType<NewPlayer>();
            return instance;
        }
    }

    //keeping original player from previous level and destroying new instance
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);

        }

    }

    void Start()
    {
        //This keeps the player to port over to the new level
        DontDestroyOnLoad(gameObject);

        healthBarOrigSize = GameManager.Instance.healthBar.rectTransform.sizeDelta;
        UpdateUI();

        SetSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, 0);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpPower;
        }

        //flip the player if moving left or right
        if(targetVelocity.x < -.01)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if(targetVelocity.x > .01)
        {
            transform.localScale = new Vector2(1, 1);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(ActivateAttack());
        }

        if (health <= 0)
        {
            Die();
        }

    }
        public IEnumerator ActivateAttack()
        {
        attackBox.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackBox.SetActive(false);
        }

    public void UpdateUI()
    {
        //changes coinstext int to a string so it can be displayed in the UI
        GameManager.Instance.coinsText.text = coinsCollected.ToString();
        //set the health bar to a percentage of its original width
        GameManager.Instance.healthBar.rectTransform.sizeDelta = new Vector2(healthBarOrigSize.x * ((float)health / (float)maxHealth), GameManager.Instance.healthBar.rectTransform.sizeDelta.y);

    }

    public void AddInventoryItem(string inventoryName, Sprite image)
    {
        inventory.Add(inventoryName, image);
        //changes the blank sprite to the key sprite
        GameManager.Instance.inventoryItemImage.sprite = inventory[inventoryName];
    }

    public void RemoveInventoryItem(string inventoryName)
    {
        inventory.Remove(inventoryName);
        //changes the key sprite to the blank sprite
        GameManager.Instance.inventoryItemImage.sprite = inventoryItemBlank;
    }

    public void SetSpawnPosition()
    {
        transform.position = GameObject.Find("SpawnLocation").transform.position;
    }
    public void Die()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}