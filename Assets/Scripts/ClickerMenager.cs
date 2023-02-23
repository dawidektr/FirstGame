using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClickerMenager : MonoBehaviour
{
    public static UnityEvent<int,int> OnItemBought = new UnityEvent<int,int>();
 

    [Header("General")]
    [SerializeField] private ClickerUI clickerUI;
    [SerializeField] private Button clickerButton;

    [Header("Shop")]
    [SerializeField] private ShopUI shopUI;
    [SerializeField] private Button openButton;
    [SerializeField] private Button closeButton;

    [SerializeField] private List<Worker> workers;


    private int pointsCounter = 0;
    private int PointsPerSecord = 0;

    private void Start()
    {
        clickerUI.updateUI(pointsCounter,PointsPerSecord);
        clickerButton.onClick.AddListener(AddPoints);
        shopUI.CloseShop();
        openButton.onClick.AddListener(shopUI.OpenShop);
        closeButton.onClick.AddListener(shopUI.CloseShop);

        foreach(Worker worker in workers)
        {
            shopUI.AddWorker(worker);
        }

        OnItemBought.AddListener(BuyItem);
        InvokeRepeating(nameof(AddPointsPerSecond), 0f, 1f);
    }

    private void BuyItem(int price,int power)
    {
       if(price<=pointsCounter)
        {
            PointsPerSecord += power;
            pointsCounter -= price;
            clickerUI.updateUI(pointsCounter, PointsPerSecord);
        }
    }

    private void AddPoints()
    {
        pointsCounter += 1;
        clickerUI.updateUI(pointsCounter, PointsPerSecord);
    }

    private void AddPointsPerSecond()
    {
        if(PointsPerSecord>0)
        {
            pointsCounter += PointsPerSecord;
            clickerUI.updateUI(pointsCounter, PointsPerSecord);
        }
    }
}
