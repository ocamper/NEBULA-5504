using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
