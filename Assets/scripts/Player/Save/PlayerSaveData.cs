using System;
using System.Collections.Generic;
[Serializable]
public class PlayerSaveData
{
    //背包资源
    public List<ResourceData> resources;
    //玩家位置
    public PlayerPosition playerPosition;
}
[Serializable]
public class PlayerPosition
{
    public float x;
    public float y;
}