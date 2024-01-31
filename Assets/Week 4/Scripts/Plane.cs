using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points; //List of points when we click on our point, we reintialize
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition; 
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rb;
    public float speed = 1;
    public AnimationCurve landing;
    float landingTimer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();//Get the component called LineRenderer
        lineRenderer.positionCount = 1; //How many positions
        lineRenderer.SetPosition(0, transform.position); //As soon as the game starts, the point is where the plane is right now, as soon as we draw, the points will connect to the plane
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() //Physics normally happen here
    {
        //Do the Rotation and the Moving in here
        //Get the value of our current position
        currentPosition = transform.position; //We don't care about the Z value, and we can't use Vector2 into Vector3
        //Do we have a flight path right now?
        if(points.Count > 0) //We will only do the rotation code if we have a flight path to follow
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg; //We got this vector pretned it's a triangle
            rb.rotation = -angle; //Negative rotates clockwise, also there's other ways to do this
        }
        //Let's move it forward
        rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime); //remember transform.forward is into the z position, also force the vector 3 to 2
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Space)) //we want this to keep happening while it's down, so not GetKeyDown
        {
            landingTimer += 0.5f * Time.deltaTime; //every single frame we're increasing this number
            float interpolation = landing.Evaluate(landingTimer); //lerp?
            if(transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }

        //The line rendere where it use to be, we want to update the point
        lineRenderer.SetPosition(0, transform.position); //back of the end of the line, move it forward; removes so that there isn't a line behind itself
        if (points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < newPointThreshold) //are these two points bigger than this path? Absolute point is bad in this sense
            {
                points.RemoveAt(0);

                //Go through all the points through the list, we want to get rid of the first slot, and move everything down
                for (int i = 0; i < lineRenderer.positionCount -2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i+1));
                }
                //if (lineRenderer.positionCount != 0) //didn't seem to fix it
                //get rid of the last point
                lineRenderer.positionCount--;
            }
        }
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>(); //Erase old points
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(newPosition);
        lineRenderer.positionCount = 1; //How many positions
        lineRenderer.SetPosition(0, transform.position); //As soon as the game starts, the point is where the plane is right now, as soon as we draw, the points will connect to the plane
    }

    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(lastPosition, newPosition) > newPointThreshold) //Compares these two vector2 and check are they further than this threshold value, did we move far enough? If yes
        {
            points.Add(newPosition);
            lineRenderer.positionCount++; //Make the array one element larger
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition); //Stuff it at the end of the list, that list of points, add it to the lineRenderer
            lastPosition = newPosition; //Is the last position far away from this position?
        }
    }
}
