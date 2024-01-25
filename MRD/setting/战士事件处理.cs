using AEAssist.MemoryApi;
using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;

using MRD.res;

#pragma warning disable CA1416

namespace MRD.setting;

public class MRD事件处理 : IRotationEventHandler
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