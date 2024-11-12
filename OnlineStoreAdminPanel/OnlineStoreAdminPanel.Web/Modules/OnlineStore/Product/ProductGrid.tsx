import { ProductColumns, ProductRow, ProductService } from '@/ServerTypes/OnlineStore';
import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { ProductDialog } from './ProductDialog';

@Decorators.registerClass('OnlineStoreAdminPanel.OnlineStore.ProductGrid')
export class ProductGrid extends EntityGrid<ProductRow> {
    protected getColumnsKey() { return ProductColumns.columnsKey; }
    protected getDialogType() { return ProductDialog; }
    protected getRowDefinition() { return ProductRow; }
    protected getService() { return ProductService.baseUrl; }
}