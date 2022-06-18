using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : CharacterStats
{
    public override void Die(Animator animator)
    {
        base.Die(animator);

        //死亡处理
        if (animator != null)
        {
            animator.SetTrigger("die");
        }

        //通知统计
        ActionsManager.getInstance().enemyChangedCallBack.Invoke();

        Destroy(gameObject, 5f);
    }
}
