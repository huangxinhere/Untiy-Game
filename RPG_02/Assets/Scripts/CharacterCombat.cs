using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCoolDown = 0f;  //攻击冷却时间
    private int attackChance = 2;

    public float attackDelay = .7f;
    Animator animator;

    CharacterStats myStats;             //共用抽象

    private void Update() {
        attackCoolDown -= Time.deltaTime;
    }

    private void Start() {
        myStats = GetComponent<CharacterStats>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    public void Attack(CharacterStats targetStats){             //被攻击

    /*攻击有效*/
        if (attackCoolDown <= 0)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay)); //数值处理

            attackCoolDown = 1f / attackSpeed;                  //周期处理
            attackChance--;                                     //攻击2次，冷却2秒
            if (attackChance <= 0)
            {
                attackChance = 2;
                attackCoolDown += 2;
            }
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay){
        yield return new WaitForSeconds(delay);

        animator.SetTrigger("attack");                          //攻击动画，本对象脚本组件

        stats.TakeDamage(myStats.damage.GetValue());
    }

}
