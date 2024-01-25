using CombatRoutine;
using CombatRoutine.View.JobView;
using Common;
using Common.GUI;
using Common.Helper;
using Common.Language;
using ImGuiNET;
using WAR.res;
using System.Diagnostics;

#pragma warning disable CA1416

namespace WAR.setting;

public class AcrUi
{
    private bool isHorizontal;
    public string? War7386;

    public static void OpenWebPage(string url)
    {
        Process.Start(url);
    }

    public void Draw日志(JobViewWindow jobViewWindow)
    {
        ImGui.Text("菜逼CXY写的ACR");
        ImGui.Text("第一次从0开始写ACR,请大家轻喷");
        ImGui.Text("有问题请反馈");
        ImGui.Text("警告！！！仅限于日常本使用");

        if (ImGui.Button("你想看看涩图么？"))
        {
            Process.Start(new ProcessStartInfo("cmd",
                "/c start https://discord.com/channels/1191648233454313482/1196081001407979600"));
        }

        ImGui.Text("记得打开梯子哦");
    }

    public void DrawGeneral(JobViewWindow jobViewWindow) //通用，会在WarriorRotationEntry中调用
    {
        ImGui.Text("===飞斧距离===");
        ImGui.Text("表示多远之后用飞斧");
        ImGui.Text("拖动滑块可自行调整");
        ImGui.Text("Ctrl+左键单击滑块可以直接输入数字");
        if (ImGui.SliderInt("飞斧距离", ref 战士设置.Instance.飞斧距离, 5, 20))
        {
            战士设置.Instance.Save();
        }

        if (ImGui.CollapsingHeader("特殊选项")) //相当于一个折叠栏
        {
            ImGui.Text("--多变迷宫支持--（还在开发中，暂不能用）"); //文字描述
            if (ImGui.Checkbox("多变六根山自动减伤", ref 战士设置.Instance.多变精神镖)) 战士设置.Instance.Save();
            ImGui.Text("--摆烂斧头人--"); //文字描述
            ImGui.Text("适合ba战士稳仇或者整活"); //文字描述
            ImGui.Text("全程输出循环只会打飞斧"); //文字描述
            if (ImGui.Checkbox("开摆", ref 战士设置.Instance.摆烂战士)) 战士设置.Instance.Save();
        }

        if (ImGui.CollapsingHeader("红斩相关")) //相当于一个折叠栏
        {
            if (ImGui.InputInt("红斩时间", ref 战士设置.Instance.红斩时间)) //这是一个能够自行输入数值的框框的写法，这里写的东西会保存在WARSettings的“红斩时间”里
            {
                战士设置.Instance.Save();
            }
        }


        if (ImGui.CollapsingHeader("留几层猛攻")) //相当于一个折叠栏 
        {
            ImGui.Text("默认是0层，即一层不留"); //文字描述

            War7386 = 战士设置.Instance.猛攻层数 switch
            {
                0 => "0层",
                1 => "1层",
                2 => "2层",
                3 => "3层",
                _ => War7386
            };

            if (ImGui.BeginCombo("猛攻层数", War7386))
            {
                if (ImGui.Selectable("0层"))
                {
                    战士设置.Instance.猛攻层数 = 0;
                }

                if (ImGui.Selectable("1层"))
                {
                    战士设置.Instance.猛攻层数 = 1;
                }

                if (ImGui.Selectable("2层"))
                {
                    战士设置.Instance.猛攻层数 = 2;
                }

                if (ImGui.Selectable("3层"))
                {
                    战士设置.Instance.猛攻层数 = 3;
                }

                ImGui.EndCombo();
            }

            战士设置.Instance.Save();
        }

        if (ImGui.CollapsingHeader("插入技能状态")) //相当于一个折叠栏
        {
            if (ImGui.Button("清除队列")) //按钮写法，内容为清除队列操作的具体写法， 可以照抄
            {
                AI.Instance.BattleData.HighPrioritySlots_OffGCD.Clear();
                AI.Instance.BattleData.HighPrioritySlots_GCD.Clear();
            }

            ImGui.SameLine();
            if (ImGui.Button("清除一个")) //按钮写法，内容为清除一个技能操作的具体写法， 可以照抄
            {
                AI.Instance.BattleData.HighPrioritySlots_OffGCD.Dequeue();
                AI.Instance.BattleData.HighPrioritySlots_GCD.Dequeue();
            }

            ImGui.Text("-------能力技-------"); //文字描述，下面接的是显示具体能力技的写法
            if (AI.Instance.BattleData.HighPrioritySlots_OffGCD.Count > 0)
                foreach (var spell in AI.Instance.BattleData.HighPrioritySlots_OffGCD)
                    ImGui.Text(spell.Name);
            ImGui.Text("-------GCD-------"); //文字描述，下面接的是显示具体GCD的写法
            if (AI.Instance.BattleData.HighPrioritySlots_GCD.Count > 0)
                foreach (var spell in AI.Instance.BattleData.HighPrioritySlots_GCD)
                    ImGui.Text(spell.Name);
        }
    }

