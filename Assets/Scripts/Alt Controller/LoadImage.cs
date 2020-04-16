using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadImage : MonoBehaviour
{
    public SpriteRenderer test;
    public Sprite original;
    public Sprite replacement;

    public void Start()
    {
        test.sprite = original;
    }

    public void replace()
    {
        test.sprite = replacement;
    }

}
