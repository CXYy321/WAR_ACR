using CombatRoutine;
using Common;
using Common.Define;
using WAR.res;
using WAR.setting;


namespace WAR.GCD
{
    public class 前基础三连 : ISlotResolver
    {
        public SlotMode SlotMode => SlotMode.Gcd;


        //判断是否在近战距离
        public int Check()
        {    if (Core.Me.ClassLevel>=50)
            {
                return -1;
            }
            if (战士设置.Instance.摆烂战士)
            {
                return -1;
            }
            if (!Helper.目标在自身近战距离())
            {
                return -1;
            }
            return 0;
        }

        public Spell 获取技能()
        {
            if (Helper.上一个连击技能() == 技能.凶残裂&&Core.Me.ClassLevel>=26)
            {
                    return 技能.暴风斩.获取技能();
            }
            if (Helper.上一个连击技能() == 技能.重劈&&Core.Me.ClassLevel>=4)
            {
                return 技能.凶残裂.获取技能();//基础连击2
            }
            return 技能.重劈.获取技能();//基础连击1
        }

        public void Build(Slot slot)
        {
            var spell = 获取技能();
            slot.Add(spell);
        }
    }
}