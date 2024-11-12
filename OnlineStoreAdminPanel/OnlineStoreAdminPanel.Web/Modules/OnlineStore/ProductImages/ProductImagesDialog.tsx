import { ProductImagesForm, ProductImagesRow, ProductImagesService } from '@/ServerTypes/OnlineStore';
import { Decorators, EntityDialog } from '@serenity-is/corelib';

@Decorators.registerClass('OnlineStoreAdminPanel.OnlineStore.ProductImagesDialog')
export class ProductImagesDialog extends EntityDialog<ProductImagesRow, any> {
    protected getFormKey() { return ProductImagesForm.formKey; }
    protected getRowDefinition() { return ProductImagesRow; }
    protected getService() { return ProductImagesService.baseUrl; }

    protected form = new ProductImagesForm(this.idPrefix);
}