
using UnityEngine;

public class EnemyAttackBox : MonoBehaviour
{
    public float damage = 10f;
    public float destriyTime = 0.5f;

    void Start()
    {
        Destroy(gameObject, destriyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_HP player = collision.GetComponent<Player_HP>();
            player.GetHit(damage);
        }
    }
}
