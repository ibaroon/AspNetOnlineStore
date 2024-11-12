import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { ProductImagesRow } from "./ProductImagesRow";

export interface ProductImagesColumns {
    Id: Column<ProductImagesRow>;
    ProductName: Column<ProductImagesRow>;
    Image: Column<ProductImagesRow>;
}

export class ProductImagesColumns extends ColumnsBase<ProductImagesRow> {
    static readonly columnsKey = 'OnlineStore.ProductImages';
    static readonly Fields = fieldsProxy<ProductImagesColumns>();
}