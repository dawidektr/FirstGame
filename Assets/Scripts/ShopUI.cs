using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private RectTransform shop;
    [SerializeField] private RectTransform content;
    [Header("Workers")]
    [SerializeField] private ShopWorkerUI shopWorkerUI;



    public void AddWorker(Worker worker,ClickerMenager clickerMenager)
    {
        var newWorker = Instantiate(shopWorkerUI, content);
        newWorker.Init(worker, clickerMenager);
        newWorker.UpdateUI();
    }

   

    public void OpenShop()
    {
        shop.gameObject.SetActive(true);
    }
    public void CloseShop()
    {
        shop.gameObject.SetActive(false);
    }
}
