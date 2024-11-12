import { fieldsProxy } from "@serenity-is/corelib";

export interface CatigoryRow {
    Id?: number;
    Name?: string;
    Photo?: string;
    Description?: string;
}

export abstract class CatigoryRow {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'Name';
    static readonly localTextPrefix = 'OnlineStore.Catigory';
    static readonly deletePermission = 'Catigory';
    static readonly insertPermission = 'Catigory';
    static readonly readPermission = 'Catigory';
    static readonly updatePermission = 'Catigory';

    static readonly Fields = fieldsProxy<CatigoryRow>();
}