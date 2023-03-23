export class CalculateCommissionRequest {
    ClientTypeId : number;
    PassengersAmmount : number;
    TripDuration : number;
    TravelPackages : Array<number> = new Array<number>();
}
