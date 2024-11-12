import { ProductForm, ProductRow, ProductService } from '@/ServerTypes/OnlineStore';
import { Decorators, EntityDialog } from '@serenity-is/corelib';

@Decorators.registerClass('OnlineStoreAdminPanel.OnlineStore.ProductDialog')
export class ProductDialog extends EntityDialog<ProductRow, any> {
    protected getFormKey() { return ProductForm.formKey; }
    protected getRowDefinition() { return ProductRow; }
    protected getService() { return ProductService.baseUrl; }

    protected form = new ProductForm(this.idPrefix);
}