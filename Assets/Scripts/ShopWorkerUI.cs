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
    [SerializeField] private TextMeshProUGUI workerCounter;


    private Worker worker;
    private ClickerMenager clickerMenager;

    public void Init(Worker worker,ClickerMenager clickerMenager)
    {
        this.worker = worker;
        this.clickerMenager = clickerMenager;
    }

    public void UpdateUI()
    {
        nameText.text = $"{worker.workerName} {worker.workerCounter}";
        powerText.text = worker.power.ToString();
        priceText.text = worker.price.ToString();
        pointsPerSecondsText.text =  $"{worker.pointsPerSeconds.ToString()}/s";
        buyButton.onClick.AddListener(delegate {
            BuyButtonClick(worker.price,worker.power);        
        });
    }

    private void BuyButtonClick(int price,int power)
    {
        if (worker.price<= clickerMenager.PointsCounter)
        {
            ClickerMenager.OnItemBought?.Invoke(price,power);
            worker.buyWorker();
            UpdateUI();
        }
    }

  

}



