#pragma warning disable CA1416
//忽略CA1416警告
using CombatRoutine;
using CombatRoutine.Setting;
using Common;
using Common.Define;
using Common.Helper;

namespace MRD.res;

public static class Helper
{
    public static CharacterAgent 自身 => Core.Me;
    // 获取当前自身Agent对象
    public static CharacterAgent 自身目标 => Core.Me.GetCurrTarget(); 
    // 获取当前自身的目标对象
    public static CharacterAgent 自身目标的目标 => Core.Me.GetCurrTargetsTarget(); 
    // 获取当前自身的目标对象的目标对象
    public static uint 自身血量 => Core.Me.CurrentHealth; 
    // 获取当前自身的血量
    public static uint 自身蓝量 => Core.Me.CurrentMana; 
    // 获取当前自身的蓝量
    public static float 自身血量百分比 => Core.Me.CurrentHealthPercent; 
    // 获取当前自身的血量百分比
    public static float 自身蓝量百分比 => Core.Me.CurrentManaPercent;
    //获取当前自身的蓝量百分比
    
    public static bool 自身存在Buff(uint id)
    {
        // 判断自身是否拥有指定id的Buff效果
        return Core.Me.HasAura(id);
    }
    
    public static bool 自身存在Buff大于时间(uint id,int time)
    {
        // 判断自身是buff是否大于指定时间
        return Core.Me.HasMyAuraWithTimeleft(id,time);
    }
    
    public static bool 技能可用(uint id)
    {   
        //检查蓝量与是否解锁以判断技能是否可用
        return Core.Get<IMemApiSpell>().IsReady(id);
    }
    
    /*
     public static bool 技能时间(Spell id,int time)
    {   
        //检查蓝量与是否解锁以判断技能是否可用
        return SpellHelper.CoolDownInGCDs(id,time);
    }
    */
    public static int 自身周围单位数量(int range)
    {
        //返回自身某距离内敌人数量
        return TargetHelper.GetNearbyEnemyCount(range);
    }
    
    public static int 兽魂()
    {   
        //返回兽魂量谱
        return Core.Get<IMemApiWarrior>().BeastGauge;
    }
    
    public static bool 目标在自身近战距离()
    {
        //目标在最大近战距离处则返回true
        return Core.Me.DistanceMelee(Core.Me.GetCurrTarget()) <
               SettingMgr.GetSetting<GeneralSettings>().AttackRange;
    }
    public static float 目标距离()
    {
        //目标在最大近战距离处则返回true
        return Core.Me.DistanceMelee(Core.Me.GetCurrTarget());
    }
    
    public static uint 上一个连击技能()
    {
        //返回上一个连击技能
        return Core.Get<IMemApiSpell>().GetLastComboSpellId();
    }
    
    public static int Gcd剩余时间()
    {
        //返回GCD剩余时间
        return AI.Instance.GetGCDCooldown();
    }
    
    /// <summary>
    /// 判断指定的技能是否最近刚刚使用过。
    /// </summary>
    /// <param name="spellId">技能的唯一标识符。</param>
    /// <param name="time">检查的时间范围，单位为毫秒，默认为1200毫秒。</param>
    /// <returns>如果技能最近刚刚使用过，则返回true；否则返回false。</returns>
    public static bool 技能刚使用过(this uint spellId, int time = 1200)
    {
        return spellId.GetSpell().RecentlyUsed(time);
    }
    
    public static float 充能层数(this uint spellId)
    {
        // 调用Get<IMemApiSpell>()获取IMemApiSpell接口实例，并使用GetCharges()方法获取指定spellId的充能层数
        return Core.Get<IMemApiSpell>().GetCharges(spellId);
    }

    
    public static Spell 获取技能(this uint id)
    {
        return id.GetSpell();
        

    }
}