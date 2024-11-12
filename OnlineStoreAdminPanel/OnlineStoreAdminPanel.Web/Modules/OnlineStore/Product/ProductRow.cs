using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;

namespace OnlineStoreAdminPanel.OnlineStore;

[ConnectionKey("OnlineStore"), Module("OnlineStore"), TableName("product")]
[DisplayName("Product"), InstanceName("Product")]
[ReadPermission("Product")]
[ModifyPermission("Product")]
[ServiceLookupPermission("Product")]
public sealed class ProductRow : Row<ProductRow.RowFields>, IIdRow, INameRow
{
    const string jCat = nameof(jCat);

    [DisplayName("Id"), Column("id"), Identity, IdProperty]
    public int? Id { get => fields.Id[this]; set => fields.Id[this] = value; }

    [DisplayName("Name"), Column("name"), QuickSearch, NameProperty]
    public string Name { get => fields.Name[this]; set => fields.Name[this] = value; }

    [DisplayName("Description"), Column("description")]
    public string Description { get => fields.Description[this]; set => fields.Description[this] = value; }

    [DisplayName("Price"), Column("price"), Size(18)]
    public decimal? Price { get => fields.Price[this]; set => fields.Price[this] = value; }

    [DisplayName("Cat"), Column("cat_id"), ForeignKey(typeof(CatigoryRow)), LeftJoin(jCat), TextualField(nameof(CatName))]
    [ServiceLookupEditor(typeof(CatigoryRow))]
    public int? CatId { get => fields.CatId[this]; set => fields.CatId[this] = value; }

    [DisplayName("Photo"), Column("photo"),ImageUploadEditor]
    public string Photo { get => fields.Photo[this]; set => fields.Photo[this] = value; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get => fields.CreatedAt[this]; set => fields.CreatedAt[this] = value; }

    [DisplayName("Quan")]
    public int? Quan { get => fields.Quan[this]; set => fields.Quan[this] = value; }

    [DisplayName("Cat Name"), Origin(jCat, nameof(CatigoryRow.Name))]
    public string CatName { get => fields.CatName[this]; set => fields.CatName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field Id;
        public StringField Name;
        public StringField Description;
        public DecimalField Price;
        public Int32Field CatId;
        public StringField Photo;
        public DateTimeField CreatedAt;
        public Int32Field Quan;

        public StringField CatName;
    }
}