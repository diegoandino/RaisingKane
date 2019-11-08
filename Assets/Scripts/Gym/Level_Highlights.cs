using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Highlights : MonoBehaviour


{
    public SpriteRenderer level;
    public Sprite level_reg;
    public Sprite level_highlighted;
    public bool mouseOver;

    // Start is called before the first frame update
    void Start()
    {
        level.sprite = level_reg;
    }

    private void Update()
    {
        
    }

    void OnMouseEnter()
    {
        level.sprite = level_highlighted;
        mouseOver = true;
        print("mouseover is true");
    }
    void OnMouseExit()
    {
        level.sprite = level_reg;
        mouseOver = false;
        print("mouseover is false");

    }
}
