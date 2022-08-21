using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    private void Start()
    {
        Invoke("LoadTitle", 23f);
    }
    private void LoadTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
