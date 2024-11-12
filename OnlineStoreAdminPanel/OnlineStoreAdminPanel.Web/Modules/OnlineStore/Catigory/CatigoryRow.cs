using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace OnlineStoreAdminPanel.OnlineStore;

[ConnectionKey("OnlineStore"), Module("OnlineStore"), TableName("catigory")]
[DisplayName("Catigory"), InstanceName("Catigory")]
[ReadPermission("Catigory")]
[ModifyPermission("Catigory")]
[ServiceLookupPermission("Catigory")]
public sealed class CatigoryRow : Row<CatigoryRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Id"), Column("id"), Identity, IdProperty]
    public int? Id { get => fields.Id[this]; set => fields.Id[this] = value; }

    [DisplayName("Name"), Column("name"), QuickSearch, NameProperty]
    public string Name { get => fields.Name[this]; set => fields.Name[this] = value; }

    [DisplayName("Photo"), Column("photo")]
    public string Photo { get => fields.Photo[this]; set => fields.Photo[this] = value; }

    [DisplayName("Description"), Column("description")]
    public string Description { get => fields.Description[this]; set => fields.Description[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field Id;
        public StringField Name;
        public StringField Photo;
        public StringField Description;

    }
}