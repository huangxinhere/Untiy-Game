using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySlider : MonoBehaviour
{
    CharacterStats myStats;
    public Slider mySlider;
    public Gradient gradient;   //范围：0-1
    public Image fill;

    private void Start() {
        myStats = GetComponentInParent<CharacterStats>();
        //Debug.Log(myStats.gameObject.name);

        mySlider.value = myStats.currentHealth;
        mySlider.maxValue = myStats.maxHealth;

        fill.color = gradient.Evaluate(1f);
    }

    private void Update() {
        mySlider.value = myStats.currentHealth;

        fill.color = gradient.Evaluate(mySlider.normalizedValue);
    }

}
