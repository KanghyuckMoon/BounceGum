using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownCheker : MonoBehaviour
{
    private Bound bound;
    private float jumppower = 55f;
    // Update is called once per frame
    private void Start()
    {
        bound = transform.parent.GetComponent<Bound>();
    }

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 9)
    //    {
    //        bound.Jump(jumppower);
    //    }
    //}
}
