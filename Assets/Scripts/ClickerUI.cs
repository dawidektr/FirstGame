using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private TextMeshProUGUI pointsPerSecondsText;


    public void updateUI(int amount,int points)
    {
       counterText.text = $"Points {amount}";
       pointsPerSecondsText.text = $"{points}/s";
    }

}
