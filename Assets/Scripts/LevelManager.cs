using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay =2f;
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }
    public void LoadGame()
    {
        
        // scoreKeeper.ResetScore();
            if(scoreKeeper != null)
        {
            scoreKeeper.ResetScore();
        } 

        SceneManager.LoadScene("Game");
              


    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);

    }
    public void LoadGameOver()
    {

       StartCoroutine(WaitAndLoad("Game Over",sceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }
    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
