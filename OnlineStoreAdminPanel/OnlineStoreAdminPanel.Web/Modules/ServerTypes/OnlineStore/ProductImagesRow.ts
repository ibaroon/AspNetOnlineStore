import { fieldsProxy } from "@serenity-is/corelib";

export interface ProductImagesRow {
    Id?: number;
    ProductId?: number;
    Image?: string;
    ProductName?: string;
}

export abstract class ProductImagesRow {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'Image';
    static readonly localTextPrefix = 'OnlineStore.ProductImages';
    static readonly deletePermission = 'ProductImages';
    static readonly insertPermission = 'ProductImages';
    static readonly readPermission = 'ProductImages';
    static readonly updatePermission = 'ProductImages';

    static readonly Fields = fieldsProxy<ProductImagesRow>();
}