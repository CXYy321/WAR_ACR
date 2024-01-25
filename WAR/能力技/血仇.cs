using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;
using WAR.res;
using WAR.setting;


namespace WAR.能力技
{
    public class 血仇 : ISlotResolver
    {
        public SlotMode SlotMode => SlotMode.OffGcd;


        public int Check()
        {               
            if (!SpellsDefine.Reprisal.IsReady())
            {
                return -1;
            }

            if (Helper.是否AOE(Core.Me.GetCurrTarget(),4))
            {
                return 1;
            }
            if (Helper.自身血量百分比 < 0.30f)
            {
                return 1;
            }
            if (Helper.自身周围单位数量(5)<3)
            {
                return -1;
            }
            if (!战士设置.Instance.自动血仇)
            {
                return -1;
            }

            if (Helper.自身血量百分比 > 战士设置.Instance.血仇阈值)
            {
                return -2;
            }
            return 0;

        }
        public void Build(Slot slot)
        {
            slot.Add(技能.血仇.获取技能());
        }


    }
}