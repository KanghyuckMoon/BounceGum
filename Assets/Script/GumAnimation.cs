using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumAnimation : MonoBehaviour
{
    [SerializeField]
    private Transform bound;
    [SerializeField]
    private Transform gum;
    private LineRenderer lineRenderer;
    Vector3 a = Vector3.zero;
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void OnEnable()
    {

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, bound.position);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, bound.position, ref a,0.1f);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, bound.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {

            gameObject.SetActive(false);
        }
    }
}
