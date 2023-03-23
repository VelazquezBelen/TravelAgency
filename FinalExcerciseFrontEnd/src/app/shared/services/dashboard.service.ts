import { Injectable } from '@angular/core';
import { ClientTypeVM } from '../model/client-type-VM';
import { CalculateCommissionRequest } from '../model/calculate-commission-request-VM';
import { TravelPackageVM } from '../model/travel-package-vm';
import { TravelPackageDetailVM } from '../model/travel-package-detail-vm';
import { ProductVM } from '../model/product-VM';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {  

  constructor(private http : HttpClient) { }

  getAllClientTypes() : any
  {
    return this.http.get<ClientTypeVM[]>("https://localhost:5001/api/Clients")
  }

  getTravelPackagesByDescription(description : string) : any
  {
    return this.http.get<TravelPackageVM[]>(`https://localhost:5001/api/TravelPackages/GetTravelPackageByDescription?description=${description}`)
  }

  getTravelPackageById(travelPackageId : number) : any
  {    
    return this.http.get<TravelPackageDetailVM>(`https://localhost:5001/api/TravelPackages/${travelPackageId}`)
  }

  calculateCommission(calculateCommissionRequestVM : CalculateCommissionRequest) : any
  {    
    return this.http.post<number>("https://localhost:5001/api/Commissions", calculateCommissionRequestVM)
  }

  private generateClientTypeVMMockData() : Array<ClientTypeVM>
  {
    let client1 = new ClientTypeVM();
    client1.ClientId = 1;
    client1.Description = "Individual";    

    let client2 = new ClientTypeVM();
    client2.ClientId = 2;
    client2.Description = "Corporate";
    
    let list = new Array<ClientTypeVM>();
    list.push(client1);
    list.push(client2);

    return list;
  }

  private generateTravelPackageVMMockData() : Array<TravelPackageVM>
  {
    let travelPackageVM1 = new TravelPackageVM();
    travelPackageVM1.travelPackageId = 1;
    travelPackageVM1.description = "Bariloche Premium";

    let travelPackageVM2 = new TravelPackageVM();
    travelPackageVM2.travelPackageId = 2;
    travelPackageVM2.description = "Tucumán";

    let list = new Array<TravelPackageVM>();
    list.push(travelPackageVM1);
    list.push(travelPackageVM2);

    return list;
  }

  private generateTravelPackageDetailMockData() : Array<TravelPackageDetailVM>
  {
    //Travel Package 1
    let travelPackage1 = new TravelPackageDetailVM();
    travelPackage1.TravelPackageId = 1;
    travelPackage1.Description = "Bariloche Premium";

    let product1 = new ProductVM();
    product1.ProductId = 1;
    product1.Description = "Pasaje Aereo Primera clase";    
    product1.Category = null;
    product1.ProductType = "Airplane Tickets";

    let product2 = new ProductVM();
    product2.ProductId = 2;
    product2.Description = "Alquiler Auto";    
    product2.Category = 2;
    product2.ProductType = "Car Rental";

    let product3 = new ProductVM();
    product3.ProductId = 3;
    product3.Description = "Hotel 3 estrellas";    
    product3.Category = null;
    product3.ProductType = "Hotel";

    travelPackage1.Products.push(product1);
    travelPackage1.Products.push(product2);
    travelPackage1.Products.push(product3);

    //Travel Package 2 
    let travelPackage2 = new TravelPackageDetailVM();
    travelPackage2.TravelPackageId = 2;
    travelPackage2.Description = "Tucumán";

    let product4 = new ProductVM();
    product4.ProductId = 4;
    product4.Description = "Pasaje Aereo clase Económica";    
    product4.Category = null;
    product4.ProductType = "Airplane Tickets";

    let product5 = new ProductVM();
    product5.ProductId = 5;
    product5.Description = "Hotel 2 estrellas";    
    product5.Category = null;
    product5.ProductType = "Hotel";

    travelPackage2.Products.push(product4);
    travelPackage2.Products.push(product5);

    //Adding Travel Packages to the list
    let travelPackageList = new Array<TravelPackageDetailVM>();
    travelPackageList.push(travelPackage1);
    travelPackageList.push(travelPackage2);

    return travelPackageList;
  }
}
