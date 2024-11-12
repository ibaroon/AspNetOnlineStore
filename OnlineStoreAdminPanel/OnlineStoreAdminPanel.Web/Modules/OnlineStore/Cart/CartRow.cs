using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace OnlineStoreAdminPanel.OnlineStore;

[ConnectionKey("OnlineStore"), Module("OnlineStore"), TableName("cart")]
[DisplayName("Cart"), InstanceName("Cart")]
[ReadPermission("Cart")]
[ModifyPermission("Cart")]
[ServiceLookupPermission("Cart")]
public sealed class CartRow : Row<CartRow.RowFields>, IIdRow, INameRow
{
    const string jProduct = nameof(jProduct);

    [DisplayName("Id"), Column("id"), Identity, IdProperty]
    public int? Id { get => fields.Id[this]; set => fields.Id[this] = value; }

    [DisplayName("User Id"), Column("user_id"), QuickSearch, NameProperty]
    public string UserId { get => fields.UserId[this]; set => fields.UserId[this] = value; }

    [DisplayName("Product"), Column("product_id"), ForeignKey(typeof(ProductRow)), LeftJoin(jProduct), TextualField(nameof(ProductName))]
    [ServiceLookupEditor(typeof(ProductRow))]
    public int? ProductId { get => fields.ProductId[this]; set => fields.ProductId[this] = value; }

    [DisplayName("Qty"), Column("qty")]
    public int? Qty { get => fields.Qty[this]; set => fields.Qty[this] = value; }

    [DisplayName("Product Name"), Origin(jProduct, nameof(ProductRow.Name))]
    public string ProductName { get => fields.ProductName[this]; set => fields.ProductName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field Id;
        public StringField UserId;
        public Int32Field ProductId;
        public Int32Field Qty;

        public StringField ProductName;
    }
}