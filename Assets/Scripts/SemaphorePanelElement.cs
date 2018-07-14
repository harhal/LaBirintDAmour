using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SemaphorePanelElement : MonoBehaviour {

    [SerializeField] Color defaultColor;
    [SerializeField] Color activeColor;
    Image image;

    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
    }

    public void SetActiveColor()
    {
        image.color = activeColor;
    }

    public void SetDefaultColor()
    {
        image.color = defaultColor;
    }
}
