import { CartColumns, CartRow, CartService } from '@/ServerTypes/OnlineStore';
import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { CartDialog } from './CartDialog';

@Decorators.registerClass('OnlineStoreAdminPanel.OnlineStore.CartGrid')
export class CartGrid extends EntityGrid<CartRow> {
    protected getColumnsKey() { return CartColumns.columnsKey; }
    protected getDialogType() { return CartDialog; }
    protected getRowDefinition() { return CartRow; }
    protected getService() { return CartService.baseUrl; }
}