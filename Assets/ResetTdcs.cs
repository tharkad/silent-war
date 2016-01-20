using UnityEngine;
using System.Collections;

public class ResetTdcs : MonoBehaviour
{
    public bool on = false;
    public Sprite[] textures;

    // Use this for initialization
    void Start()
    {
        Grid.resetTdcsButton = this;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<SpriteRenderer>().sprite == textures[1])
            {
                GetComponent<SpriteRenderer>().sprite = textures[0];
                Grid.resetTdcs();
            }
        }
    }
}
