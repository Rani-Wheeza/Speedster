using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetmaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        //print("Adjusting health bar");
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            slider.value -= 10;
        }

    }

    internal static void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        throw new NotImplementedException();
    }

    internal static void UpdateHealthBar(int currentHealth, float maxHealth)
    {
        throw new NotImplementedException();
    }
}
