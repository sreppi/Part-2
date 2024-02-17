using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 scaleChange = new Vector3(-100f, -100f, 0f);
    public float lerpTimer;
    public float interpolation;
    public AnimationCurve animationCurve;
    public PlayerShooting playerShooting;
    public GameObject retical;
    public Vector2 startPosition;
    public Vector2 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        retical = GameObject.FindWithTag("Player");
        if (retical != null)
        {
            playerShooting = retical.GetComponent<PlayerShooting>(); // This is finding the Knight script using FindWithTag, it's to attach the component to every new instantiated axe
        }
        startPosition = playerShooting.worldPosition;
        endPosition = playerShooting.worldPosition + new Vector3(0, 1, 0);
    }
    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        interpolation = animationCurve.Evaluate(lerpTimer);
        transform.position = Vector3.Lerp(startPosition, endPosition, interpolation);
        lerpTimer += Time.deltaTime;

        transform.localScale += scaleChange;
        if (transform.localScale.x <= 0 && transform.localScale.y <= 0)
        {
            Destroy(gameObject);
        }


    }
}
