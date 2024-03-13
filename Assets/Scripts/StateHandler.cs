using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHandler : MonoBehaviour
{
    // Define an enum to represent the different game states
    public enum State
    {
        MainMenu,
        Playing,
        GameOver
    }

    // The current state of the game
    public State currentState = State.MainMenu;

    // Reference to the player object
    public GameObject player;

    // Reference to the game over UI
    public GameObject gameOverUI;

    void Update()
    {
        // Check for input to change the state
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Change the state based on the current state
            switch (currentState)
            {
                case State.MainMenu:
                    StartGame();
                    break;
                case State.Playing:
                    GameOver();
                    break;
                case State.GameOver:
                    RestartGame();
                    break;
                default:
                    break;
            }
        }
    }

    void StartGame()
    {
        // Set the state to Playing
        currentState = State.Playing;

        // Activate the player object
        player.SetActive(true);
    }

    void GameOver()
    {
        // Set the state to GameOver
        currentState = State.GameOver;

        // Deactivate the player object
        player.SetActive(false);

        // Show the game over UI
        gameOverUI.SetActive(true);
    }

    void RestartGame()
    {
        // Set the state to MainMenu
        currentState = State.MainMenu;

        // Reset the game
        player.transform.position = Vector3.zero;
        player.SetActive(false);
        gameOverUI.SetActive(false);
    }
}
