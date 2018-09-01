using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIDefender : MonoBehaviour {
    [SerializeField]
    private Text bombText;
    [SerializeField]
    private Text electricText;
    [SerializeField]
    private Text poisonText;

    private float currentBomb;
    private float currentElectric;
    private float currentPoison;

    private Bomb bomb;
    private Poison poison;
    private Electric electric;
    void Start()
    {
        bomb = FindObjectOfType<Bomb>();
        electric = FindObjectOfType<Electric>();
        poison = FindObjectOfType<Poison>();
    }
    void Update()
    {
        ShowNumberBomb();
        ShowNumberElectric();
        ShowNumberPosion();
    }

    private void ShowNumberBomb()
    {
        currentBomb = bomb.TotalItem;
        if (bombText)
            bombText.text = currentBomb.ToString();
    }
    private void ShowNumberElectric()
    {
        currentElectric =electric.TotalItem;
        if (electricText)
            electricText.text = currentElectric.ToString();
    }

    private void ShowNumberPosion()
    {
        currentPoison = poison.TotalItem;
        if (poisonText)
            poisonText.text = currentPoison.ToString();
    }
}
