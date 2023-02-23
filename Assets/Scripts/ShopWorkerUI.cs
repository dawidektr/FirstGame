using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopWorkerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private Button buyButton;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI pointsPerSecondsText;


    public void UpdateUI(Worker worker)
    {
        nameText.text = worker.workerName;
        powerText.text = worker.power.ToString();
        priceText.text = worker.price.ToString();
        pointsPerSecondsText.text =  $"{worker.pointsPerSeconds.ToString()}/s";
        buyButton.onClick.AddListener(delegate {
            BuyButtonClick(worker.price,worker.power);        
        });
    }

    private void BuyButtonClick(int price,int power)
    {
        ClickerMenager.OnItemBought?.Invoke(price,power);
    }

   

}



