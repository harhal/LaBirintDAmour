using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharacterSelection : MonoBehaviour {

    [SerializeField] Sprite Girl;
    [SerializeField] Sprite Boy;
    [SerializeField] Image leftPanel;
    [SerializeField] Image rightPanel;

    int count = 0;
    bool isFirstSelected = false;
    bool isSecondSelected = false;

    private void Update()
    {
            if((Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.S)) && !isFirstSelected)
            {
                ChangeIcon(leftPanel);
            }
            if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && !isSecondSelected)
            {
                ChangeIcon(rightPanel);
            }
            if(Input.GetKeyDown(KeyCode.F) && !isFirstSelected)
            {
                ApplySelection("player1", leftPanel.sprite);
                isFirstSelected = true;
            }
            if(Input.GetKeyDown(KeyCode.Delete) && !isSecondSelected)
            {
                ApplySelection("player2", rightPanel.sprite);
                isSecondSelected = true;
            }
    }

    void ChangeIcon(Image panel)
    {
        if (panel.sprite == Girl)
            panel.sprite = Boy;
        else
            panel.sprite = Girl;
    }

    void ApplySelection(string name, Sprite icon)
    {
        count++;
        int gender;
        if (icon == Girl)
            gender = 0;
        else
            gender = 1;
        PlayerPrefs.SetInt(name, gender);
        if (count == 2)
        {
            SceneManager.LoadScene("MasterScene_1");
        }
    }

}
