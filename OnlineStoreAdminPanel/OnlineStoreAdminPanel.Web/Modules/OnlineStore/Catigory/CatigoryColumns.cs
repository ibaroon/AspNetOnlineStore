using Serenity.ComponentModel;
using System.ComponentModel;

namespace OnlineStoreAdminPanel.OnlineStore.Columns;

[ColumnsScript("OnlineStore.Catigory")]
[BasedOnRow(typeof(CatigoryRow), CheckNames = true)]
public class CatigoryColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int Id { get; set; }
    [EditLink]
    public string Name { get; set; }
    public string Photo { get; set; }
    public string Description { get; set; }
}