using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Restart : MonoBehaviour,IPointerDownHandler {
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.Restart();
    }
}
