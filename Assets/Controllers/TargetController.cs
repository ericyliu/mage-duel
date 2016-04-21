using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		Debug.Log(collision);
	}
}
