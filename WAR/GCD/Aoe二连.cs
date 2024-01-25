using CombatRoutine;
using Common;
using Common.Define;
using WAR.res;
using WAR.setting;


namespace WAR.GCD
{
    public class Aoe二连 : ISlotResolver
    {
        public SlotMode SlotMode => SlotMode.Gcd;


        //判断是否在近战距离
        public int Check()
        {   
            if (战士设置.Instance.摆烂战士)
            {
                return -1;
            }
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
            if (Helper.上一个连击技能() == 技能.超压斧&&Core.Me.ClassLevel>=40)
            {
                    return 技能.秘银暴风.获取技能();
            }
           
            return 技能.超压斧.获取技能();
        }

        public void Build(Slot slot)
        {
            var spell = 获取技能();
            slot.Add(spell);
        }
    }
}