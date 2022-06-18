using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager
{
    private ActionsManager(){}

    private static class ActionsSingleton{
        public static ActionsManager INSTANCE = new ActionsManager();
    }

    public static ActionsManager getInstance(){
        return ActionsSingleton.INSTANCE;
    }

    /*统计敌人数量*/
    public delegate void OnEnemyChanged();
    public OnEnemyChanged enemyChangedCallBack;//会在delegate之前定义为空吗？

    /*胜利*/
    public delegate void Victory();
    public Victory victory;

    /*失败*/
    public delegate void Fail();
    public Fail fail;
}
