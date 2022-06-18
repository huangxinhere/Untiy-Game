using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equiment : Item
{
    public EquipmentSlot equipmentSlot; //防护的部位

    public int armorValue;              //护甲修改器（防护值）
    public int damageValue;             //伤害值

    public override void Use()
    {
        base.Use();

        EquipmentManager.instance.Equip(this);   //装备   

        RemoveFromInventory();                   //从物品栏中移除
    }
}

public enum EquipmentSlot{
    Helm, Shield, Sword
}
