using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points; //List of points when we click on our point, we reintialize
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition; 
    LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();//Get the component called LineRenderer
        lineRenderer.positionCount = 1; //How many positions
        lineRenderer.SetPosition(0, transform.position); //As soon as the game starts, the point is where the plane is right now, as soon as we draw, the points will connect to the plane
    }

    void OnMouseDown()
    {
        points = new List<Vector2>(); //Erase old points
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(newPosition);
        lineRenderer.positionCount = 1; //How many positions
        lineRenderer.SetPosition(0, transform.position); //As soon as the game starts, the point is where the plane is right now, as soon as we draw, the points will connect to the plane
    }

    void OnMouseDrag()
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
