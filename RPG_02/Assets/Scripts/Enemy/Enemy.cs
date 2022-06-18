using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats enemyStats;

    private void Start() {
        playerManager = PlayerManager.instance;
        enemyStats = GetComponent<CharacterStats>();
    }

    public override void Interect()
    {
        //玩家右击会调用这个方法，所以写在这里：玩家 攻击 敌人
        base.Interect();

        //attacked
        CharacterCombat playerCombat = 
            playerManager.player.GetComponent<CharacterCombat>();

        if (playerCombat != null)
        {
            playerCombat.Attack(enemyStats);
        }
        
    }
}
