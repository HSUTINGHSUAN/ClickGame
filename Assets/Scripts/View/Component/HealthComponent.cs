using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour {
    [SerializeField]//private Slider healthSlider就算是私有的也讓其他人能夠拖曳使用
    private Slider healthSlider;
    private int currentHealth;
    //-------封裝性↑
    [SerializeField]
    private float speed = 5f;


    public bool IsOver
    {
        get
        {
            return currentHealth <= healthSlider.minValue;
        }
    }

    [ContextMenu("Test Init 100")]
    private void TestInit()
    {
        Init(100);
    }
    [ContextMenu("Test Hurt 50")]
    private void TestHurt()
    {
        Hurt(50);
    }

    public void Init(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        currentHealth = maxHealth;
    }
    public void Hurt(int damage)
    {
        currentHealth -= damage;
        currentHealth = (int)Mathf.Max(currentHealth, healthSlider.minValue);//會回傳最大值
    }

    private void Update()
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value, currentHealth, Time.deltaTime * speed);
    }

}
