using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//new using statement
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject hazard; // what are we spawning
    public Vector2 spawnValue; // where do we spawn Hazards
    public int hazardCount; // how many hazards per wave
    public float startWait; // how long until hazard wave starts
    public float spawnWait; // how long between each hazard in each wave
    public float waveWait; // how long between each wave of enemies

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

	// Use this for initialization
	void Start () {
        score = 0;

        //ScoreText.text = "";
        restartText.text = "";
        gameOverText.text = "";

        StartCoroutine(SpawnWaves());
    }
	
	// Update is called once per frame
	void Update () {
        if(restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // the old way of restarting game.
                //Application.LoadLevel(Application.loadedLevel);

                //The new way of loading a level
                //SceneManager.LoadScene("SpaceShooter"); // <-- This works fine but prone to error

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // <-- better but more complicated.
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait); // pause Wait time before game first wave
        while(true)
        {
            for(int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y,spawnValue.y));
                //                                      12                         -3.5          3.5

                Quaternion spawnRotation = Quaternion.identity; // default rotation
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait); //Wait time between spawning each asteroid
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                restartText.gameObject.SetActive(true);
                restartText.text = "Press R for restart";
                restart = true;
                break;
            }
        }
    }
    //Update the score text
    void updateScore()
    {
        ScoreText.text = "Score: " + score;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        // score = score + newScoreValue
        //Debug.Log("Score is " + score);
        updateScore();
    }

    public void GameOver()
    {
        //Debug.Log("Game is Over");
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
