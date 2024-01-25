using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;
using WAR.res;
using WAR.setting;


namespace WAR.能力技
{
    public class 复仇 : ISlotResolver
    {
        public SlotMode SlotMode => SlotMode.OffGcd;


        public int Check()
        {
            
            if (!战士设置.Instance.自动复仇)
            {
                return -1;
            }
            if (!SpellsDefine.Vengeance.IsReady())
            {
                return -1;
            }
            if (Helper.是否死刑(Core.Me.GetCurrTarget(),4))
            {
                return 1;
            }
            if (Helper.自身血量百分比 > 战士设置.Instance.复仇阈值)
            {
                return -2;
            }
            return 0;

        }
        public void Build(Slot slot)
        {
            slot.Add(技能.复仇.获取技能());
        }


    }
}