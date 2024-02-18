using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public float timerOne;
    public float speed = 1f;
    public float timeSpacing = 2.5f;
    public float distanceThreshold = 0.1f;
    public bool aToB;
    public bool bToC;
    public bool cToA;
    public float step;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        step = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(rb.transform.position, pointA.transform.position) <= distanceThreshold)
        {
            aToB = true;
            cToA = false;
        }
        if (Vector2.Distance(rb.transform.position, pointB.transform.position) <= distanceThreshold)
        {
            bToC = true;
            aToB = false;
        }
        if (Vector2.Distance(rb.transform.position, pointC.transform.position) <= distanceThreshold)
        {
            cToA = true;
            bToC = false;
        }
    }
    private void FixedUpdate()
    {
        if (aToB == true)
        {
            rb.transform.position = Vector2.MoveTowards(rb.position, pointB.position, step);
        }
        if (bToC == true)
        {
            rb.transform.position = Vector2.MoveTowards(rb.position, pointC.position, step);
        }
        if (cToA == true)
        {
            rb.transform.position = Vector2.MoveTowards(rb.position, pointA.position, step);
        }
    }
}
