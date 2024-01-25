using CombatRoutine;
using Common;
using Common.Define;
using WAR.res;
using WAR.setting;


namespace WAR.能力技
{
    public class 直觉 : ISlotResolver
    {

        public SlotMode SlotMode => SlotMode.OffGcd;


        public int Check()
        {
            if (Core.Me.ClassLevel>=82)
            {
                return -1;
            }
            if (Helper.自身周围单位数量(5)<3)
            {
                return -1;
            }
            if (!战士设置.Instance.自动血气)
            {
                return -1;
            }
            if (!SpellsDefine.RawIntuition.IsReady())
            {
                return -1;
            }
            if (Helper.自身血量百分比 > 战士设置.Instance.血气阈值)
            {
                return -2;
            }
            return 0;

        }
        public void Build(Slot slot)
        {
            slot.Add(技能.原初的直觉.获取技能());
        }



    }
}