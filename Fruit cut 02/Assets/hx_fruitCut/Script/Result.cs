using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Text showText;

    private void Start()
    {
        
    }
    public void ShowPoints()
    {
        showText.text =  "×îÖÕ·ÖÊý£º" + GetComponent<Points>().getPoints().ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
