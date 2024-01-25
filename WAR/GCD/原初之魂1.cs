using CombatRoutine;
using Common.Define;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombatRoutine.TriggerModel;
using Common;
using WAR.res;
using WAR.setting;


namespace WAR.GCD
{
    internal class 原初之魂1 : ISlotResolver
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
            if (Core.Me.ClassLevel>=50)
            {
                return -1;
            }
            
            
            if (!Helper.目标在自身近战距离())
            {
                return -1;
            }

            if (Helper.兽魂() < 50)
            {
                return -1;
            }
            
            return 0;
            

        }

        private Spell 获取技能()
        {

            return 技能.原初之魂.获取技能();
        }


        public void Build(Slot slot)
        {
            var spell = 获取技能();
            slot.Add(spell);
        }
    }




}