using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {


    [SerializeField] GameObject threeButtons;
    [SerializeField] GameObject characterChoosePanel;
    

    public void StartGame()
    {
        threeButtons.SetActive(false);
        characterChoosePanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
