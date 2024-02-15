using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetHealth(float health)
    {
        slider.value = health; // Works with storing health
    }

    public void TakeDamage(float damage)
    {
        slider.value -= damage;
    }
}
