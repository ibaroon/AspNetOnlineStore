import { SaveRequest, SaveResponse, ServiceOptions, DeleteRequest, DeleteResponse, RetrieveRequest, RetrieveResponse, ListRequest, ListResponse, serviceRequest } from "@serenity-is/corelib";
import { CatigoryRow } from "./CatigoryRow";

export namespace CatigoryService {
    export const baseUrl = 'OnlineStore/Catigory';

    export declare function Create(request: SaveRequest<CatigoryRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<CatigoryRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<CatigoryRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<CatigoryRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<CatigoryRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<CatigoryRow>>;

    export const Methods = {
        Create: "OnlineStore/Catigory/Create",
        Update: "OnlineStore/Catigory/Update",
        Delete: "OnlineStore/Catigory/Delete",
        Retrieve: "OnlineStore/Catigory/Retrieve",
        List: "OnlineStore/Catigory/List"
    } as const;

    [
        'Create', 
        'Update', 
        'Delete', 
        'Retrieve', 
        'List'
    ].forEach(x => {
        (<any>CatigoryService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}