

using CombatRoutine.View;
using ImGuiNET;


namespace MRD.setting;
public class AeUi : ISettingUI//这个是AE界面，ACR那栏，设置界面的东西
{
    public string Name => "MDR";

    public void Draw()
    {
        ImGui.Text("严重警告！！！此ACR只能用来打日随，用这玩意打高难算你牛逼");
        ImGui.Text("关注DC_MRD谢谢喵");
        ImGui.Text("咸鱼小店死个妈");
        if (ImGui.Button("保存设置")) MRD设置.Instance.Save();
    }
}
