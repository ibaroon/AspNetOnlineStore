import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { ReviewRow } from "./ReviewRow";

export interface ReviewColumns {
    Id: Column<ReviewRow>;
    Name: Column<ReviewRow>;
    Email: Column<ReviewRow>;
    Subject: Column<ReviewRow>;
    Description: Column<ReviewRow>;
}

export class ReviewColumns extends ColumnsBase<ReviewRow> {
    static readonly columnsKey = 'OnlineStore.Review';
    static readonly Fields = fieldsProxy<ReviewColumns>();
}