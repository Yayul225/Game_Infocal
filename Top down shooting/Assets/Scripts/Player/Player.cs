using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public Rigidbody2D rb;

    //Movement support
    public float moveSpeed = 5f;
    Vector2 movement;

    //Point mouse support

    Vector2 mousePos;
    bool isLookingRight = true;
    public Transform playerTransform;
    public float angle;

    public Camera cam;


    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        
        //a trigger lowers health
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    private void FixedUpdate()
    {
        //moves the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //gets the vector from the player to the mouse
        Vector2 lookDirec = mousePos - rb.position;
        
        //calculates the angle for the rotation
        angle = Mathf.Atan2(lookDirec.y, lookDirec.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
        //if(angle > 0 && isLookingRight)
        //{
        //    Flip();
        //}

        //if(angle < 0 && !isLookingRight)
        //{
        //    Flip();
        //}


    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void Flip()
    {
        isLookingRight = !isLookingRight;
        transform.Rotate(180f, 0f, 0f);
    }
}
