using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;
    private ActionsManager actions;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        actions = ActionsManager.getInstance();
    }

    #endregion

    public GameObject player;   //用来存储固定的变量，以便各种游戏对象来直接获取

    public void KillPlayer(){
        actions.fail.Invoke();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
