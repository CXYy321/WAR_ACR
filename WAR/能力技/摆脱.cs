using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;
using WAR.res;
using WAR.setting;


namespace WAR.能力技
{
    public class 摆脱 : ISlotResolver
    {
        public SlotMode SlotMode => SlotMode.OffGcd;


        public int Check()
        {
            
            if (!战士设置.Instance.自动摆脱)
            {
                return -1;
            }
            if (!SpellsDefine.ShakeItOff.IsReady())
            {
                return -1;
            }
            if (Helper.是否AOE(Core.Me.GetCurrTarget(),4))
            {
                return 1;
            }
            if (Helper.自身血量百分比 > 战士设置.Instance.摆脱阈值)
            {
                return -2;
            }
            return 0;

        }
        public void Build(Slot slot)
        {
            slot.Add(技能.摆脱.获取技能());
        }


    }
}