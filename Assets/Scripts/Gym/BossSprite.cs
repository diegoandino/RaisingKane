using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSprite : MonoBehaviour
{
    public SpriteRenderer boss;
    public Sprite bossIdle;
    public Sprite bossAttack;
    public bool once;

    // Start is called before the first frame update
    void Start()
    {
        boss.sprite = bossIdle;
        once = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.L) && !once)
        {
            once = true;
            StartCoroutine(ChangeSprite());
        }
    }

    private IEnumerator ChangeSprite()
    {
        boss.sprite = bossAttack;
        yield return new WaitForSeconds(35.77068f);
        boss.sprite = bossIdle;

    }
}

