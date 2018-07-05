﻿using UnityEngine;
using System.Collections;

public class spawn1 : MonoBehaviour {

	//Interval between each call 
	private float interval=1f;

	//Distance from player to new object
	float z;

	//Distance
	private float dist = 40f;

	//This one identifies that doesn't start the "invoke repeating" function
	private bool done=false;

	//Gets the actual time
	private float time;

	//Identifies the next X and Y positions to new object
	private float x;
	private float y;

	//increase?
	private int incr=1;

	//the Prefab Cube, cointaining all foods
	public GameObject pref;

	public GameObject son;

	// Make the new isntance
	void make(){

		//0 - Indicates thats gonna be a good food
		//1 - Indicates thats gonna be a bad one
		//the END IS NOT INCLUSIVE
		int roubo = Random.Range(0,3);
		int choose;
		if (roubo == 0 || roubo == 1) {
			choose = 0;
		} else {
			choose = 1;
		}

		string nome;

		// Position in line
		int pos = Random.Range(2,5)-2;
		position (pos);

		//Making and positioning the cube with all foods
		GameObject item = Instantiate (pref) as GameObject;
		item.transform.position = new Vector3 (x, y, z+dist);

		//Setting the new kind of this food.
		//This "name" will be comparable inside of prefab
		item.name=choose.ToString();

		//Getting the son 
		//0 - potato
		//1 - Apple
		//Getting another random, to detect with BAD or GOOD food will appear
		son = item.transform.GetChild(choose).gameObject;



		// Activating the son
		son.SetActive(true);

	}


	// This one summon a new food in the path
	/*void spawning(){
		
		//0 - Indicates thats gonna be a good food
		//1 - Indicates thats gonna be a bad one
		//the END IS NOT INCLUSIVE
		int choose = Random.Range (0,2);
		//make another object


		//Position
		int pos = Random.Range(2,5)-2;
		position (pos);

		//Starting a new item in path
		GameObject item;
		if (choose == 1) {
			item = Instantiate (good) as GameObject;
		} else {
			item = Instantiate (trash) as GameObject;
		}
		//The new position
		item.transform.position = new Vector3 (x, y, pl.transform.position.z+dist);
	}*/

	//This waits some seconds
	bool wait(float t){
		time += Time.deltaTime;
		if (time > t){
			return true;
		}
		return false;
	}

	//Calling the function call every "interval" seconds
	void call(){ InvokeRepeating ("make",interval,  interval); }


	// Update is called once per frame
	void Update () {
		z = player1.z;


		if (!wait(interval)){return;}
		Invoke ("make", 0.1f);
		time = 0;

		//good interval
		interval = 0.31f;
		/*
		//increasing
		if (incr == 1) {
			//getting faster
			if (interval <= 0.5f) {
				incr = 0;
			} else {
				interval -= 0.1f;
			}

		//Decreasing
		} else {
			//Getting slower
			if (interval >= 1f) {
				incr = 1;
			} else {
				interval += 0.1f;
			}
		}
		*/



	}


	//Set a new position
	void position(int v){
		switch(v){
		case 0:
			x = -0.7f;
			y = -3.30f;
			break;
		case 1:
			x = 0.25f;
			y = -3.30f;
			break;
		case 2:
			x = 1.25f;
			y = -3.30f;
			break;
		}

	}
}
