using CombatRoutine;
using Common;
using Common.Define;
using MRD.res;
using MRD.setting;


namespace MRD.GCD
{
    public class Aoe二连 : ISlotResolver
    {
        public SlotMode SlotMode => SlotMode.Gcd;


        //判断是否在近战距离
        public int Check()
        {   
            if (!Qt.GetQt("AOE"))
            {
                return -1;
            }
            if (Helper.自身周围单位数量(5)<3)
            {
                return -1;
            }
            return 0;
        }

        public Spell 获取技能()
        {

            return 技能.超压斧.获取技能();
        }

        public void Build(Slot slot)
        {
            var spell = 获取技能();
            slot.Add(spell);
        }
    }
}