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
        //等待1秒显示ready
        yield return new WaitForSeconds(1.0f);
        GetReady.SetActive(true);

        yield return new WaitForSeconds(2.0f);
        GetReady.SetActive(false);

        /*GO!*/
        GO.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        GO.SetActive(false);

        //！！！启用计时组件
        GetComponent<Timer>().enabled = true;

        //开始弹出
        spawn.SetActive(true);
    }
}
