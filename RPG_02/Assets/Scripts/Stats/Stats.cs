using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//类的private数值皆可视化？
public class Stats
{
    //状态值。设置成一个类型，将会用于玩家和敌人
    [SerializeField]
    private int baseValue;

    private List<int> values = new List<int>();

    public int GetValue(){
        int finalValue = baseValue;
        values.ForEach(x => finalValue += x);
        return finalValue;
    }

    public void AddValue(int value){
        if (value != 0)
        {
            values.Add(value);
        }
    }

    public void RemoveValue(int value){
        if (value != 0)
        {
            values.Remove(value);
        }
    }
}
