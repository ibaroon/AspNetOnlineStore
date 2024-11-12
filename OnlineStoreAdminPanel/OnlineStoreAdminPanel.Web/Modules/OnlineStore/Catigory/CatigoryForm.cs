using Serenity.ComponentModel;

namespace OnlineStoreAdminPanel.OnlineStore.Forms;

[FormScript("OnlineStore.Catigory")]
[BasedOnRow(typeof(CatigoryRow), CheckNames = true)]
public class CatigoryForm
{
    public string Name { get; set; }
    public string Photo { get; set; }
    public string Description { get; set; }
}