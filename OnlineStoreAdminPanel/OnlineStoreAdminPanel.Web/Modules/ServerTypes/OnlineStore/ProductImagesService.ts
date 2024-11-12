import { SaveRequest, SaveResponse, ServiceOptions, DeleteRequest, DeleteResponse, RetrieveRequest, RetrieveResponse, ListRequest, ListResponse, serviceRequest } from "@serenity-is/corelib";
import { ProductImagesRow } from "./ProductImagesRow";

export namespace ProductImagesService {
    export const baseUrl = 'OnlineStore/ProductImages';

    export declare function Create(request: SaveRequest<ProductImagesRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<ProductImagesRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<ProductImagesRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<ProductImagesRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<ProductImagesRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<ProductImagesRow>>;

    export const Methods = {
        Create: "OnlineStore/ProductImages/Create",
        Update: "OnlineStore/ProductImages/Update",
        Delete: "OnlineStore/ProductImages/Delete",
        Retrieve: "OnlineStore/ProductImages/Retrieve",
        List: "OnlineStore/ProductImages/List"
    } as const;

    [
        'Create', 
        'Update', 
        'Delete', 
        'Retrieve', 
        'List'
    ].forEach(x => {
        (<any>ProductImagesService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}