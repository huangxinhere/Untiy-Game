using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    Animator animator;
    CharacterCombat enemyCombat;
    CharacterStats enemyStat;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        enemyCombat = GetComponent<CharacterCombat>();
        enemyStat = GetComponent<CharacterStats>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        animator.SetBool("isRunning", agent.speed >= 0.15 ? true : false);

        if (distance <= lookRadius && enemyStat.currentHealth >= 0)
        {
            agent.SetDestination(target.position);
            FaceTarget();

            if (distance <= agent.stoppingDistance)
            {
                //attack：敌人 攻击 玩家
                CharacterStats playerStats = target.GetComponent<CharacterStats>();
                if (playerStats != null)
                {
                    enemyCombat.Attack(playerStats);
                }
                
            }
        }
    }

    void FaceTarget(){
        agent.updateRotation = false;
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRoatation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRoatation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
