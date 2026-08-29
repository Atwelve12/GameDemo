using UnityEngine;
public class ResourceSystemHost : MonoBehaviour
{
    // 资源配置数据库
    public ResourceDatabase database;
    // 后端地址配置
    public ApiSettings apiSettings;
    //资源网络模块
    public ResourceNetwork Network
    {  get; private set; }
    // 资源管理
    public ResourceManager Manager
    {get;private set;}
    private void Awake()
    {
        //创建网络模块
        Network = new ResourceNetwork(apiSettings);
        // 创建资源管理器
        Manager = new ResourceManager(
            database,
            AddResourceToServer
        );      
        Debug.Log("ResourceSystem初始化完成");
    }
    private void Start()
    {
        //启动服务器资源加载
        StartCoroutine(Network.GetResource(Manager));
    }
    public void AddResourceToServer(ResourseData resourse)
    {
        StartCoroutine(Network.SendResource(resourse));
    }
}
