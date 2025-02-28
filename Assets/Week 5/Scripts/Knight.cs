using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knight : MonoBehaviour
{
    public Rigidbody2D rb;
    Animator animator;
    Vector2 destination;
    public Vector2 movement;
    public float speed = 3;
    bool clickingOnSelf = false;
    public float health;
    public float maxHealth = 5;
    bool isDead = false;
    public Vector2 lastPosition;

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = PlayerPrefs.GetFloat("PlayerHealth"); // Something interesting is happening, when the player dies, restarting the game will give them 1 health instead of 0.
        lastPosition = rb.position;
    }

    public void FixedUpdate() // Physics things happen in here
    {
        if (isDead) return; // If this is true, don't do anything below
        movement = destination - (Vector2)transform.position; // Direction you want to move in
        if(movement.magnitude < 0.1) // If we're just about there
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime); // Normalize: it's the correct angle, but only a direction of 1 unit
    }
    public void Update()
    {
        if (isDead) return;
        if (Input.GetMouseButtonDown(0) && !clickingOnSelf && !EventSystem.current.IsPointerOverGameObject()) // Requires a UnityEngine.EventSystems at the top
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude); // Make sure things are spelt right cause you won't get a warning.

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
        }

        PlayerPrefs.SetFloat("PlayerHealth", health);

        if (health < maxHealth)
        {
            SendMessage("SetHealth", health);
        }
    }

    public void SetHealth(float health) // I'm not sure if it's okay to leave this blank
    {

    }

    private void OnMouseDown()
    {
        if (isDead) return;
        clickingOnSelf = true;
        SendMessage("TakeDamage", 1);
    }

    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }

    public void TakeDamage(float damage) // neat this allows you to change values easily
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth); // Keep this within these values
        if(health <= 0)
        {
            // die
            isDead = true;
            animator.SetTrigger("Death");
        }
        else
        {
            isDead = false; // If we get healed, we can arise from the dead
            animator.SetTrigger("TakeDamage");
        }
    }
}
