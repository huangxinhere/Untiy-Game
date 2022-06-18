using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrePare : MonoBehaviour
{
    public GameObject GetReady;
    public GameObject GO;
    public GameObject spawn;
    void Start()
    {
        StartCoroutine(PrepareRountine());
    }

    IEnumerator PrepareRountine()
    {
        //�ȴ�1����ʾready
        yield return new WaitForSeconds(1.0f);
        GetReady.SetActive(true);

        yield return new WaitForSeconds(2.0f);
        GetReady.SetActive(false);

        /*GO!*/
        GO.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        GO.SetActive(false);

        //���������ü�ʱ���
        GetComponent<Timer>().enabled = true;

        //��ʼ����
        spawn.SetActive(true);
    }
}
