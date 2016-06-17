using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public Text scoreText;
    public Text gameOver;
    public static int score = 0;
    public float scoreMultiplier = 1f;
    public bool isPlayerDead = false;
    public float nextLevelDelay = 2f;
    private float timer;


    void Start () {
	
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        scoreText.text = "Score : " + score;
        gameOver.text = "";
        timer = nextLevelDelay;

    }

	void Update () {

        if (!isPlayerDead)
        {
            scoreMultiplier -= Time.deltaTime;
            if (scoreMultiplier <= 0)
            {
                score ++;
            }
        }
        scoreText.text = "Score : " + score;

        ResetLevel();
    }

    //reset game if player is dead
    public void ResetLevel()
    {
        if (isPlayerDead)
        {
            
            timer -= Time.deltaTime;
            scoreText.text = "";
            gameOver.text = "Game Over";
            if (timer <= 0)
            { 
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
    }
}
