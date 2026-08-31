using UnityEngine;

[CreateAssetMenu(fileName = "ApiSettings", menuName = "Game/Api Settings")]
public class ApiSettings : ScriptableObject
{
    public string baseUrl; // 在 Inspector 里填你的服务器地址
    private static ApiSettings instance;
    public static ApiSettings Instance
    {
        get {
            if (instance == null)
            {
                //优先加载真实配置
                instance = Resources.Load<ApiSettings>("ApiSettings");
                if (instance == null)
                {
                    //没有真实配置，加载示例模板
                    instance = Resources.Load<ApiSettings>("ApiSettingsExample");
                    Debug.LogWarning("未找到ApiSetting真实配置，已加载示例，请创建ApiSettings.asset填写真实服务器地址");
                }
            }
            return instance;
        }
    }
}