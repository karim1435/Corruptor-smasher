using UnityEngine;
using System.Collections;
using Assets.Assets;

public class ElectricArea : MonoBehaviour {

    public delegate void TriggerZone(GameObject other);

    public event TriggerZone OnElectricInArea;
    public event TriggerZone OnElectricOffArea;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tag.Enemy)
            if (OnElectricInArea != null)
                OnElectricInArea(other.gameObject);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == Tag.Enemy)
            if (OnElectricOffArea != null)
                OnElectricOffArea(other.gameObject);
    }
}
