using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;

    private void Start() {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        float speedPercent = agent.velocity.magnitude / agent.speed;    //前者是当前速度，后者是过程中最大的值
        animator.SetFloat("speedPercent", speedPercent, .1f, Time.deltaTime);   //增加过渡时间，然后告诉增量时间是什么
    }

}
