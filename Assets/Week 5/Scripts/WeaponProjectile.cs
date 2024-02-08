using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject axeSprite;
    public Rigidbody2D rb;
    public float speed = 2.5f;
    public Knight knight; // Used to access the Knight Script
    public GameObject player;
    public float despawnTimer;
    public float timeToDespawn = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            knight = player.GetComponent<Knight>(); // This is finding the Knight script using FindWithTag, it's to attach the component to every new instantiated axe
        }
        rb.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-8, 8), 0); // Note to self: Look for a way so it doesn't spawn inside the arena, but rather around it
    }

    // Update is called once per frame
    void Update()
    {
        axeSprite.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        rb.transform.position = Vector2.MoveTowards(transform.position, knight.rb.position, speed * Time.deltaTime);
        despawnTimer += Time.deltaTime;
        if (despawnTimer > timeToDespawn)
        {
            Destroy(gameObject);
            despawnTimer = 0;
        }
    }

    private void FixedUpdate()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
