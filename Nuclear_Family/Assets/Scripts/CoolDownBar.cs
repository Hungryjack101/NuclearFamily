using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    
    public void SetMaxBar(float cooldown) {
        slider.maxValue = cooldown;
        slider.value = cooldown;
        
        fill.color = gradient.Evaluate(1f);
    }
    
    public void SetCool(float cooldown) {
        slider.value = cooldown;
        
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
