using CombatRoutine;
using Common.Define;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using WAR.res;
using WAR.setting;


namespace WAR.GCD
{
    internal class Fc : ISlotResolver
    {
        public SlotMode SlotMode => SlotMode.Gcd;



        public int Check()
        {
            if (战士设置.Instance.摆烂战士)
            {
                return -1;
            }
            if (!Qt.GetQt("FC"))
            {
                return -1;
            
            }
            if (Core.Me.ClassLevel<54)
            {
                return -1;
            }
            
            
            if (!Helper.目标在自身近战距离())
            {
                return -1;
            }
            if (!Helper.自身存在Buff(Buff.战场风暴))
            {
                return -1;
            }
            if (Helper.兽魂() < 50 && !Helper.自身存在Buff(Buff.原初的解放))
            {
                return -1;
            }
            
            return 0;

        }

        private Spell 获取技能()
        {
            if (Helper.自身存在Buff(Buff.原初的混沌))
            {
                return 技能.狂魂.获取技能();
            }
            return 技能.裂石飞环.获取技能();
        }


        public void Build(Slot slot)
        {
            var spell = 获取技能();
            slot.Add(spell);
        }
    }




}