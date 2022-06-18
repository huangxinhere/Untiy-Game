using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingBtn : MonoBehaviour
{
    public GameObject SettingPanel;

    bool isActive;

    public void OnBtnClick() {
        isActive = !isActive;
        if (isActive)
        {
            ShowMenu();
        }else
            HiddenMenu();
    }

    void ShowMenu(){
        SettingPanel.SetActive(true);
    }

    void HiddenMenu(){
        Animator[] animators = SettingPanel.GetComponentsInChildren<Animator>();
        foreach (var item in animators)
        {
            item.SetTrigger("out");
        }
    }

    


}
