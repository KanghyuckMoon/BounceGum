using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlatform : MonoBehaviour
{
    [SerializeField]
    private bool Righton;
    [SerializeField]
    private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0,0,transform.eulerAngles.z + (speed * Time.deltaTime));
    }
}
