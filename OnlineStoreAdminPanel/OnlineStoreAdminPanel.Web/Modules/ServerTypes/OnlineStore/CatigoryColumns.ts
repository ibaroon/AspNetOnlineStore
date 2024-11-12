import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { CatigoryRow } from "./CatigoryRow";

export interface CatigoryColumns {
    Id: Column<CatigoryRow>;
    Name: Column<CatigoryRow>;
    Photo: Column<CatigoryRow>;
    Description: Column<CatigoryRow>;
}

export class CatigoryColumns extends ColumnsBase<CatigoryRow> {
    static readonly columnsKey = 'OnlineStore.Catigory';
    static readonly Fields = fieldsProxy<CatigoryColumns>();
}