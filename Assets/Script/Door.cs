using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public int needcoin = 0;
    private Text needText;

    private void Start()
    {
        needText = GetComponentInChildren<Text>();
        needText.text = string.Format("{0}", needcoin);
    }
}
