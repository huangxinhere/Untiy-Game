using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }      //获取受限

    Animator animator;

    public Stats damage;
    public Stats armor;

    private void Awake() {
        currentHealth = maxHealth;
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        /* if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(damage.GetValue());
        }  */
    }

    public void TakeDamage(int damage){
        damage -= armor.GetValue();                     //伤害削减
        damage = Mathf.Clamp(damage, 0, int.MaxValue);  //伤害值不能为负数，否则成了“修复值”

        currentHealth -= damage;                        //掉血
        if (animator != null)
        {
            animator.SetTrigger("hit");                     //受伤动画
        }else
            Debug.Log("No hit animation!!");

        //Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die(animator);
        }
    }

    public virtual void Die(Animator animator){
        //Debug.Log("DIE!!");
    }
}
