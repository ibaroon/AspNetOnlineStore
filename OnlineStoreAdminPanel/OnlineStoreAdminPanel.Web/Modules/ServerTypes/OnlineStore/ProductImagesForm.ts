import { ServiceLookupEditor, StringEditor, PrefixedContext, initFormType } from "@serenity-is/corelib";

export interface ProductImagesForm {
    ProductId: ServiceLookupEditor;
    Image: StringEditor;
}

export class ProductImagesForm extends PrefixedContext {
    static readonly formKey = 'OnlineStore.ProductImages';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!ProductImagesForm.init)  {
            ProductImagesForm.init = true;

            var w0 = ServiceLookupEditor;
            var w1 = StringEditor;

            initFormType(ProductImagesForm, [
                'ProductId', w0,
                'Image', w1
            ]);
        }
    }
}