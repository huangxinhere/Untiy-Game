using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use(){
        //因为不同物品有不同的使用方法，所以是抽象方法
        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory(){
        Inventory.instance.Remove(this);
    }
}
