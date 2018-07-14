﻿using System.Collections;
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


public class SemaphoreLogic : MonoBehaviour, IQuest {

    [SerializeField] List<Color> UIColors;
    [SerializeField] List<Pair> PanelsPairs;
    [SerializeField] float roundTime;
    [SerializeField] float timeDelta;
    [SerializeField] DoorsController Door;
    StatsComponent playerLeft;
    StatsComponent playerRight;
    int previousType;
    Image image;



    bool isGameStart = false;
    int currentType;
    float leftTime;
    GameStates currentState = GameStates.start;

	public void RunQuest()
	{
		isGameStart = true;
	}

	private void Awake()
    {
        leftTime = roundTime;
    }

    private void Start()
    {
		playerLeft = FindObjectOfType<CharactersOwner>().Left.GetComponent<StatsComponent>();
        playerRight = FindObjectOfType<CharactersOwner>().Right.GetComponent<StatsComponent>();
	}

    private void Update()
    {           
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
                        image.color=UIColors[currentType];
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
                        image.color = Color.white;
                        currentState = GameStates.start;
                        break;
                    }
                case GameStates.endGame:
                    {
                        isGameStart = false;
                        Debug.Log("Dealed with it");
						Door.Open();
                        //TODO open the door and destroy itself
                        break;
                    }
            }
        }
    }
}
