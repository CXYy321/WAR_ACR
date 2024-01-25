using CombatRoutine;
using WAR.res;
using WAR.setting;

namespace WAR.GCD;

public class 飞斧 : ISlotResolver
{    public SlotMode SlotMode => SlotMode.Gcd;
    
    public int Check()
    {
        if (!Qt.GetQt("飞斧"))
        {
            return -1;
            
        }

        if (战士设置.Instance.摆烂战士)
        {
            return 0;
        }

        if (Helper.目标距离()<=战士设置.Instance.飞斧距离 || Helper.目标距离()>20)
        {
            return -1;
        }
        

        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(技能.飞斧.获取技能());
    }

   
}

