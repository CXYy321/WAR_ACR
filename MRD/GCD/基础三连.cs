using CombatRoutine;
using Common;
using Common.Define;
using MRD.res;
using MRD.setting;


namespace MRD.GCD
{
    public class 基础三连 : ISlotResolver
    {
        public SlotMode SlotMode => SlotMode.Gcd;


        //判断是否在近战距离
        public int Check()
        {    
            
    
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
                if (Helper.自身存在Buff大于时间(Buff.战场风暴, 1400))
                {
                    return 技能.暴风斩.获取技能();
                }
                else
                {
                    return 技能.暴风碎.获取技能();//判断红绿斩
                }
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