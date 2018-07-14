using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemaphoreLightElement : MonoBehaviour {

    [SerializeField] Color defaultColor;
    [SerializeField] Color activeColor;
    public bool isPressed = false;

    public void SetActiveColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = activeColor;
    }

    public void SetDefaultColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(8))
            isPressed = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer.Equals(8))
            isPressed = false;
    }

}
