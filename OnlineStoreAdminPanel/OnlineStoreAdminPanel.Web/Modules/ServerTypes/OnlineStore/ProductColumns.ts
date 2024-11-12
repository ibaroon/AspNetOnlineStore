import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { ProductRow } from "./ProductRow";

export interface ProductColumns {
    Id: Column<ProductRow>;
    Name: Column<ProductRow>;
    Description: Column<ProductRow>;
    Price: Column<ProductRow>;
    CatName: Column<ProductRow>;
    Photo: Column<ProductRow>;
    CreatedAt: Column<ProductRow>;
    Quan: Column<ProductRow>;
}

export class ProductColumns extends ColumnsBase<ProductRow> {
    static readonly columnsKey = 'OnlineStore.Product';
    static readonly Fields = fieldsProxy<ProductColumns>();
}