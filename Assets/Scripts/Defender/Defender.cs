using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using Assets.Scripts.Collectible_Item;

public abstract class DefenderParent : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private float totalItem;
    public float TotalItem
    {
        get { return totalItem; }
        protected set { totalItem = value; }
    }
    public void ExtraItem(float health)
    {
        TotalItem += health;
    }
    protected void SpendItem()
    {
        TotalItem--;
    }
    protected bool IsItemAvailable()
    {
        return TotalItem > 0;
    }
    protected abstract void KillAllIncomingEnemy();
    private void UseItem()
    {
        SpendItem();
        KillAllIncomingEnemy();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (!GameManager.instance.IsGameRunning()) return;
            if (IsItemAvailable())
                UseItem();
        }
        
    }
}
