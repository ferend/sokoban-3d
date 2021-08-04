using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    
    public GameObject completedMenu;
    public LevelGoal levelGoal;

  
    public void LevelCompleted()
    {
        completedMenu.SetActive(true);
        FindObjectOfType<PauseMenu>().Resume();
        // Time.timeScale = 0f;
    }

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GameOver");
            Restart();
        }
    }

    void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }
}
