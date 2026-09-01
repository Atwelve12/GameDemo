using UnityEngine;
public class ResourcePickup : MonoBehaviour
{
    //拾取物对应的资源ID，Inspector面板配置，默认1001
    public int resourceID = 1001;
    //拾取后获得的资源数量
    public int amount = 1;
    //背包系统
    public ResourceSystemHost resourceSystem;
    //资源管理器
    private ResourceManager manager;
    //2D触发器进入事件
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Player"))
        {  return; }
        manager = resourceSystem.Manager;
        Debug.Log("拾取资源ID：" + resourceID +"数量："+amount);
        manager.RequestAddResource(resourceID, amount, success =>
            {
                if (success)
                { Destroy(gameObject); Debug.Log("资源拾取成功"); }
                else { Debug.Log("资源拾取失败"); }
            });
        
    }
}
