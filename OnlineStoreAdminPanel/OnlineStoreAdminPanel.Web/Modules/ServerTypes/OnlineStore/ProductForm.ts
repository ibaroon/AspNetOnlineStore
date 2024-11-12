import { StringEditor, DecimalEditor, ServiceLookupEditor, ImageUploadEditor, DateEditor, IntegerEditor, PrefixedContext, initFormType } from "@serenity-is/corelib";

export interface ProductForm {
    Name: StringEditor;
    Description: StringEditor;
    Price: DecimalEditor;
    CatId: ServiceLookupEditor;
    Photo: ImageUploadEditor;
    CreatedAt: DateEditor;
    Quan: IntegerEditor;
}

export class ProductForm extends PrefixedContext {
    static readonly formKey = 'OnlineStore.Product';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!ProductForm.init)  {
            ProductForm.init = true;

            var w0 = StringEditor;
            var w1 = DecimalEditor;
            var w2 = ServiceLookupEditor;
            var w3 = ImageUploadEditor;
            var w4 = DateEditor;
            var w5 = IntegerEditor;

            initFormType(ProductForm, [
                'Name', w0,
                'Description', w0,
                'Price', w1,
                'CatId', w2,
                'Photo', w3,
                'CreatedAt', w4,
                'Quan', w5
            ]);
        }
    }
}