    public void Draw减伤(JobViewWindow jobViewWindow)
    {
        if (ImGui.CollapsingHeader("自动减伤开关"))
        {
            if (ImGui.Checkbox("自动铁壁", ref 战士设置.Instance.自动铁壁)) 战士设置.Instance.Save();
            if (ImGui.Checkbox("自动复仇", ref 战士设置.Instance.自动复仇)) 战士设置.Instance.Save();
            if (ImGui.Checkbox("自动血仇", ref 战士设置.Instance.自动血仇)) 战士设置.Instance.Save();
            if (ImGui.Checkbox("自动摆脱", ref 战士设置.Instance.自动摆脱)) 战士设置.Instance.Save();
            if (ImGui.Checkbox("自动泰然", ref 战士设置.Instance.自动泰然)) 战士设置.Instance.Save();
            if (ImGui.Checkbox("自动战栗", ref 战士设置.Instance.自动战栗)) 战士设置.Instance.Save();
            if (ImGui.Checkbox("自动死斗", ref 战士设置.Instance.自动死斗)) 战士设置.Instance.Save();
            if (ImGui.Checkbox("自动血气", ref 战士设置.Instance.自动血气)) 战士设置.Instance.Save();
        }

        if (ImGui.CollapsingHeader("自动减伤阈值"))
        {
            ImGui.Text("开发中");
            ImGui.Text("拖动滑块可自行调整");
            ImGui.Text("Ctrl+左键单击滑块可以直接输入数字");
            if (ImGui.SliderFloat("铁壁阈值", ref 战士设置.Instance.铁壁阈值, 0.0f, 0.99f))
            {
                战士设置.Instance.Save();
            }

            if (ImGui.SliderFloat("复仇阈值", ref 战士设置.Instance.复仇阈值, 0.0f, 0.99f))
            {
                战士设置.Instance.Save();
            }

            if (ImGui.SliderFloat("血仇阈值", ref 战士设置.Instance.血仇阈值, 0.0f, 0.99f))
            {
                战士设置.Instance.Save();
            }

            if (ImGui.SliderFloat("摆脱阈值", ref 战士设置.Instance.摆脱阈值, 0.0f, 0.99f))
            {
                战士设置.Instance.Save();
            }

            if (ImGui.SliderFloat("泰然阈值", ref 战士设置.Instance.泰然阈值, 0.0f, 0.99f))
            {
                战士设置.Instance.Save();
            }

            if (ImGui.SliderFloat("战栗阈值", ref 战士设置.Instance.战栗阈值, 0.0f, 0.99f))
            {
                战士设置.Instance.Save();
            }

            if (ImGui.SliderFloat("死斗阈值", ref 战士设置.Instance.死斗阈值, 0.0f, 0.99f))
            {
                战士设置.Instance.Save();
            }

            if (ImGui.SliderFloat("血气阈值", ref 战士设置.Instance.铁壁阈值, 0.0f, 0.99f))
            {
                战士设置.Instance.Save();
            }
        }
    }

