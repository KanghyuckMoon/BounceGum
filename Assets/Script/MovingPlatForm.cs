using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatForm : MonoBehaviour
{
    [SerializeField]
    private bool Righton;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float amplitude;
    [SerializeField]
    private bool side;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(side)
        {
            transform.position = new Vector2(transform.position.x + amplitude * Mathf.Sin(Time.time * Time.deltaTime * speed), transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + amplitude * Mathf.Sin(Time.time * Time.deltaTime * speed));
        }
    }
}
