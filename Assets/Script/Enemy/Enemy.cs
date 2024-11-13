using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private static readonly int IsHit = Animator.StringToHash("IsHit");

    private Coroutine coroutine;
    private float maxHP;
    private float HP;
    private bool isHit = false;

    public EnemySO enemySO;
    public Animator animator;
    public Image hpImage;
    public float animationChangeTime;

    private void Awake()
    {
        maxHP = enemySO.maxHP;
        HP = maxHP;
        GameManager.Instance.PlayerController.enemy = this;
    }

    public void ChangeHealth(float power)
    {
        HP = Mathf.Max(0f, HP - power);
        if (HP == 0f) Die();

        ChangeHealthUI();
        Hit();
    }

    private void ChangeHealthUI()
    {
        hpImage.fillAmount = HP / maxHP;
    }

    private void Hit()
    {
        animator.SetBool(IsHit, true);
        isHit = true;
        
        if (coroutine != null) StopCoroutine(coroutine);
        StartCoroutine(ChangeIdleAnimCoroutine());
    }

    private void ChangeIdleAnimation()
    {
        animator.SetBool(IsHit, false);
        isHit = false;
    }

    private IEnumerator ChangeIdleAnimCoroutine()
    {
        yield return new WaitForSeconds(animationChangeTime);
        ChangeIdleAnimation();
    }

    private void Die()
    {
        GameManager.Instance.PlayerController.enemyGenerator.Generate();
        UIMAnager uiManager = GameManager.Instance.PlayerController.uiManager;
        uiManager.UpdateGold(Random.Range(enemySO.minGold, enemySO.maxGold));
        uiManager.UpdateStage();
    }
}