using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private EdgeCollider2D lineCollider;
    private List<Vector2> points; 

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();   
        lineCollider = GetComponent<EdgeCollider2D>();
        lineCollider.transform.position -= transform.position;
        points = new List<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(Vector2 pos)
    {
        if (!CanAppend(pos))
        {
            return;
        }

        points.Add(pos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);

        lineCollider.SetPoints(points);
    }

    public bool CanAppend(Vector2 pos)
    {
        if (lineRenderer.positionCount == 0) { return true; }
        return Vector2.Distance(lineRenderer.GetPosition(lineRenderer.positionCount - 1), pos) > DrawLine.RESOLUTION;
    }
}
