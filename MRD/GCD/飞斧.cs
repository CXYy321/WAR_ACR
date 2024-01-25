using CombatRoutine;
using MRD.res;
using MRD.setting;

namespace MRD.GCD;

public class 飞斧 : ISlotResolver
{    public SlotMode SlotMode => SlotMode.Gcd;
    
    public int Check()
    {
 
        
        if (Helper.目标距离()<=MRD设置.Instance.飞斧距离 || Helper.目标距离()>20)
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

