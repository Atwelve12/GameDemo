using UnityEngine;

public class ThrowableRock : MonoBehaviour
{
    public float damage;        // 造成的伤害
    public float lifetime = 5f;       // 自动销毁时间
    private Rigidbody2D rb;         // 2D 刚体

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // 由敌人调用，设置初速度
   public void Throw(Vector2 direction, float force)
{
    if (rb != null)
        rb.velocity = direction.normalized * force;
}

    void Start()
    {
        Destroy(gameObject, lifetime); // 自动销毁，防止场景堆积
    }

    // 可选：碰撞检测造成伤害
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject); // 碰到玩家后销毁石头
            AttackControl player = collision.GetComponent<AttackControl>();
            player.TakeDamage(damage);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }


}