using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class digitSlider : MonoBehaviour
{
    public int value = 0;
    public int maxValue = 3;

    public Color valuedColor = Color.green;
    public Color unvaluedColor = Color.white;

    int oldValue = 0;
    int oldMaxValue = 3;
    Color oldValuedColor = Color.green;
    Color oldUnvaluedColor = Color.white;

    digitSlider oldSlider;

    GameObject unit;

    [SerializeField]
    RectTransform[] units = new RectTransform[1];

    float digitWidth = 60;

    void Start()
    {
        unit = transform.GetChild(0).gameObject;

        units = new RectTransform[maxValue];
        digitWidth = GetComponent<RectTransform>().sizeDelta.x / maxValue;
        units = new RectTransform[maxValue];
        for (int i = 1; i <= maxValue; i++)
        {
            units[i] = Instantiate(unit, transform).GetComponent<RectTransform>();
            units[i].anchoredPosition = new Vector2(i * digitWidth, 0);
            units[i].sizeDelta = new Vector2((maxValue - i) * digitWidth, 0);
            if (i <= value)
            {
                units[i].GetComponent<Image>().color = valuedColor;
            }
            else
            {
                units[i].GetComponent<Image>().color = unvaluedColor;
            }
        }
    }
}
