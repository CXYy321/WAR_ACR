using CombatRoutine;
using Common;
using Common.Define;
using WAR.res;
using WAR.setting;


namespace WAR.能力技
{
    public class 狂暴2 : ISlotResolver
    {
        public SlotMode SlotMode => SlotMode.OffGcd;


        public int Check()
        {       
            if (Core.Me.ClassLevel>=70 || Core.Me.ClassLevel<50)
            {
                return -1;
            }
            if (战士设置.Instance.摆烂战士)
            {
                return -1;
            }
            if (!Helper.目标在自身近战距离())
            {
                return -1;
            }
            if (!SpellsDefine.Berserk.IsReady())
            {
                return -1;
            }

            if (!Helper.自身存在Buff(Buff.战场风暴))
            {
                return -1;
            }
            if (Helper.Gcd剩余时间() < 600)
            {
                return -3;
            }

            return 0;
            

        }
        public void Build(Slot slot)
        {
            slot.Add(技能.狂暴.获取技能());
        }


    }
}