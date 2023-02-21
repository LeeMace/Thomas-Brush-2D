using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{

    [SerializeField] private float  maxSpeed = 1;
    [SerializeField] private float jumpPower = 10f;

    public int coinsCollected;

    public TMP_Text coinsText;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxis("Horizontal")* maxSpeed, 0);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpPower;
        }
    }

    public void UpdateUI()
    {
        coinsText.text = coinsCollected.ToString;
    }
}
