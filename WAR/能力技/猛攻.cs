using CombatRoutine;
using Common.Define;
using WAR.res;
using WAR.setting;

namespace WAR.能力技;

public class 猛攻 : ISlotResolver
{
    public int Check()
    {   
        if (!SpellsDefine.Onslaught.IsReady())
        {
            return -1;
        }
        if (Helper.自身存在Buff(Buff.狂暴))
        {
            return -1;
        }
        if (战士设置.Instance.摆烂战士)
        {
            return -1;
        }
        if (!Helper.自身存在Buff(Buff.战场风暴))
        {
            return -1;
        }

        if (技能.蛮荒崩裂.技能刚使用过())
        {
            return -3;
        }
        if (技能.猛攻.技能刚使用过())
        {
            return -3;
        }

        if (Helper.Gcd剩余时间() < 600)
        {
            return -3;
        }

        if (!Helper.目标在自身近战距离()) return -2;
        if (!Qt.GetQt("猛攻"))
        {
            return -1;
        }

        if (技能.猛攻.充能层数() >=战士设置.Instance.猛攻层数)
        {
            return 0;
        }

        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(技能.猛攻.获取技能());
    }

    public SlotMode SlotMode { get; } = SlotMode.OffGcd;
}