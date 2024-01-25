using CombatRoutine;
using MRD.res;
using MRD.setting;

namespace MRD.能力技;

public class 守护: ISlotResolver
{
    public int Check()
    {
        if (Helper.自身存在Buff(Buff.守护))
        {
            return -1;
        }
        if (!Qt.GetQt("自动盾姿"))
        {
            return -1;
        }

        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(技能.守护.获取技能());
    }

    public SlotMode SlotMode { get; } = SlotMode.OffGcd;
}