using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTarget : MonoBehaviour {
    // Спрайт для использования в качестве прицельной сетки.
    public Sprite targetImage;
    public Color targetColor;
    
    private Indicator currentIndicator;
    
    public void setActive(bool active)
    {
        if (currentIndicator == null)
        {
            currentIndicator = IndicatorManager.instance.AddIndicator(gameObject, targetColor, targetImage);
        }
        currentIndicator.show = active;
    }
}
