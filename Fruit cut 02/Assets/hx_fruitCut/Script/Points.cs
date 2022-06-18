using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text PointText;
    int points;

    public void ChangePoints(int num)
    {
        if(points > 0)
        {
            points +=  num;
        }else if(num > 0)
        {
            points += num;
        }else
        {
            points = 0;
        }
        PointText.text = "·ÖÊý " + points;
    }

    public int getPoints()
    {
        return points;
    }
}
