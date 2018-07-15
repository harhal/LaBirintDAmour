using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemaphoreLightElement : MonoBehaviour {

    [SerializeField] Color defaultColor;
    [SerializeField] Color activeColor;
    [SerializeField]
    MeshRenderer Target;
    public bool isPressed = false;

    public void SetActiveColor()
    {
        Target.material.color = activeColor;
    }

    public void SetDefaultColor()
    {
        Target.material.color = defaultColor;
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
