using CombatRoutine;
using Common.Define;
using MRD.res;
using MRD.setting;


namespace MRD.能力技
{
    public class 死斗 : ISlotResolver
    {
        public SlotMode SlotMode => SlotMode.OffGcd;


        public int Check()
        {
            
            if (!MRD设置.Instance.自动死斗)
            {
                return -1;
            }
            if (!SpellsDefine.Holmgang.IsReady())
            {
                return -1;
            }
            if (Helper.自身血量百分比 > MRD设置.Instance.死斗阈值)
            {
                return -2;
            }
            return 0;

        }
        public void Build(Slot slot)
        {
            slot.Add(技能.死斗.获取技能());
        }


    }
}