using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   


// Reference: https://youtu.be/BLfNP4Sc_iA
public class HealthUI : MonoBehaviour
{

    [SerializeField] Slider healthSlider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image healthFill;
    
    private void Start() 
    {
        // Set the colour to green initially (we setup the color gradients in the editor)
        healthFill.color = gradient.Evaluate(1f);
    }

    public void UpdateHealthBar(float health)
    {
        // Update the health bar and the color gradient associated with the current fill value
        healthSlider.value = health;
        healthFill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }
}
