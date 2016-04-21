using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour {

	const float MAXDISTANCE = 30f;
	public float speed = 8f;
	float distance = 0f;

	public void setup(Vector3 start, Vector3 direction) {
		transform.position = start;
		transform.forward = direction;
	}
	
	// Update is called once per frame
	void Update () {
		this.move();
		this.checkLimit();
	}

	void OnCollisionEnter (Collision collision) {
		Debug.Log(collision);
		if (collision.gameObject.GetComponent<TargetController>() != null) {
			Destroy(GetComponent<Collider>().gameObject);
			Destroy(gameObject);
		}
	}

	void move () {
		transform.Translate(transform.forward * this.speed * Time.deltaTime, Space.World);
		distance += this.speed * Time.deltaTime;
	}

	void checkLimit () {
		if (distance > FireballController.MAXDISTANCE) Destroy(gameObject);
	}
}
