using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

	public int TotalScore;
	public int TimeLeft = 10;

	// Use this for initialization
	void Start () {
	
		StartCoroutine (CountDown ());

	}
	
	// Update is called once per frame
	void Update () {

		GameObject.Find ("ScoreLabel").GetComponent<Text> ().text = "Score: "+ TotalScore;

		GameObject.Find ("TimeLabel").GetComponent<Text> ().text = "Time: "+ TimeLeft;

		}


	IEnumerator CountDown(){
		while (TimeLeft > 0) {
//			Debug.Log (TimeLeft);
			yield return new WaitForSeconds (1);
			TimeLeft--;

			if (TimeLeft == 5) {

				Debug.Log ("There are 5 seconds left!!");
			}
		}

			


		


	}


}
