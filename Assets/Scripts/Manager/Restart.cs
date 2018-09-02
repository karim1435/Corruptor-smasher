using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Restart : MonoBehaviour,IPointerDownHandler {
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.instance.Restart();
    }
}
