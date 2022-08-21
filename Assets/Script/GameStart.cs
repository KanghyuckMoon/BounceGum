using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class GameStart : MonoBehaviour
{
    [SerializeField]
    private Volume volume;

    private void Awake()
    {
        StartCoroutine(asd());
    }

    IEnumerator asd()
    {
        Time.timeScale = 0;
        float a = 1;
        yield return new WaitForSecondsRealtime(1f);
        for (int i = 0; i < 10;i++)
        {
            a = Mathf.Lerp(a, 0, 0.1f);
            volume.weight = a;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        volume.weight = 0;
        Time.timeScale = 1;
        yield return null;
    }
}
