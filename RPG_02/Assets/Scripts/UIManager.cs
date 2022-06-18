using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("开始菜单")]
    public Canvas UIcanvas;
    [Header("选择菜单")]
    public GameObject OptionPanel;
    [Header("胜利界面")]
    public GameObject VictoryPanel;
    [Header("失败界面")]
    public GameObject failPanel;

    Animator CanvasAnimator;
    Animator optionAnimator;
    ActionsManager actions;


    private void Start() {
        actions = ActionsManager.getInstance();
        actions.victory += ShowVictory;
        actions.fail += ShowFailure;

        CanvasAnimator = UIcanvas.GetComponent<Animator>();
        optionAnimator = OptionPanel.GetComponent<Animator>();
    }

/*结束游戏*/
    public void QuitGame(){
        Application.Quit();
    }

/*胜利*/
    public void ShowVictory(){
        VictoryPanel.SetActive(true);
    }

    public void Restart(){
        //记得在按钮设置panel消失
        
        //restart
        Debug.Log("Restart here!!!");
    }

/*失败*/
    public void ShowFailure(){
        failPanel.SetActive(true);
    }
}
