using UnityEngine;
using System.Collections;

public class SpellWhieel : MonoBehaviour {
	public float turnSpeed = 50f;
	public bool spinClockwise = true;

	private float rotationSinceStart = 0f;
	private GameObject[] textObjects;

	void Start () {
		this.textObjects = getTextObjects();	
		string[] spellNames = new string[] {"dark", "fire", "aqua", "gaia", "lux", "luna", "sola", "tera"};
		for (int i = 0; i < this.textObjects.Length; i++) {
			this.textObjects[i].GetComponent<TextMesh>().text = spellNames[i];	
		}
	}

	void Update () {
		rotateWheel();
		GameObject textObject = getFocusedTextObject();
		textObject.GetComponent<TextMesh>().color = Color.red;
	}

	/******************************************************/

	GameObject getFocusedTextObject() {
		int widthOfFocus = 360 / 8;
		int indexOfFocus = ((int)this.rotationSinceStart / widthOfFocus) % 8;
		if (spinClockwise) {
			return this.textObjects[7 - indexOfFocus];
		} else {
			return this.textObjects[indexOfFocus];
		}
	}
	

	GameObject[] getTextObjects() {
		GameObject[] spellTextObjects = new GameObject[8];	
		for (int i = 0; i < spellTextObjects.Length; i++) {
			spellTextObjects[i] = this.transform.Find("text" + i.ToString()).gameObject;
		}
		return spellTextObjects;
	}

	void rotateWheel() {
		float direction = 1;
		if (!spinClockwise) {
			direction = -1;	
		}
		float rotationAmount = direction * turnSpeed * Time.deltaTime;
		this.transform.Rotate(Vector3.up, rotationAmount);
		this.rotationSinceStart += rotationAmount;
	}
}
