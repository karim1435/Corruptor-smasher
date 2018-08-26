using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public abstract class Defender : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private float totalItem;
    public float TotalItem
    {
        get { return totalItem; }
        private set { totalItem = value; }
    }
    protected void SpendItem()
    {
        totalItem--;
    }
    protected bool IsItemAvailable()
    {
        return totalItem > 0;
    }
    protected abstract void KillAllIncomingEnemy();
    private void UseItem()
    {
        SpendItem();
        KillAllIncomingEnemy();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!GameManager.instance.IsGameRunning()) return;
        if (IsItemAvailable())
            UseItem();
    }
}
