using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;
    public override void Interect()
    {
        base.Interect();

        PickUp();
    }

    void PickUp(){
        Debug.Log("Picking up " + item.name);
        bool isPickUped = Inventory.instance.Add(item);
        if (isPickUped)
        {
            Destroy(gameObject);
        }
        
    }
}
