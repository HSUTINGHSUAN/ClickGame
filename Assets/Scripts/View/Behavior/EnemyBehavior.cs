using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]//attribute//強制限制這個class一定要掛Animator才能使用

public class EnemyBehavior : MonoBehaviour {
    private Animator animator;//指標

    private void Awake()
    {
        animator = GetComponent<Animator>();//抓物件
        //animator.SetTrigger("die");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
