using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    Camera cam;
    PlayerMotor motor;

    private void Start() {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    private void Update() {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            //如果点击的是ui，不执行人物移动和拾取物品逻辑
            return;
        }

    /*点击到运动的位置*/
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)){
                motor.MoveToPoint(hit.point);

                //取消聚焦物品
                RemoveFocus();
            }
        }

    /*与物品互动*/
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //聚焦物品
            if(Physics.Raycast(ray, out hit)){
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable)
                {
                    SetFocus(interactable);
                }
                
            }
        }
    }

    void SetFocus(Interactable newTarget){
        //当点击其它物品时，也要取消对之前的关注
        if (newTarget != focus)
        {
            if (focus != null)  //前一个focus可能是空的，因为被取消掉
            {
                focus.DisFocused();
            }
            
            focus = newTarget;
            motor.FollowTarget(newTarget);
        }

        //确保设置关注的是最新的
        newTarget.OnFocused(transform);
    }

//点击不可互动物品时才会取消跟随
    void RemoveFocus(){
        if (focus != null)
        {
            focus.DisFocused();
        }
        
        focus = null;
        motor.StopFollowing();
    }
}
