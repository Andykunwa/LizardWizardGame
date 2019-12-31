using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour {

	public Transform[] points;
	private int destPoint;
	public NavMeshAgent agent;
	public Animator enemyAnimations;

	// Use this for initialization
	void Start () {
			enemyAnimations = GetComponent<Animator> ();
			agent = GetComponent<NavMeshAgent> ();
			agent.autoBraking = false;

			GoToNextPoint ();
	}

	void GoToNextPoint() {
			if (points.Length == 0)
				return;

			agent.destination = points [destPoint].position;
			//float step = 5 * Time.deltaTime;
			//transform.position = Vector3.MoveTowards(transform.position, points[destPoint].position, step);
			destPoint = (destPoint + 1) % points.Length;
	}
	
	// Update is called once per frame
	void Update () {
			if (!agent.pathPending && agent.remainingDistance < 0.5f)
				GoToNextPoint ();
		}
}
