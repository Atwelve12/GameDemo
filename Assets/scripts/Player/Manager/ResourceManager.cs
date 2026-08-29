using System.Collections.Generic;
using UnityEngine;
public class ResourceManager
{   //玩家拥有的资源
    public List<ResourseData> resourses = new List<ResourseData>();
    public int maxSlot = 10;
    //资源数据库：存放所有资源静态配置
    public ResourceDatabase database;
    //服务器通信：负责客户端和服务端资源数据同步
    public ResourceNetwork network;
    public bool IsInitialized { get; private set;  }
    private System.Action<ResourseData> syncToServer;
    //构造函数
    public ResourceManager(ResourceDatabase database, System.Action<ResourseData> syncToServer)
    {
        this.database = database;
        this.syncToServer = syncToServer;
    }
    //判断背包是否满
    public bool IsFull()
    {
        return resourses.Count >= maxSlot;
    }
    //增加资源
    public void AddResource(int id, int count)
    {
        Debug.Log(
            "AddResource调用 id:"
            + id
            + " count:"
            + count
        );
        //在背包列表中查找已有该ID资源
        ResourseData resource = resourses.Find(
            r => r.id == id
        );
        //背包里没有则新建一条资源数据
        if (resource == null)
        {
            Debug.Log("没有找到资源，创建新资源");
            resource = new ResourseData();
            resource.id = id;
            // 从数据库读取资源名称
            ResourceConfig config = database.GetResource(id);
            if (config != null)
            {
                resource.name = config.itemName;
            }
            else
            {
                resource.name = "未知资源";
            }
            resource.count = 0;
            resourses.Add(resource);
        }
        //增加数量
        resource.count += count;
        //向服务器同步本次新增资源
        if (network != null)
        {
            ResourseData data = new ResourseData();
            data.id = resource.id;
            data.name = resource.name;
            data.count = count;
            syncToServer?.Invoke(data);
        }
    }
    //减少资源，返回bool代表操作是否成功
    public bool RemoveResource(int id, int count)
    {
        ResourseData resourse = resourses.Find(r => r.id == id);
        //背包不存在该资源
        if (resourse == null)
        { return false; }
        //当前数量不足
        if (resourse.count < count)
        {
            return false;
        }
        //校验全部通过
        resourse.count -= count;
        Debug.Log(
            resourse.name
            +
            "-"
            +
            count
        );
        //同步服务器

        return true;
    }
    //查询指定ID资源当前数量
    public int GetResourceCount(int id)
    {
        ResourseData resourse = resourses.Find(
            r => r.id == id);
        if (resourse != null)
        {
            return resourse.count;
        }
        //找不到资源默认返回0
        return 0;
    }
    //判断资源是否够用
    public bool HasEnough(int id, int needCount)
    {
        return GetResourceCount(id) >= needCount;
    }
    //读取背包内全部资源
    public List<ResourseData> GetAllResource()
    {
        return resourses;
    }
    //从服务器加载资源，覆盖本地背包
    public void LoadFromServer(List<ResourseData> serverResources)
    {
        resourses = serverResources;
        IsInitialized = true;
        Debug.Log("服务器资源加载完成");
        //根据数据库刷新资源名称
        foreach (ResourseData resource in resourses)
        {
            ResourceConfig config =
                database.GetResource(resource.id);
            if (config != null)
            {
                resource.name = config.itemName;
            }
        }
    }
    
}