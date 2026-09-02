using UnityEngine;
public class Enemy_ThrowRock : EnemyBase
{
    [Header("Enemy 投掷石头")]
    public GameObject RockPerfab;
    public float AttackForce = 3f;


    public override void AddAttackBox()
    {
        ThrowRock();
    }

    public void ThrowRock()
    {
        GameObject go;
        ThrowableRock rock;
        Vector2 direction;
        if (isRight)
        {
            go = Instantiate(RockPerfab,AttackPoint1.position,Quaternion.identity,transform);
            go.transform.localScale = AttackPoint1.localScale;
            rock = go.GetComponent<ThrowableRock>();
            if (rock != null)
            {
                rock.damage = AttackDamage;
                direction = (player.transform.position - AttackPoint1.position).normalized;
                direction.y *= 0f;
                direction.Normalize();
                rock.Throw(direction, AttackForce);
            }
            
        }
        else
        {
            go = Instantiate(RockPerfab,AttackPoint2.position,Quaternion.identity,transform);
            go.transform.localScale = AttackPoint2.localScale;
            rock = go.GetComponent<ThrowableRock>();
            if (rock != null)
            {
                rock.damage = AttackDamage;
                direction = (player.transform.position - AttackPoint2.position).normalized;
                direction.y *= 0f;
                direction.Normalize();
                rock.Throw(direction, AttackForce);
            }
           
        }
    }
}
