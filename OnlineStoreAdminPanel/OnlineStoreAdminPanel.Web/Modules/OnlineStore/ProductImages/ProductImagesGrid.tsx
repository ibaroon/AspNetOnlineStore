import { ProductImagesColumns, ProductImagesRow, ProductImagesService } from '@/ServerTypes/OnlineStore';
import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { ProductImagesDialog } from './ProductImagesDialog';

@Decorators.registerClass('OnlineStoreAdminPanel.OnlineStore.ProductImagesGrid')
export class ProductImagesGrid extends EntityGrid<ProductImagesRow> {
    protected getColumnsKey() { return ProductImagesColumns.columnsKey; }
    protected getDialogType() { return ProductImagesDialog; }
    protected getRowDefinition() { return ProductImagesRow; }
    protected getService() { return ProductImagesService.baseUrl; }
}