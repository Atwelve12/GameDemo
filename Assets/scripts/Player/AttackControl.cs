using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using UnityEngine.Events;
using UnityEngine.UI;

public class AttackControl : MonoBehaviour
{
    [Header("属性")]
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float currentHealth;

    [Header("无敌时间")]
    public bool invulnerable;
    public float invulnerableDuration;

    [Header("Player Gethit")]
    public Slider hpSlider;

    private Animation anim;

    public UnityEvent OnHurt;
    public UnityEvent OnDie;

    private void Start()
    {
        anim = GetComponent<Animation>();
        hpSlider.value = currentHealth / maxHealth;
    }
    protected virtual void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        if (invulnerable)
        {
            return;
        }
        if (currentHealth - damage > 0f)
        {
            currentHealth -= damage;
            StartCoroutine(nameof(InvulnerableCoroutine));//启动无敌状态的协程
            hpSlider.value = currentHealth / maxHealth;
            OnHurt?.Invoke();//这里用？可以防空
        }
        else
        {
            Die();
        }
    }

    public  virtual void Die()
    {
        currentHealth = 0f;
        hpSlider.value = 0;
        OnDie?.Invoke ();
    }

    //无敌
   protected virtual IEnumerator InvulnerableCoroutine ()
    {
        invulnerable = true;
        //等待无敌时间
        yield return new WaitForSeconds(invulnerableDuration);
        invulnerable = false;
    }
}
