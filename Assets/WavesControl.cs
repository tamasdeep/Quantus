using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesControl : MonoBehaviour {

	[SerializeField]
	Transform[] waypoints;

	[SerializeField]
	float moveSpeed = 2f;

    
    public GameObject model;

    int waypointIndex = 0;

	void Start () {
        model = Instantiate(model);
        model.transform.position = waypoints [waypointIndex].transform.position;
       
	}

	void Update () {
		Move ();
	}

	void Move()
	{
        //Debug.Log("model position" + model.transform.position);
        //Debug.Log("waypoint position " + waypoints[waypointIndex].transform.position);
        //Debug.Log("moving " + (model.transform.position == waypoints[waypointIndex].transform.position));
        model.transform.position = Vector3.MoveTowards (model.transform.position,
												waypoints[waypointIndex].transform.position,
												moveSpeed * Time.deltaTime);

		if (model.transform.position == waypoints [waypointIndex].transform.position) {
			waypointIndex += 1;
		}
				
		if (waypointIndex == waypoints.Length)
			waypointIndex = 0;
	}

}
