import { ProductVM } from "./product-VM";

export class TravelPackageDetailVM {
    TravelPackageId : number;
    Description : string;
    Products : Array<ProductVM> = [];
}