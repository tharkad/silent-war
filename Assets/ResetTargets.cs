using UnityEngine;
using System.Collections;

public class ResetTargets : MonoBehaviour {
    public bool on = false;
    public Sprite[] textures;

    // Use this for initialization
    void Start()
    {
        Grid.resetTargetsButton = this;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Grid.targetsRolled)
            {
                GetComponent<SpriteRenderer>().sprite = textures[0];
                Grid.resetTargets();
            }
        }
    }
}
