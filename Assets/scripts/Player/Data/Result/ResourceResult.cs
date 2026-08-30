using System;
[Serializable]
public class ResourceResult
{
    //是否成功
    public bool success;
    //状态码
    public int code;
   //提示信息
   public string message;
    public ResourceResult(bool success, int code, string message)
    {
        this.success = success;
        this.code = code;
        this.message = message;
    }
}