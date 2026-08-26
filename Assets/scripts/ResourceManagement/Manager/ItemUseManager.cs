using UnityEngine;
public class ItemUseManager : MonoBehaviour
{
    public ResourseManager resourceManager;
    // 疗愈草药ID
    public int healHerbID = 1002;
    // 每次恢复的血量
    public int healAmount = 10;
    public void UseItem(int id)
    {
        if (id == healHerbID)
        {
            UseHealHerb();
        }
    }
    private void UseHealHerb()
    {
        if (!resourceManager.HasEnough(healHerbID, 1))
        {
            Debug.Log("没有疗愈草药");
            return;
        }
        bool success = resourceManager.RemoveResource(healHerbID, 1);
        if (!success)
        {
            return;
        }
        Debug.Log("使用疗愈草药，恢复 " + healAmount + " HP");
        // 下一步在这里接玩家血量
    }
}

