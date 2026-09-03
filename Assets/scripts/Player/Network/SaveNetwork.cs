using System.Collections;
using System.Text;
using UnityEngine.Networking;
using UnityEngine;
public class SaveNetwork
{
    private ApiSettings apiSettings;
    public SaveNetwork(ApiSettings apiSettings)
    {  this.apiSettings = apiSettings;}
    public IEnumerator SaveGame(PlayerSaveData data)
    {
        string fullurl = apiSettings.baseUrl + "/save";
        string json=JsonUtility.ToJson(data);
        Debug.Log("发送保存数据："+json);
        UnityWebRequest request=new UnityWebRequest(fullurl,"POST");
        byte[] body = Encoding.UTF8.GetBytes(json);
        request.uploadHandler=new UploadHandlerRaw(body);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type","application/json");
        yield return request.SendWebRequest();
        if(request.result==UnityWebRequest.Result.Success)
        {
            Debug.Log("游戏保存成功：" + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("游戏保存失败：" + request.error);
        }
    }
    public IEnumerator LoadGame(System.Action<PlayerSaveData> onSuccess)
    {
        string fullurl = apiSettings.baseUrl + "/save";
        UnityWebRequest request=UnityWebRequest.Get(fullurl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;
            Debug.Log("服务器存档数据：" + json);
            PlayerSaveData data = JsonUtility.FromJson<PlayerSaveData>(json);
            if (data != null)
            {
                Debug.Log("服务器存档解析成功");
                onSuccess?.Invoke(data);
            }
            else
            {
                Debug.LogError("服务器存档解析失败");
            }
        }
        else
        {
            Debug.LogError("加载游戏失败："+request.error);
        }
    }
}
