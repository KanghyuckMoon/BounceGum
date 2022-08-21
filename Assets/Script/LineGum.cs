using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGum : MonoBehaviour
{
    [SerializeField]
    private Transform[] transforms;
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, transforms[0].position);
        lineRenderer.SetPosition(1, transforms[1].position);
    }
}
