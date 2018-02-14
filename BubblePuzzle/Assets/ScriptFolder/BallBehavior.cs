using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

//	public Material[] mat;

	public bool IsExploding = false;
	public int CurrentlyCollidingSameColorBalls = 0;
	public List<Transform> AllSameColoredBallsCollision = new List<Transform> ();


	// Use this for initialization
	void Start () {
//
//		int chosenMaterial = Random.Range (0, mat.Length);
//		Debug.Log("Chosen material index is: " + chosenMaterial);
//		GetComponent<Renderer> ().material = mat [chosenMaterial];

	}

	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter(Collision col){

//		Debug.Log ("Ball has collided with" + col.transform.tag);


		if ((col.transform.tag == "Wall") || (col.transform.tag == "Ball")) {
			GetComponent<Rigidbody>().isKinematic = true;
			GetComponent<AudioSource> ().Play ();
		}

		if (col.transform.tag == "Ball" || (col.transform.tag == "Ball" && col.transform.tag == "Wall")) {
			if (GetComponent<Renderer> ().material.name == col.transform.GetComponent<Renderer>().material.name) {

				CurrentlyCollidingSameColorBalls++;
				AllSameColoredBallsCollision.Add(col.transform);
				if (CurrentlyCollidingSameColorBalls > 1) {
					Explode();


				}
				Debug.Log ("This object has the same material as me");

			}

		}

	}

	public void Explode(){
		Debug.Log ("Time to explooooodeeee :)");


		IsExploding = true;

		GameObject.Find("MainManager").GetComponent<MainManager>().TotalScore++;	
		//Tell my friends to explodee
		foreach (Transform ball in AllSameColoredBallsCollision) {

			if (ball.GetComponent<BallBehavior> ().IsExploding == false) {
				ball.GetComponent<BallBehavior> ().Explode ();
			}
		}

		//Now I shall perish in the void
		Destroy (gameObject);

	}
}
