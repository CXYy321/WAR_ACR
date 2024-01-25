using CombatRoutine;
using Common.Define;
using WAR.res;
using WAR.setting;

namespace WAR.能力技;

public class 战嚎 : ISlotResolver
{
    public int Check()
    {
        if (战士设置.Instance.摆烂战士)
        {
            return -1;
        }
        if (!Helper.目标在自身近战距离())
        {
            return -1;
        }
        if (!SpellsDefine.Infuriate.IsReady())
        {
            return -1;
        }
        if (!Helper.技能可用(技能.战壕))
        {
            return -1;
        }

        if (Helper.Gcd剩余时间() < 600)
        {
            return -3;
        }

        if (Helper.兽魂() >= 50)
        {
            return -2;
        }

        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(技能.战壕.获取技能());
    }

    public SlotMode SlotMode { get; } =SlotMode.OffGcd;
}