using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TargetCam : MonoBehaviour
{
    CinemachineTargetGroup target;
    int index = 0;

    private void Awake()
    {
        target = GetComponent<CinemachineTargetGroup>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10 || collision.gameObject.layer == 18 || collision.gameObject.layer == 16)
        {
            target.AddMember(collision.transform, 0, 5);
            //Debug.Log(target.FindMember(collision.transform));
            //target.m_Targets[target.FindMember(collision.transform)].weight = 100;
            StartCoroutine(WeightUp(collision.transform));
        }
    }

    private IEnumerator WeightUp(Transform tran)
    {
        for (float i = 0.1f; i < 1; i += 0.1f)
        {
            target.m_Targets[target.FindMember(tran.transform)].weight = i;
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
    private IEnumerator WeightDown(Transform tran)
    {
        for (float i = 0.9f; i > 0; i -= 0.1f)
        {
            target.m_Targets[target.FindMember(tran.transform)].weight = i;
            yield return new WaitForSeconds(0.1f);
        }
        target.RemoveMember(tran);
        yield return null;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10 || collision.gameObject.layer == 18 || collision.gameObject.layer == 16)
        {
            StartCoroutine(WeightDown(collision.transform));
        }
    }

}
