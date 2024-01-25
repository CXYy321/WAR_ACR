using AEAssist.MemoryApi;
using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;

using WAR.res;

#pragma warning disable CA1416

namespace WAR.setting;

public class 战士事件处理 : IRotationEventHandler
{
    public void OnResetBattle()
    {
        Qt.Reset();//照抄
    }
    
  

    public Task OnNoTarget()
    {
        return Task.CompletedTask;//照抄
    }

    public void AfterSpell(Slot slot, Spell spell)
    {
        switch (spell.Id)
        {
            case SpellsDefine.StormsEye:
                if (Qt.GetQt("多打一个红斩"))
                {
                    Qt.SetQt("多打一个红斩", false);
                }

                break;

        }
      
    }

    public void OnBattleUpdate(int currTime)
    {
        
    }
    public Task OnPreCombat()//照抄
    {
        return Task.CompletedTask;
    }
}