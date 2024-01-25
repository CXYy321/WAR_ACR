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
    internal class  钢铁旋风 : ISlotResolver
    {
        public SlotMode SlotMode => SlotMode.Gcd;



        public int Check()
        {               
            if (Core.Me.ClassLevel>=60)
            {
                return -1;
            }
            if (战士设置.Instance.摆烂战士)
            {
                return -1;
            }
            if (!Helper.自身存在Buff(Buff.战场风暴))
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
            if (Helper.兽魂()<50)
            {
                return -1;
            }
            return 1;
        }

        private Spell 获取技能()
        {
            return 技能.钢铁旋风.获取技能();
        }


        public void Build(Slot slot)
        {
            var spell = 获取技能();
            slot.Add(spell);
        }
    }




}