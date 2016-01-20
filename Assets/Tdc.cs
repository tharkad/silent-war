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
            Grid.tdcs[0, 3] = this;
        else if (this.name == "tdc-a5")
            Grid.tdcs[0, 4] = this;
        else if (this.name == "tdc-a6")
            Grid.tdcs[0, 5] = this;

        else if (this.name == "tdc-b1")
            Grid.tdcs[1, 0] = this;
        else if (this.name == "tdc-b2")
            Grid.tdcs[1, 1] = this;
        else if (this.name == "tdc-b3")
            Grid.tdcs[1, 2] = this;
        else if (this.name == "tdc-b4")
            Grid.tdcs[1, 3] = this;
        else if (this.name == "tdc-b5")
            Grid.tdcs[1, 4] = this;

        else if (this.name == "tdc-c1")
            Grid.tdcs[2, 0] = this;
        else if (this.name == "tdc-c2")
            Grid.tdcs[2, 1] = this;
        else if (this.name == "tdc-c3")
            Grid.tdcs[2, 2] = this;
        else if (this.name == "tdc-c4")
            Grid.tdcs[2, 3] = this;
        else if (this.name == "tdc-c5")
            Grid.tdcs[2, 4] = this;

        if (this.name == "tdc-d1")
            Grid.tdcs[3, 0] = this;
        else if (this.name == "tdc-d2")
            Grid.tdcs[3, 1] = this;
        else if (this.name == "tdc-d3")
            Grid.tdcs[3, 2] = this;
        else if (this.name == "tdc-d4")
            Grid.tdcs[3, 3] = this;
        else if (this.name == "tdc-d5")
            Grid.tdcs[3, 4] = this;
        else if (this.name == "tdc-d6")
            Grid.tdcs[3, 5] = this;

        //		Grid.LoadTdcTargets ();
        loadTexture();
	}
	
	public void loadTexture() {
		GetComponent<SpriteRenderer> ().sprite = textures[Grid.tdcCurrentTexture (this)];
	}

	void OnMouseOver() {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<SpriteRenderer>().sprite = textures[Grid.tdcShowTexture(this)];
        }
        else if (Input.GetMouseButtonDown(1))
        {
            GetComponent<SpriteRenderer>().sprite = textures[Grid.tdcFlippedTexture(this)];
        }
    }
}
