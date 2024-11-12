import { CatigoryForm, CatigoryRow, CatigoryService } from '@/ServerTypes/OnlineStore';
import { Decorators, EntityDialog } from '@serenity-is/corelib';

@Decorators.registerClass('OnlineStoreAdminPanel.OnlineStore.CatigoryDialog')
export class CatigoryDialog extends EntityDialog<CatigoryRow, any> {
    protected getFormKey() { return CatigoryForm.formKey; }
    protected getRowDefinition() { return CatigoryRow; }
    protected getService() { return CatigoryService.baseUrl; }

    protected form = new CatigoryForm(this.idPrefix);
}