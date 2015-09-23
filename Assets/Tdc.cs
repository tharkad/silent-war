using UnityEngine;
using System.Collections;

public class Tdc : MonoBehaviour {

	public Sprite[] textures;

	// Use this for initialization
	void Start () {
		if (this.name == "tdc-a1")
			Grid.tdcs [0, 0] = this;
		else if (this.name == "tdc-a2")
			Grid.tdcs [0, 1] = this;
		else if (this.name == "tdc-a3")
			Grid.tdcs [0, 2] = this;
		else if (this.name == "tdc-a4")
			Grid.tdcs [0, 3] = this;
		else if (this.name == "tdc-b1")
			Grid.tdcs [1, 0] = this;
		else if (this.name == "tdc-b2")
			Grid.tdcs [1,1] = this;
		else if (this.name == "tdc-b3")
			Grid.tdcs [1,2] = this;
		else if (this.name == "tdc-b4")
			Grid.tdcs [1,3] = this;

//		Grid.LoadTdcTargets ();
		loadTexture ();
	}
	
	public void loadTexture() {
		GetComponent<SpriteRenderer> ().sprite = textures[Grid.tdcCurrentTexture (this)];
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (1)) {
			GetComponent<SpriteRenderer> ().sprite = textures[Grid.tdcFlippedTexture (this)];
		}
	}
}
