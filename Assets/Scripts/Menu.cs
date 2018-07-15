using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {


    [SerializeField] GameObject threeButtons;
    [SerializeField] GameObject characterChoosePanel;
    [SerializeField] Sprite selectionIcon;
    

    public void StartGame()
    {
        threeButtons.SetActive(false);
        characterChoosePanel.SetActive(true);
        GetComponent<Image>().sprite = selectionIcon;
    }

    public void Exit()
    {
        Application.Quit();
    }

}
