using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 scaleChange = new Vector3(-1f, -1f, 0f);
    public float lerpTimer;
    public float interpolation;
    public AnimationCurve animationCurve;
    public PlayerShooting playerShooting;
    public EnemyScript enemyScript;
    public ScoreCounter scoreCounter;
    public GameObject scoreText;
    public GameObject retical;
    public Vector2 startPosition;
    public Vector2 endPosition;
    public float arrowSpeed;

    // Start is called before the first frame update
    void Start()
    {
        arrowSpeed = 0.5f;
        rb = GetComponent<Rigidbody2D>();
        retical = GameObject.FindWithTag("Player");
        if (retical != null)
        {
            playerShooting = retical.GetComponent<PlayerShooting>(); // Find the game object with the script
        }
        scoreText = GameObject.FindWithTag("ScoreCounter");
        if (scoreText != null)
        {
            scoreCounter = scoreText.GetComponent<ScoreCounter>(); // Find the game object with the script
        }
        startPosition = playerShooting.worldPosition;
        endPosition = playerShooting.worldPosition + new Vector3(0, 3, 0); // Height of the arrow
    }
    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move the arrow up and back down
        interpolation = animationCurve.Evaluate(lerpTimer);
        transform.position = Vector3.Lerp(startPosition, endPosition, interpolation);
        lerpTimer += arrowSpeed * Time.deltaTime;

        // Reduce the scale of the arrow
        transform.localScale += scaleChange * (arrowSpeed * 150f * Time.deltaTime);
        if (transform.localScale.x <= 0 && transform.localScale.y <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerStay2D(Collider2D collision) // OnTriggerStay saved my life!
    {
        if (collision.gameObject.CompareTag("Enemy") && transform.localScale.x <= 0.1 && transform.localScale.y <= 0.1)
        {  
            scoreCounter.SendMessage("ReceiveScore", 100, SendMessageOptions.DontRequireReceiver); // There's some unintended bugs here but time is running out for me to finish this
            collision.gameObject.SendMessage("DeathAnimation", SendMessageOptions.DontRequireReceiver);
            Destroy(collision.gameObject, 2);
        }
    }
}
