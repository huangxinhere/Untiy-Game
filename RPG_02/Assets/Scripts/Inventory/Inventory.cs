using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake() {
        if (instance != null)
        {
            Debug.LogWarning("There is already an instance!");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();       //委托：事件——也就是方法
    public OnItemChanged onItemChangedCallback; //假设是事件的委托人，负责接受事件和执行事件

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add(Item item){
        if (!item.isDefaultItem)    //物品不是默认物品才会执行
        {
            if (items.Count >= space)
            {
                Debug.LogWarning("There is no enough space!");
                return false;
            }

            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke(); //数据一旦有变化，委托人开始执行
            }
            
        }
        return true;
    }

    public void Remove(Item item){
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
