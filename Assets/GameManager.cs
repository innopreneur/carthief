using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public Text scoreText, highestScore, gameOver, newHighScore, levelText, targetText;
    public static int score = 0;
    public float scoreMultiplier = 1f;
    public bool isPlayerDead = false;
    public float nextLevelDelay = 2f;
    private float timer, resetTimer;
    private static int highscore = 0;
    private bool isHighscore = false;
    private static int levelCount = 1;
    private static int levelTarget = 2;


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
        newHighScore.text = "";
        highestScore.text = "Best : " + highscore;
        timer = nextLevelDelay;
        resetTimer = nextLevelDelay;
        levelText.text = "";
        targetText.text = "";

    }

	void Update () {

        timer -= Time.deltaTime;
        if(timer > 0)
        {
            levelText.text = "Level " + levelCount;
            targetText.text = "Target " + levelTarget;
            
        }
        else
        {
            levelText.text = "";
            targetText.text = "";
        }
        if (!isPlayerDead)
        {
            scoreMultiplier -= Time.deltaTime;
            if (scoreMultiplier <= 0)
            {
                //score ++;
            }
        }
        else
        {
            ResetLevel();
        }
        scoreText.text = "Score : " + score;

        if (score >= levelTarget)
        {
            gameOver.text = "Level Complete";
            ResetLevel();
        }
        
    }

    //reset game if player is dead
    public void ResetLevel()
    {
        resetTimer -= Time.deltaTime;
        if (isPlayerDead)
        {
            scoreText.text = "";
            gameOver.text = "Game Over";
            if (score > highscore || highscore == 0)
            {
                highscore = score;
                score = 0;
                isHighscore = true;
            }

            if (isHighscore)
            {
                newHighScore.text = "New High Score : " + highscore;
                isHighscore = false;
            }
        }
        else
        {
            levelCount++;
            levelTarget *= 2;
        }
            if (resetTimer <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        
        
    }
}
