using CombatRoutine;
using Common.Define;
using WAR.res;
using WAR.setting;


namespace WAR.能力技
{
    public class 泰然 : ISlotResolver
    {
        public SlotMode SlotMode => SlotMode.OffGcd;


        public int Check()
        {
            
            if (!战士设置.Instance.自动泰然)
            {
                return -1;
            }
            if (!SpellsDefine.Equilibrium.IsReady())
            {
                return -1;
            }
            if (Helper.自身血量百分比 > 战士设置.Instance.泰然阈值)
            {
                return -2;
            }
            return 0;

        }
        public void Build(Slot slot)
        {
            slot.Add(技能.泰然自若.获取技能());
        }


    }
}