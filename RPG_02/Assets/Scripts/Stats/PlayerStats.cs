using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    //继承了共有的：防护和受伤两种值；受伤方法和死亡方法
    //要写出特有的：装备——更新防护值和受伤值
    
    private void Start() {
        EquipmentManager.instance.onEquipmentChanged += ValueChanged;
    }

    private void ValueChanged(Equiment newItem, Equiment oldItem){
        if (newItem != null)
        {
            armor.AddValue(newItem.armorValue);     //身上装备防御值和伤害值的累加
            damage.AddValue(newItem.damageValue);
        }

        if (oldItem != null)
        {
            armor.RemoveValue(oldItem.armorValue);
            damage.RemoveValue(oldItem.damageValue);
        }
    }

    public override void Die(Animator animator)
    {
        base.Die(animator);

        //kill the player
        PlayerManager.instance.KillPlayer();
    }
}
