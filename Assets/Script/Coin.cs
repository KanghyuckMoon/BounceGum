using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private int indexcoin = 0;
    private bool eat = false;

    private void OnEnable()
    {
        eat = false;
    }

    private void Start()
    {
        if(PlayerPrefs.GetInt("EAT" + indexcoin) == 1)
        {
            eat = true;
        }
        if(eat)
        {
            gameObject.SetActive(false);
        }
    }
    public void Eat()
    {
        eat = true;
        PlayerPrefs.SetInt("EAT" + indexcoin, 1);
    }
}
