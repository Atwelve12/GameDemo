using UnityEngine;

public class Player_HP : MonoBehaviour
{
 public float GetHit(float damage)
    {
        Debug.Log("Player hit! Damage: " + damage);
        return damage;
    }
}