using CombatRoutine;
using Common.Define;
using MRD.res;
using MRD.setting;


namespace MRD.能力技
{
    public class 复仇 : ISlotResolver
    {
        public SlotMode SlotMode => SlotMode.OffGcd;


        public int Check()
        {
            
            if (!MRD设置.Instance.自动复仇)
            {
                return -1;
            }
            if (!SpellsDefine.Vengeance.IsReady())
            {
                return -1;
            }
            if (Helper.自身血量百分比 > MRD设置.Instance.复仇阈值)
            {
                return -2;
            }
            return 0;

        }
        public void Build(Slot slot)
        {
            slot.Add(技能.复仇.获取技能());
        }


    }
}