using CombatRoutine;
using Common;
using Common.Define;
using MRD.res;
using MRD.setting;


namespace MRD.能力技
{
    public class 狂暴1 : ISlotResolver
    {
        public SlotMode SlotMode => SlotMode.OffGcd;


        public int Check()
        {    
            if (Helper.上一个连击技能() != 技能.凶残裂)
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
            if (!SpellsDefine.Berserk.IsReady())
            {
                return -1;
            }
            
            if (Helper.Gcd剩余时间() < 600)
            {
                return -3;
            }

            return 0;
            

        }
        public void Build(Slot slot)
        {
            slot.Add(技能.狂暴.获取技能());
        }


    }
}