using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeControl : MonoBehaviour
{
    static int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //死亡
        //Todo
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //加分
        score++;
        Debug.Log(score);
    }

    //重制高度
    public void ResetHeight()
    {
        Vector2 v = transform.localPosition;
        v.y = Random .Range (0.5f, 2.5f);
        transform .localPosition = v;
    }
}
