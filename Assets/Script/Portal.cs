using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject ply;
    private GameObject gum;
    [SerializeField]
    private Transform anpotal;
    private bool tele;

    // Start is called before the first frame update
    void Start()
    {
        ply = FindObjectOfType<Bound>(true).gameObject;
        gum = FindObjectOfType<Gum>(true).gameObject;
    }

    public void Teleport()
    {
        if (tele) return;
        gum.transform.position = new Vector3(anpotal.position.x, anpotal.position.y - 6.5f, -1);
        ply.transform.position = new Vector3(anpotal.position.x, anpotal.position.y, 0);
        tele = true;
        anpotal.GetComponent<Portal>().teletrue();
        Invoke("telenot", 1f);
        Invoke("telenot2", 1f);
    }

    public void telenot()
    {
        tele = false;
    }
    public void telenot2()
    {
        anpotal.GetComponent<Portal>().telenot();
    }

    public void teletrue()
    {
        tele = true;
    }
}
