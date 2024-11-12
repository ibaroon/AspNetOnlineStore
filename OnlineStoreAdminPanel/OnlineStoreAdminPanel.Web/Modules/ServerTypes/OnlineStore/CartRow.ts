import { fieldsProxy } from "@serenity-is/corelib";

export interface CartRow {
    Id?: number;
    UserId?: string;
    ProductId?: number;
    Qty?: number;
    ProductName?: string;
}

export abstract class CartRow {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'UserId';
    static readonly localTextPrefix = 'OnlineStore.Cart';
    static readonly deletePermission = 'Cart';
    static readonly insertPermission = 'Cart';
    static readonly readPermission = 'Cart';
    static readonly updatePermission = 'Cart';

    static readonly Fields = fieldsProxy<CartRow>();
}