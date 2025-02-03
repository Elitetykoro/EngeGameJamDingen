using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private CircleCollider2D colliderToDraw;
    // Start is called before the first frame update
    void Start()
    {
        DrawOutline(100, colliderToDraw.radius);
    }

    void DrawOutline(int steps, float radius)
    {
        lineRenderer.positionCount = steps;

        for(int i = 0; i<steps; i++)
        {
            float progress = (float)i / steps;
            float radian = progress * 2 * Mathf.PI;

            float scaledX = Mathf.Cos(radian);
            float scaledY = Mathf.Sin(radian);

            float x = scaledX * radius;
            float y = scaledY * radius;

            Vector3 position = new Vector3(x, y, 0);

            lineRenderer.SetPosition(steps, position);
        }
    }
}
