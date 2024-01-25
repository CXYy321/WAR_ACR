#pragma warning disable CA1416
//忽略CA1416警告
using CombatRoutine;
using CombatRoutine.Opener;
using CombatRoutine.View.JobView;
using Common;
using Common.Define;
using Common.Language;
using MRD.GCD;
using MRD.setting;
using MRD.能力技;

namespace MRD;

public class WarriorRotationEntry : IRotationEntry
{
    public void DrawOverlay() //不知道干嘛用的，照抄，猜是ui相关
    {
    }
    public static JobViewWindow JobViewWindow;//界面UI相关的，复制照抄
    private AcrUi _lazyOverlay = new AcrUi();
    
    /// <summary>
    /// 获取或设置作者名称
    /// </summary>
    public string AuthorName { get; } = "CXY";

    /// <summary>
    /// 获取或设置目标职业
    /// </summary>
    public Jobs TargetJob { get; } = Jobs.Marauder;

    /// <summary>
    /// 获取或设置Acr类型
    /// </summary>
    public AcrType AcrType { get; } = AcrType.Normal;

    /// <summary>
    /// 获取或设置最小等级
    /// </summary>
    public int MinLevel { get; } = 1;

    /// <summary>
    /// 获取或设置最大等级
    /// </summary>
    public int MaxLevel { get; } = 50;

    /// <summary>
    /// 获取或设置描述
    /// </summary>
    public string Description { get; } = "严重警告！！！此ACR只能用来打日随，用这玩意打高难算你牛逼";

    /// <summary>
    /// 获取或设置覆盖标题
    /// </summary>
    public string OverlayTitle { get; } = "CXY的斧术师测试";
    


    public List<ISlotResolver> SlotResolvers = new() //你ACR的逻辑部分，从上到下是使用技能的优先级
    {
       new Aoe二连(),
       new 基础三连(),
       new 飞斧(),
       
       new 狂暴1(),
       new 狂暴2(),
        
        
        new 守护(),
        new 死斗(),
        new 复仇(),
        new 血仇(),
        new 铁壁(),
        new 战栗(),
        
        
    };


    public Rotation Build(string settingFolder) // 将其他文件引入主文件
    {
        MRD设置.Build(settingFolder);
        return new Rotation(this, () => SlotResolvers) //照抄
            .SetRotationEventHandler(new MRD事件处理()) //照抄，“.SetRotationEventHandler(new WARRotationEventHandler())”括号里的“new WARRotationEventHandler()”填写你自己的
            .AddSettingUIs(new AeUi()) //UI设置相关，照抄，括号里 的“new TankWARSettingView()”填写你自己的
            .AddSlotSequences(); //照抄
    }
    //rotation
    
    public bool BuildQt(out JobViewWindow jobViewWindow)//设置QT界面
    {
        //QT设置栏
        jobViewWindow = new JobViewWindow(MRD设置.Instance.JobViewSave, MRD设置.Instance.Save, OverlayTitle);
        JobViewWindow = jobViewWindow; // 这里设置一个静态变量.方便其他地方用，照抄
        jobViewWindow.AddTab("日志", _lazyOverlay.Draw日志);//QT里显示的通用那栏，照抄
        jobViewWindow.AddTab("通用", _lazyOverlay.DrawGeneral);//QT里显示的通用那栏，照抄
        jobViewWindow.AddTab("减伤设置", _lazyOverlay.Draw减伤);//QT里显示的通用那栏，照抄
        jobViewWindow.AddTab("时间轴", _lazyOverlay.DrawTimeLine);//QT里显示的时间轴那栏，照抄
        jobViewWindow.AddTab("DEV", _lazyOverlay.DrawDev);//QT里显示的DEV那栏，照抄
        //QT开关设置
        jobViewWindow.AddQt("AOE", true);
 
        jobViewWindow.AddQt("自动盾姿", true);
        jobViewWindow.AddQt("飞斧", true);
        return true;
    }
    public void OnLanguageChanged(LanguageType languageType)//切换语言相关，不懂就照抄
    {
    }
}