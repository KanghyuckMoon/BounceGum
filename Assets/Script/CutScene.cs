using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    [SerializeField]
    private GameObject titles;
    [SerializeField]
    private GameObject Cutscene;
    [SerializeField]
    private Text bgmtext;
    [SerializeField]
    private Camera maincam;
    private bool bgmon = true;
    private int coincount = 38;

    private int dan = 0;

    private void Start()
    {
        System.GC.Collect();
        dan = 0;
        if (PlayerPrefs.GetInt("CAM") == 1)
        {
            dan = 1;
            maincam.GetComponent<Animator>().Play("returnmenucam");
        }
        PlayerPrefs.SetInt("CAM", 0);
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "TitleScene")
        {
            if(Input.GetMouseButtonDown(0))
            {
                Touch();
            }
        }
        else if(SceneManager.GetActiveScene().name == "Ending")
        {

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (dan == 0)
            {
            Application.Quit();
            }
            else if (dan == 1)
            {
                Returnmove();
            }
        }
    }

    public void Touch()
    {
        if (dan == 0)
        {
            dan = 2;
            maincam.GetComponent<Animator>().Play("zoomanim");
            Invoke("Danone", 2f);
        }
    }

    public void Returnmove()
    {
        maincam.GetComponent<Animator>().Play("returncam");
        dan = 2;
        Invoke("Danzero",2f);
    }

    public void Danzero()
    {
        dan = 0;
    }
    public void Danone()
    {
        dan = 1;
    }

    public void SceneEnding()
    {

    }
    public void SceneGame()
    {

    }
    public void FirstStart()
    {
        dan = 10;
        PlayerPrefs.SetFloat("boundx", 3.5f);
        PlayerPrefs.SetFloat("boundy", -3.5f);
        PlayerPrefs.SetInt("coins", 0);
        for(int i = 0; i < coincount; i++)
        {
            PlayerPrefs.SetInt("EAT" + i,0);
        }
        maincam.GetComponent<Animator>().Play("normalcam");
        titles.SetActive(false);
        Cutscene.SetActive(true);
        Invoke("LoadIngame", 6.5f);
    }

    public void LoadIngame()
    {
        SceneManager.LoadScene("Ingame");
    }
    public void ContinueStart()
    {
        SceneManager.LoadScene("Ingame");
    }

    public void ChangeBgm()
    {
        bgmon = !bgmon;
        PlayerPrefs.SetInt("BGMON",bgmon ? 1:0);
        if(bgmon)
        {
            bgmtext.text = "πË∞Ê¿Ωæ«\nON";
        }
        else
        {
            bgmtext.text = "πË∞Ê¿Ωæ«\nOFF";
        }
    }
}
