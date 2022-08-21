using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector2 saveposition;
    [SerializeField]
    private Sprite[] sprites;
    private bool saved = false;
    private GameObject particle;

    private void Start()
    {
        particle = transform.GetChild(0).gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
        saveposition = transform.position;
    }

    public void SaveOn()
    {
        if(!saved)
        {
            spriteRenderer.sprite = sprites[1];
            particle.SetActive(true);
            Invoke("Particlefalse", 0.7f);
            PlayerPrefs.SetFloat("boundx", saveposition.x);
            PlayerPrefs.SetFloat("boundy", saveposition.y);
            saved = true;
        }
    }
    private void Particlefalse()
    {
        particle.SetActive(false);
    }
}
