using CombatRoutine;
using Common.Define;
using MRD.res;
using MRD.setting;


namespace MRD.能力技
{
    public class 战栗 : ISlotResolver
    {
        public SlotMode SlotMode => SlotMode.OffGcd;


        public int Check()
        {
            
            if (!MRD设置.Instance.自动战栗)
            {
                return -1;
            }
            if (!SpellsDefine.ThrillofBattle.IsReady())
            {
                return -1;
            }
            if (Helper.自身血量百分比 > MRD设置.Instance.战栗阈值)
            {
                return -2;
            }
            return 0;

        }
        public void Build(Slot slot)
        {
            slot.Add(技能.战栗.获取技能());
        }


    }
}