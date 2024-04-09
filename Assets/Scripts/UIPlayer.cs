using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPlayer : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI txt_points; 

    private void Start()
    {
        Player.onUpdateHealth += UpdateSliderHealth;
        Player.onUpdatePoints += UpdateTextPoints;
    }

    private void OnDestroy()
    {
        Player.onUpdateHealth -= UpdateSliderHealth;
        Player.onUpdatePoints -= UpdateTextPoints;  
    }

    private void UpdateSliderHealth(float value)
    {
        slider.value = value;
    }

    private void UpdateTextPoints(int points)
    {
        txt_points.text = $"Puntos; {points}";
    }
}
