using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {
	
	public Sprite[] backTextures;
	public Sprite[] frontTextures;
	public bool front = false;
    public float catchTime = 0.25f;
    private float timeLastClicked;
	
	// Use this for initialization
	void Start () {
		if (this.name == "target-a1")
			Grid.targets [0, 0] = this;
		else if (this.name == "target-a2")
			Grid.targets [0, 1] = this;
		else if (this.name == "target-a3")
			Grid.targets [0, 2] = this;
		else if (this.name == "target-a4")
			Grid.targets [0, 3] = this;
		else if (this.name == "target-a5")
			Grid.targets [0, 4] = this;
		else if (this.name == "target-a6")
			Grid.targets [0, 5] = this;

		else if (this.name == "target-b1")
			Grid.targets [1, 0] = this;
		else if (this.name == "target-b2")
			Grid.targets [1,1] = this;
		else if (this.name == "target-b3")
			Grid.targets [1,2] = this;
		else if (this.name == "target-b4")
			Grid.targets [1,3] = this;
		else if (this.name == "target-b5")
			Grid.targets [1,4] = this;
		
		else if (this.name == "target-c1")
			Grid.targets [2, 0] = this;
		else if (this.name == "target-c2")
			Grid.targets [2,1] = this;
		else if (this.name == "target-c3")
			Grid.targets [2,2] = this;
		else if (this.name == "target-c4")
			Grid.targets [2,3] = this;
		else if (this.name == "target-c5")
			Grid.targets [2,4] = this;
		
		else if (this.name == "target-d1")
			Grid.targets [3, 0] = this;
		else if (this.name == "target-d2")
			Grid.targets [3, 1] = this;
		else if (this.name == "target-d3")
			Grid.targets [3, 2] = this;
		else if (this.name == "target-d4")
			Grid.targets [3, 3] = this;
		else if (this.name == "target-d5")
			Grid.targets [3, 4] = this;
		else if (this.name == "target-d6")
			Grid.targets [3, 5] = this;

		Grid.resetBoard ();
//		Grid.LoadTdcTargets ();
		loadTexture ();
	}
	
	public void loadTexture() {
		if (front)
			GetComponent<SpriteRenderer> ().sprite = frontTextures[Grid.targetCurrentTexture (this)];
		else
			GetComponent<SpriteRenderer> ().sprite = backTextures[Grid.targetCurrentTexture (this)];
	}
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (1)) {
			front = !front;
			if (front)
				GetComponent<SpriteRenderer> ().sprite = frontTextures[Grid.targetCurrentTexture (this)];
			else
				GetComponent<SpriteRenderer> ().sprite = backTextures[Grid.targetCurrentTexture (this)];

		}
        else if (Input.GetMouseButtonDown (0))
        {
            if (Time.time - timeLastClicked < catchTime)
            {
                Grid.replaceTarget(this);
            }
            timeLastClicked = Time.time;
        }
	}
}