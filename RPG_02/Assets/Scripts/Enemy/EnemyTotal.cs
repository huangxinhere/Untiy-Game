using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTotal : MonoBehaviour
{
    private int counts;
    ActionsManager actions;

    private void Start() {
        actions = ActionsManager.getInstance();
        actions.enemyChangedCallBack += CheckCounts;

        counts = transform.childCount;
    }

    private void CheckCounts(){
        counts = transform.childCount - 1;      //还没destory但已到达死亡状态的
        //Debug.Log("Now enemy's count is: " + counts);
        if (counts <= 0)
        {
            //Victory
            Debug.Log("Victory!!");

            actions.victory.Invoke();

        }
    }


}
