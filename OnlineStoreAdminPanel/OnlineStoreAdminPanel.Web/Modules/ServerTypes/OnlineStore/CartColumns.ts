import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { CartRow } from "./CartRow";

export interface CartColumns {
    Id: Column<CartRow>;
    UserId: Column<CartRow>;
    ProductName: Column<CartRow>;
    Qty: Column<CartRow>;
}

export class CartColumns extends ColumnsBase<CartRow> {
    static readonly columnsKey = 'OnlineStore.Cart';
    static readonly Fields = fieldsProxy<CartColumns>();
}