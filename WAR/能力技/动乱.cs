using CombatRoutine;
using Common.Define;
using WAR.res;
using WAR.setting;

namespace WAR.能力技;

public class 动乱: ISlotResolver
{   
    public SlotMode SlotMode { get; } = SlotMode.OffGcd;
    public int Check()
    {       
        if (!SpellsDefine.Upheaval.IsReady())
        {
            return -1;
        }
        // if ((Helper.自身周围单位数量(5)>=3))
        // {
        //     return -1;
        // }
        if (!Helper.自身存在Buff(Buff.战场风暴))
        {
            return -2;
        }
        if (战士设置.Instance.摆烂战士)
        {
            return -3;
        }
        if (Helper.Gcd剩余时间() < 600)
        {
            return -4;
        }

        return 0;
    }
    
    public void Build(Slot slot)
    {

        slot.Add(技能.动乱.获取技能());
    }

   
}