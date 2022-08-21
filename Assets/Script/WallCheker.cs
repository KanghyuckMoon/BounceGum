using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheker : MonoBehaviour
{
    private Bound bound;
    [SerializeField]
    private int angle;

    // Update is called once per frame
    private void Start()
    {
        bound = transform.parent.GetComponent<Bound>();
    }

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 9)
    //    {
    //        bound.GumWall(angle);
    //    }
    //}
}
