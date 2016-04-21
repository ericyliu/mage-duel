using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	public Dictionary<KeyCode, string> movementKeyMap = new Dictionary<KeyCode, string>() {
		{ KeyCode.W, "forward" },
		{ KeyCode.A, "left" },
		{ KeyCode.S, "back" },
		{ KeyCode.D, "right" }
	};

	public float speed = 5f;
	
	// Update is called once per frame
	void Update () {
		foreach (KeyCode key in this.movementKeyMap.Keys) {
			if (Input.GetKey(key)) this.move(this.movementKeyMap[key]);
		}
	}

	void move (string direction) {
		Vector3 translation;
		if (direction == "forward") translation = transform.forward;
		else if (direction == "left") translation = transform.right * -1f;
		else if (direction == "back") translation = transform.forward * -1f;
		else if (direction == "right") translation = transform.right;
		else return;
		transform.Translate(translation * this.speed * Time.deltaTime, Space.World); 
	}
}
