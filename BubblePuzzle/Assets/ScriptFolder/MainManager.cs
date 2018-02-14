using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

	public int TotalScore;
	public int TimeLeft = 30;
    public Text RestartText;
    public Text GameOverText;

    private bool gameOver;
    private bool restart;

	// Use this for initialization
	void Start () {

        gameOver = false;
        restart = false;
        RestartText.text = "";
        GameOverText.text = "";

		StartCoroutine (CountDown ());

	}
	
	// Update is called once per frame
	void Update () {

        if (restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Main");
                Time.timeScale = 1;

            }

        }

        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                GameObject.Find("Canon").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        GameObject.Find ("ScoreLabel").GetComponent<Text> ().text = "Score: "+ TotalScore;

		GameObject.Find ("TimeLabel").GetComponent<Text> ().text = "Time: "+ TimeLeft;

		}


    IEnumerator CountDown()
    {
        while (TimeLeft > 0)
        {
            //			Debug.Log (TimeLeft);
            yield return new WaitForSeconds(1);
            TimeLeft--;

            if (TimeLeft == 5)
            {

                Debug.Log("There are 5 seconds left!!");
            }
        }
        if (TimeLeft == 0)
        {
            GameOver();
        }

        if (gameOver)
        {
            RestartText.text = "Press R to restart the game";
            restart = true;
        }
    }
        public void GameOver() {

        GameOverText.text = "Game Over!!";
        gameOver = true;
        Debug.Log("The Game is Over");
        Time.timeScale = 0;


    }

		


	


}
