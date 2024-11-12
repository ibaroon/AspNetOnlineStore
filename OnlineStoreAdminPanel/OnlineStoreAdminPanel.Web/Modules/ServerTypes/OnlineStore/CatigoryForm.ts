import { StringEditor, PrefixedContext, initFormType } from "@serenity-is/corelib";

export interface CatigoryForm {
    Name: StringEditor;
    Photo: StringEditor;
    Description: StringEditor;
}

export class CatigoryForm extends PrefixedContext {
    static readonly formKey = 'OnlineStore.Catigory';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!CatigoryForm.init)  {
            CatigoryForm.init = true;

            var w0 = StringEditor;

            initFormType(CatigoryForm, [
                'Name', w0,
                'Photo', w0,
                'Description', w0
            ]);
        }
    }
}