    public void DrawTimeLine(JobViewWindow jobViewWindow) //时间轴，会在WarriorRotationEntry中调用，不懂的话建议全文照抄
    {
        var currTriggerline = AI.Instance.TriggerlineData.CurrTriggerLine;
        var notice = "无";
        if (currTriggerline != null) notice = $"[{currTriggerline.Author}]{currTriggerline.Name}";

        ImGui.Text(notice);
        if (currTriggerline != null)
        {
            ImGui.Text("导出变量:".Loc());
            ImGui.Indent();
            foreach (var v in currTriggerline.ExposedVars)
            {
                var oldValue = AI.Instance.ExposedVars.GetValueOrDefault(v);
                ImGuiHelper.LeftInputInt(v, ref oldValue);
                AI.Instance.ExposedVars[v] = oldValue;
            }

            ImGui.Unindent();
        }
    }

    public void DrawDev(JobViewWindow jobViewWindow) //Dev，会在WarriorRotationEntry中调用，不懂的话建议全文照抄
    {
        if (ImGui.TreeNode("循环"))
        {
            ImGui.Text($"爆发药：{Qt.GetQt("爆发药")}");
            ImGui.Text($"gcd是否可用：{AI.Instance.CanUseGCD()}");
            ImGui.Text($"gcd剩余时间：{AI.Instance.GetGCDCooldown()}");
            ImGui.Text($"gcd总时间：{AI.Instance.GetGCDDuration()}");
            ImGui.TreePop();
        }


        if (ImGui.TreeNode("技能释放"))
        {
            ImGui.Text($"上个技能：{Core.Get<IMemApiSpellCastSucces>().LastSpell}");
            ImGui.Text($"上个GCD：{Core.Get<IMemApiSpellCastSucces>().LastGcd}");
            ImGui.Text($"上个能力技：{Core.Get<IMemApiSpellCastSucces>().LastAbility}");
            ImGui.TreePop();
        }

        if (ImGui.TreeNode("小队"))
        {
            ImGui.Text($"小队人数：{PartyHelper.CastableParty.Count}");
            ImGui.Text($"小队坦克数量：{PartyHelper.CastableTanks.Count}");
            ImGui.TreePop();
        }
    }
}

public static class Qt
{
    /// 获取指定名称qt的bool值
    public static bool GetQt(string qtName)
    {
        return WarriorRotationEntry.JobViewWindow.GetQt(qtName);
    }

    /// 反转指定qt的值
    /// <returns>成功返回true，否则返回false</returns>
    public static bool ReverseQt(string qtName)
    {
        return WarriorRotationEntry.JobViewWindow.ReverseQt(qtName);
    }

    /// 设置指定qt的值
    /// <returns>成功返回true，否则返回false</returns>
    public static bool SetQt(string qtName, bool qtValue)
    {
        return WarriorRotationEntry.JobViewWindow.SetQt(qtName, qtValue);
    }

    /// 重置所有qt为默认值
    public static void Reset()
    {
        WarriorRotationEntry.JobViewWindow.Reset();
    }

    /// 给指定qt设置新的默认值
    public static void NewDefault(string qtName, bool newDefault)
    {
        WarriorRotationEntry.JobViewWindow.NewDefault(qtName, newDefault);
    }

    /// 将当前所有Qt状态记录为新的默认值，
    /// 通常用于战斗重置后qt还原到倒计时时间点的状态
    public static void SetDefaultFromNow()
    {
        WarriorRotationEntry.JobViewWindow.SetDefaultFromNow();
    }

    /// 返回包含当前所有qt名字的数组
    public static string[] GetQtArray()
    {
        return WarriorRotationEntry.JobViewWindow.GetQtArray();
    }
}