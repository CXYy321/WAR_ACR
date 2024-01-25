#pragma warning disable CA1416
#pragma warning disable CS8604
//忽略CA1416警告
using System.Numerics;
using CombatRoutine.View.JobView;
using Common.Helper;
using Common.Language;


namespace MRD.setting;

public class MRD设置
{
    public static MRD设置 Instance;
    private static string path;
    

    
    public bool 自动铁壁 = true;
    public bool 自动复仇 = true;
    public bool 自动血仇 = true;
    public bool 自动战栗 = true;
    public bool 自动死斗 = true;

    
    public float 铁壁阈值 = 0.80f;
    public float 复仇阈值 = 0.70f;
    public float 血仇阈值 = 0.75f;

    public float 战栗阈值 = 0.50f;
    public float 死斗阈值 = 0.10f;  
    public int 飞斧距离 = 7;
   
    
    
    public Dictionary<string, object> StyleSetting = new(); //创建了一个名为StyleSetting的字典变量
    //定义一些变量

    public JobViewSave
        JobViewSave = new() { MainColor = new Vector4(24 / 255f, 91 / 255f, 135 / 255f, 0.8f) }; //设置QT界面的颜色

    public void Save() //照抄
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path));
        File.WriteAllText(path, JsonHelper.ToJson(this));
    }

    public static void Build(string settingPath)
    {
        path = Path.Combine(settingPath, "MDR设置.json");
        if (!File.Exists(path))
        {
            Instance = new MRD设置();
            Instance.Save();
            return; //照抄
        }


        try //照抄
        {
            Instance = JsonHelper.FromJson<MRD设置>(File.ReadAllText(path)); //照抄，“WARSettings”保持和class一致
        }
        catch (Exception e) //照抄
        {
            Instance = new MRD设置(); //照抄，“WARSettings”保持和class一致
            LogHelper.Error(e.ToString()); //照抄
        }
    }
}