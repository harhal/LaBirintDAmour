using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Pair
{
    public SemaphoreLightElement left;
    public SemaphoreLightElement right;
}


enum GameStates
{
    wait,
    start,
    end,
    endGame
}


public class SemaphoreLogic : MonoBehaviour {

    [SerializeField] List<SemaphorePanelElement> UIPanelElements;
    [SerializeField] List<Pair> PanelsPairs;
    [SerializeField] float roundTime;
    [SerializeField] float timeDelta;
    [SerializeField] GameObject Door;
    StatsComponent playerLeft;
    StatsComponent playerRight;
    int previousType;



    bool isGameStart = false;
    int currentType;
    float leftTime;
    GameStates currentState = GameStates.start;

    private void Awake()
    {
        leftTime = roundTime;
    }

    private void Start()
    {
        playerLeft = GameObject.Find("Character1").GetComponent<StatsComponent>();
        playerRight = GameObject.Find("Character2").GetComponent<StatsComponent>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            isGameStart = true;
        if (isGameStart) {
            switch (currentState) { 
                case GameStates.start:
                    {
                        roundTime -= timeDelta;
                        if (roundTime < 0.5)
                        {
                            currentState = GameStates.endGame;
                            break;
                        }
                        leftTime = roundTime;
                        currentType = Random.Range(0, 4);
                        if (previousType == currentType)
                            currentType = currentType % 3 + 1;
                        previousType = currentType;
                        //PanelsPairs[currentType].left.SetActiveColor();
                        //PanelsPairs[currentType].right.SetActiveColor();
                        UIPanelElements[currentType].SetActiveColor();
                        currentState = GameStates.wait;
                        break;
                    }
                case GameStates.wait:
                    {
                        leftTime -= Time.deltaTime;
                        if (leftTime <= 0)
                        {
                            currentState = GameStates.end;
                            //TODO negative feedback
                            playerLeft.ChangeHealth(-5);
                            playerRight.ChangeHealth(-5);
                        }
                        if (PanelsPairs[currentType].left.isPressed && PanelsPairs[currentType].right.isPressed)
                        {
                            currentState = GameStates.end;
                            playerLeft.ChangeHealth(10);
                            playerRight.ChangeHealth(10);
                        }
                        break;
                    }
                case GameStates.end:
                    {
                        //PanelsPairs[currentType].left.SetDefaultColor();
                        //PanelsPairs[currentType].right.SetDefaultColor();
                        UIPanelElements[currentType].SetDefaultColor();
                        currentState = GameStates.start;
                        break;
                    }
                case GameStates.endGame:
                    {
                        isGameStart = false;
                        Debug.Log("Dealed with it");
                        //TODO open the door and destroy itself
                        break;
                    }
            }
        }
    }
}
