using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharacterSelection : MonoBehaviour {

    [SerializeField] List<GameObject> upPanel;
    [SerializeField] List<GameObject> downPanel;

    int count = 0;
    bool isFirstSelected = false;
    bool isSecondSelected = false;

    private void Update()
    {
            if((Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.D)) && !isFirstSelected)
            {
                ChangeIcon(upPanel);
            }
            if((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && !isSecondSelected)
            {
                ChangeIcon(downPanel);
            }
            if(Input.GetKeyDown(KeyCode.F) && !isFirstSelected)
            {
                ApplySelection("player1", upPanel);
                isFirstSelected = true;
            }
            if(Input.GetKeyDown(KeyCode.Delete) && !isSecondSelected)
            {
                ApplySelection("player2", downPanel);
                isSecondSelected = true;
            }
    }

    void ChangeIcon(List<GameObject> animations)
    {
        foreach(GameObject obj in animations)
        {
            obj.SetActive(!obj.activeInHierarchy);
        }
    }

    void ApplySelection(string name, List<GameObject> animations)
    {
        count++;
        for(int i = 0; i < animations.Count; i++)
        {
            if(animations[i].activeInHierarchy)
                PlayerPrefs.SetInt(name, i);
        }
        if (count == 2)
        {
            SceneManager.LoadScene("MasterScene_Artyom");
        }
    }

}
