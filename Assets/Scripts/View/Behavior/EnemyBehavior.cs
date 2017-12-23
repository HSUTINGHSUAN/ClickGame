﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(Animator))]//attribute//強制限制這個class一定要掛Animator才能使用
[RequireComponent(typeof(MeshFader))]
[RequireComponent(typeof(AudioSource))]
public class EnemyBehavior : MonoBehaviour {
    private Animator animator;//指標
    private MeshFader meshFader;
    private AudioSource audioSource;
    private HealthComponent healthComponent;
    public AudioClip hurtClip;
    private void Awake()
    {
        animator = GetComponent<Animator>();//抓物件
        meshFader = GetComponent<MeshFader>();
        audioSource = GetComponent<AudioSource>();
        healthComponent = GetComponent<HealthComponent>();
    }

    private void OnEnable()
    {
        StartCoroutine(meshFader.FadeIn());
        healthComponent.Init(100);
    }

    public void DoDamage(int attack)
    {
        animator.SetTrigger("hurt");
        audioSource.clip = hurtClip;
        audioSource.Play();
        healthComponent.Hurt(attack);
    }
    private void Update()
    {
        if (healthComponent.IsOver)
            return;
        if (Input.GetButtonDown("Fire1"))
        {
            DoDamage(10);

        }
    }
}
