using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public int winNumber;
    [SerializeField] private int winCondition;

    private void Update()
    {
        // Checking if the win condition equal to number of right place win (>= to assure that the player will win at any cost)
        if (winNumber >= winCondition)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
