using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DragLine : MonoBehaviour
{
    private LineRenderer lr;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        //endPoint.x = Mathf.Clamp(endPoint.x, -2f, 2f);
        //endPoint.y = Mathf.Clamp(endPoint.y, -2f, 2f);
        //endPoint.z = Mathf.Clamp(endPoint.z, -2f, 2f);

        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        lr.SetPositions(points);
    }

    public void EndLine()
    {
        lr.positionCount = 0;
    }
}
