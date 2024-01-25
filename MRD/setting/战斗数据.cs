namespace MRD.setting;

public class 战斗数据
{
    public static 战斗数据 Instance = new();

    public void Reset()
    {
        Instance = new 战斗数据();  
        
    } //重置
    
}