using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellWheel : MonoBehaviour {
	public float turnSpeed = 50f;
	public bool spinClockwise = true;

	private float rotationSinceStart = 0f;
	private List<SpellWheelText> spellTextObjects;
	private bool isActive = false;

	public void setActiveState(bool isActive) {
		this.isActive = isActive;
	}

	void Start () {
		this.instantiateTextObjects();

		string[] spellNames = new string[] {"dark", "fire", "aqua", "gaia", "lux", "luna", "sola", "tera"};
		for (int i = 0; i < this.spellTextObjects.Count; i++) {
			this.spellTextObjects[i].setSpellText(spellNames[i]);
		}
	}

	void Update () {
		rotateWheel();
		// reset all text
		foreach (SpellWheelText spellText in this.spellTextObjects) {
			spellText.setHighlighted(false);
		}

		if (this.isActive) {
			getFocusedTextObject().setHighlighted(true);
		}
	}

	/******************************************************/

	SpellWheelText getFocusedTextObject() {
		int widthOfFocus = 360 / 8;
		int offset = 30;
		int indexOfFocus = (((int)this.rotationSinceStart - offset) / widthOfFocus) % 8;
		if (spinClockwise) {
			return this.spellTextObjects[7 - indexOfFocus];
		} else {
			return this.spellTextObjects[indexOfFocus];
		}
	}
	
	void instantiateTextObjects() {
		this.spellTextObjects = new List<SpellWheelText>();
		for (int i = 0; i < 8; i++) {
			this.spellTextObjects.Add(new SpellWheelText(this.transform.Find("text" + i.ToString()).gameObject));
		}
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
