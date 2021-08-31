using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; //unity choose healthbar in Slider slot
    public Gradient gradient;

    public Image fill; //drag fill image into this slot

    //set value at max/startup
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health; // make sure slider starts at max health

        fill.color = gradient.Evaluate(1f); //sets color at max & beg of game
    }

    //when player takes damage
    public void SetHealth(int health)
    {
        slider.value = health;

        //normalized value is between 0 -1
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
