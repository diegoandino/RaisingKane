using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimation : MonoBehaviour
{
    [SerializeField] private Animator MonsterAnimateController;
    public BeatGenerator bg;

    // Start is called before the first frame update
    void Start()
    {
        MonsterAnimateController.SetBool("playAttack", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!bg.start)
        {
            MonsterAnimateController.SetBool("playAttack", true);
        }
    }
}