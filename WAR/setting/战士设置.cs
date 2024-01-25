#pragma warning disable CA1416
#pragma warning disable CS8604
//忽略CA1416警告
using System.Numerics;
using CombatRoutine.View.JobView;
using Common.Helper;
using Common.Language;


namespace WAR.setting;

public class 战士设置
{
    public static 战士设置 Instance;
    private static string path;
    public int 红斩时间 = 14000;

    public int Time = 100;
    public bool 多变精神镖 = true;
    public bool 摆烂战士 = false;
    public int  猛攻层数 =0;
    public int 飞斧距离 = 7;
    
    public bool 自动铁壁 = true;
    public bool 自动复仇 = true;
    public bool 自动血仇 = true;
    public bool 自动摆脱 = true;
    public bool 自动泰然 = true;
    public bool 自动战栗 = true;
    public bool 自动死斗 = true;
    public bool 自动血气 = true;
    
    public float 铁壁阈值 = 0.80f;
    public float 复仇阈值 = 0.70f;
    public float 血仇阈值 = 0.75f;
    public float 摆脱阈值 = 0.80f;
    public float 泰然阈值 = 0.50f;
    public float 战栗阈值 = 0.50f;
    public float 死斗阈值 = 0.10f;  
    public float 血气阈值 = 0.75f;
    
    
    
    public Dictionary<string, object> StyleSetting = new(); //创建了一个名为StyleSetting的字典变量
    //定义一些变量

    public JobViewSave
        JobViewSave = new() { MainColor = new Vector4(24 / 255f, 91 / 255f, 135 / 255f, 0.8f) }; //设置QT界面的颜色

    public void Save() 
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path));
        File.WriteAllText(path, JsonHelper.ToJson(this));
    }

    public static void Build(string settingPath)
    {
        path = Path.Combine(settingPath, "战士设置.json");
        if (!File.Exists(path))
        {
            Instance = new 战士设置();
            Instance.Save();
            return; //照抄
        }


        try //照抄
        {
            Instance = JsonHelper.FromJson<战士设置>(File.ReadAllText(path)); 
        }
        catch (Exception e) //照抄
        {
            Instance = new 战士设置(); 
            LogHelper.Error(e.ToString()); 
        }
    }
}