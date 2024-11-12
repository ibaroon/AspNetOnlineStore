import { StringEditor, ServiceLookupEditor, IntegerEditor, PrefixedContext, initFormType } from "@serenity-is/corelib";

export interface CartForm {
    UserId: StringEditor;
    ProductId: ServiceLookupEditor;
    Qty: IntegerEditor;
}

export class CartForm extends PrefixedContext {
    static readonly formKey = 'OnlineStore.Cart';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!CartForm.init)  {
            CartForm.init = true;

            var w0 = StringEditor;
            var w1 = ServiceLookupEditor;
            var w2 = IntegerEditor;

            initFormType(CartForm, [
                'UserId', w0,
                'ProductId', w1,
                'Qty', w2
            ]);
        }
    }
}