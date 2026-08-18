using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    //向上的力
    public float Force = 3;
    //最大角度
    public float MaxAngle = 40;

    //刚体
    private Rigidbody2D rdbody;
    // Start is called before the first frame update
    void Start()
    {
        rdbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //点击鼠标给小鸟力
    if (Input.GetMouseButtonDown(0))
        {
            rdbody.velocity = new Vector2(0, Force);
        }
        //获取当前角度
        Vector3 angle = transform.eulerAngles;
        //旋转
        angle.z += rdbody.velocity.y;
        //将z旋转同步面板上的数值
        angle.z = angle.z - 180;
        if (angle.z > 0)
        {
            angle.z -= 180;
        }
        else
        {
            angle.z += 180;
        }
        //限制角度
        angle.z = Mathf.Clamp(angle.z, -MaxAngle, MaxAngle);
        transform.eulerAngles = angle;
    }
}
