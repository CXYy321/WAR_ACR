

using CombatRoutine.View;
using ImGuiNET;


namespace WAR.setting;
public class AeUi : ISettingUI//这个是AE界面，ACR那栏，设置界面的东西
{
    public string Name => "战士";

    public void Draw()
    {
        ImGui.Text("严重警告！！！此ACR只能用来打日随，用这玩意打高难算你牛逼");
        ImGui.Text("关注DC_CXY谢谢喵");
        ImGui.Text("咸鱼小店死个妈");
        if (ImGui.Button("保存设置")) 战士设置.Instance.Save();
    }
}
