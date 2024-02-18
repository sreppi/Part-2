using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using System.Reflection;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;
    public Transform pointE;
    public Transform pointF;
    public Transform pointG;
    public Transform pointH;
    public float timerOne;
    public float speed;
    public float timeSpacing = 2.5f;
    public float distanceThreshold = 0.1f;
    public bool aToB;
    public bool bToC;
    public bool cToD;
    public bool dToE;
    public bool eToF;
    public bool fToG;
    public bool gToH;
    public float step;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        pointA = GameObject.FindWithTag("Point A").transform;
        if (pointA != null)
        {
            pointA = pointA.GetComponent<Transform>(); // Find the game object with the script
        }
        pointB = GameObject.FindWithTag("Point B").transform;
        if (pointB != null)
        {
            pointB = pointB.GetComponent<Transform>(); // Find the game object with the script
        }
        pointC = GameObject.FindWithTag("Point C").transform;
        if (pointC != null)
        {
            pointC = pointC.GetComponent<Transform>(); // Find the game object with the script
        }
        pointD = GameObject.FindWithTag("Point D").transform;
        if (pointD != null)
        {
            pointD = pointD.GetComponent<Transform>(); // Find the game object with the script
        }
        pointE = GameObject.FindWithTag("Point E").transform;
        if (pointE != null)
        {
            pointE = pointE.GetComponent<Transform>(); // Find the game object with the script
        }
        pointF = GameObject.FindWithTag("Point F").transform;
        if (pointF != null)
        {
            pointF = pointF.GetComponent<Transform>(); // Find the game object with the script
        }
        pointG = GameObject.FindWithTag("Point G").transform;
        if (pointG != null)
        {
            pointG = pointG.GetComponent<Transform>(); // Find the game object with the script
        }
        pointH = GameObject.FindWithTag("Point H").transform;
        if (pointH != null)
        {
            pointH = pointH.GetComponent<Transform>(); // Find the game object with the script
        }

        speed = Random.Range(1.0f, 3.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(rb.transform.position, pointA.transform.position) <= distanceThreshold)
        {
            aToB = true;
        }
        if (Vector2.Distance(rb.transform.position, pointB.transform.position) <= distanceThreshold)
        {
            bToC = true;
            aToB = false;
        }
        if (Vector2.Distance(rb.transform.position, pointC.transform.position) <= distanceThreshold)
        {
            cToD = true;
            bToC = false;
        }
        if (Vector2.Distance(rb.transform.position, pointD.transform.position) <= distanceThreshold)
        {
            dToE = true;
            cToD = false;
        }
        if (Vector2.Distance(rb.transform.position, pointE.transform.position) <= distanceThreshold)
        {
            eToF = true;
            dToE = false;
        }
        if (Vector2.Distance(rb.transform.position, pointF.transform.position) <= distanceThreshold)
        {
            fToG = true;
            eToF = false;
        }
        if (Vector2.Distance(rb.transform.position, pointG.transform.position) <= distanceThreshold)
        {
            gToH = true;
            fToG = false;
        }
    }
    private void FixedUpdate()
    {
        step = speed * Time.deltaTime;
        if (aToB == true)
        {
            rb.transform.position = Vector2.MoveTowards(rb.position, pointB.position, step);
        }
        if (bToC == true)
        {
            rb.transform.position = Vector2.MoveTowards(rb.position, pointC.position, step);
        }
        if (cToD == true)
        {
            rb.transform.position = Vector2.MoveTowards(rb.position, pointD.position, step);
        }
        if (dToE == true)
        {
            rb.transform.position = Vector2.MoveTowards(rb.position, pointE.position, step);
        }
        if (eToF == true)
        {
            rb.transform.position = Vector2.MoveTowards(rb.position, pointF.position, step);
        }
        if (fToG == true)
        {
            rb.transform.position = Vector2.MoveTowards(rb.position, pointG.position, step);
        }
        if (gToH == true)
        {
            rb.transform.position = Vector2.MoveTowards(rb.position, pointH.position, step);
        }
    }
}
