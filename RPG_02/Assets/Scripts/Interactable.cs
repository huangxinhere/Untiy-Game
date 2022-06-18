using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    bool isFocus = false;       //是否正在目标中{目标开始为true}
    bool hasInteracted = false; //是否已经接触
    public Transform interactableTransform; //这样互动点可以和物体本身分离
    Transform player;

    public virtual void Interect(){
        //Debug.Log("Interacting with " + interactableTransform.name);
    }

    private void Update() {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactableTransform.position);
            if (distance <= radius)
            {
                Interect();
                hasInteracted = true;
            }
        }
    }

/*是否关注*/
    public void OnFocused(Transform playerTransform){
        hasInteracted = false;
        isFocus = true;
        player = playerTransform;
    }

    public void DisFocused(){
        hasInteracted = false;
        isFocus = false;
        player = null;
    }

/*标记*/
    public void OnDrawGizmosSelected() {
        if (interactableTransform == null)
        {
            interactableTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactableTransform.position, radius);
    }
}
