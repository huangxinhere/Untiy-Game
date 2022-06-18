using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    Transform target;   
    NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

/*地点的跟踪*/
    public void MoveToPoint(Vector3 target){
        agent.SetDestination(target);
        FaceTarget(target);
    }

/*Interactable的跟踪*/
    public void FollowTarget(Interactable newTarget){
        agent.stoppingDistance = newTarget.radius * .8f;

        //目标移动的时候暂停导航对物体旋转的控制
        agent.updateRotation = false;

        target = newTarget.transform;
        
    }

    public void StopFollowing(){
        agent.stoppingDistance = 0f;    //归零
        agent.updateRotation = true;
        target = null;
    }

//这里有关于unity的数学视频：7：22
    void FaceTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));   //不会向上/下看
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 20f);
    }

    void FaceTarget(Vector3 target){
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));   //不会向上/下看
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 20f);
    }
}
