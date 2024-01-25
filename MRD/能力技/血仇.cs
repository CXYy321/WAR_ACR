using CombatRoutine;
using Common.Define;
using MRD.res;
using MRD.setting;


namespace MRD.能力技
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
            if (Helper.自身血量百分比 < 0.30f)
            {
                return 1;
            }
            if (Helper.自身周围单位数量(5)<3)
            {
                return -1;
            }
            if (!MRD设置.Instance.自动血仇)
            {
                return -1;
            }

            if (Helper.自身血量百分比 > MRD设置.Instance.血仇阈值)
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