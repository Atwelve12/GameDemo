using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackControl : AttackControl 
{
    [Header("近战攻击")]
    public Vector2 attackSize = new Vector2(1f, 1f);//攻击范围
    private Vector2 AttackAreaPos;
    public float offsetX = 1f;
    public float offsetY = 1f;

   void MeleeAttackAnimEvent(float isAttack)
   {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(AttackAreaPos ,attackSize ,0f);//中心点，半径，旋转
    }

    //绘图用于测试
    private void OnDrawGizmosSelected()
    {
        AttackAreaPos = transform.position;

        AttackAreaPos.x += offsetX;
        AttackAreaPos.y += offsetY;

        Gizmos.color = Color.yellow ;
        Gizmos.DrawWireCube(AttackAreaPos ,attackSize);
    }
}
