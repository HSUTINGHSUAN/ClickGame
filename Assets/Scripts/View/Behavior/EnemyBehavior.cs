using System.Collections;
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
    [SerializeField]
    public AudioClip hurtClip;
    [SerializeField]
    public AudioClip deadClip;
    public EnemyData enemyData;

    public bool IsDead
    {
        get
        {
            return healthComponent.IsOver;//死的方式要改從這裡
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();//抓物件
        meshFader = GetComponent<MeshFader>();
        audioSource = GetComponent<AudioSource>();
        healthComponent = GetComponent<HealthComponent>();
        //GameFacade.GetInstance();--測試用
    }

    private void OnEnable()
    {
        StartCoroutine(meshFader.FadeIn());
    }

    [ContextMenu("Test Execute")]
    private void TestExecute()
    {
        StartCoroutine(Execute(enemyData));
    }
    public IEnumerator Execute(EnemyData enemyData)
    {
        healthComponent.Init(enemyData.health);
        while (IsDead == false)
        {
            yield return null;
        }

        animator.SetTrigger("die");
        audioSource.clip = deadClip;
        audioSource.Play();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        yield return StartCoroutine(meshFader.FadeOut());
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
