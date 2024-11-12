import { CatigoryColumns, CatigoryRow, CatigoryService } from '@/ServerTypes/OnlineStore';
import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { CatigoryDialog } from './CatigoryDialog';

@Decorators.registerClass('OnlineStoreAdminPanel.OnlineStore.CatigoryGrid')
export class CatigoryGrid extends EntityGrid<CatigoryRow> {
    protected getColumnsKey() { return CatigoryColumns.columnsKey; }
    protected getDialogType() { return CatigoryDialog; }
    protected getRowDefinition() { return CatigoryRow; }
    protected getService() { return CatigoryService.baseUrl; }
}