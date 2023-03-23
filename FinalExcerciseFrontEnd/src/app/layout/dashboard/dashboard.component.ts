import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { DashboardService } from 'src/app/shared/services/dashboard.service';
import { ClientTypeVM } from 'src/app/shared/model/client-type-VM';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CalculateCommissionRequest } from 'src/app/shared/model/calculate-commission-request-VM';
import { TravelPackageVM } from 'src/app/shared/model/travel-package-vm';
import { TravelPackageDetailVM } from 'src/app/shared/model/travel-package-detail-vm';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss'],
    animations: [routerTransition()]
})
export class DashboardComponent implements OnInit {
    alerts: Array<any> = [];
    clientTypeList : Array<ClientTypeVM> = [];
    travelPackageList : Array<TravelPackageVM> = [];
    selectedTravelPackageList : Array<TravelPackageVM> = [];
    selectedTravelPackage : TravelPackageDetailVM = null;
    
    dashboardForm = new FormGroup({
        clientType : new FormControl('', Validators.required),
        passengersAmmount : new FormControl('', Validators.required),
        tripDuration : new FormControl('', Validators.required),
        travelPackageDescription : new FormControl(''),
        selectedTravelPackage : new FormControl('')
    });

    constructor(private dashboardService : DashboardService) {

    }

    ngOnInit()
    {       
        this.dashboardService.getAllClientTypes()
            .subscribe(result => this.clientTypeList = result,
                error => { this.createNotificationMessage("danger", error.error.title)})       
    }

    public closeAlert(alert: any) {
        const index: number = this.alerts.indexOf(alert);
        this.alerts.splice(index, 1);
    }

    getTravelPackages()
    {
        let description = this.dashboardForm.controls.travelPackageDescription.value;

        this.dashboardService.getTravelPackagesByDescription(description)
            .subscribe(result => this.travelPackageList = result, 
                error => { this.createNotificationMessage("danger", error.error.title)})
    }

    selectTravelPackage()
    {
        let selectedTravelPackage = this.dashboardForm.controls.selectedTravelPackage.value;

        if(selectedTravelPackage != "")
            this.selectedTravelPackageList.push(selectedTravelPackage);
    }

    viewTravelPackageDetails(travelPackageId : number)
    {
        this.dashboardService.getTravelPackageById(travelPackageId)
            .subscribe(result => this.selectedTravelPackage = result,
                error => { this.createNotificationMessage("danger", error.error.title)})
    }

    removeTravelPackage(travelPackage : TravelPackageVM)
    {
        this.selectedTravelPackageList = this.selectedTravelPackageList.filter(x => x !== travelPackage);
        this.selectedTravelPackage = null;
    }

    onSubmit()
    {
        let calculateCommissionRequest = new CalculateCommissionRequest();

        calculateCommissionRequest.ClientTypeId = this.dashboardForm.controls.clientType.value;
        calculateCommissionRequest.PassengersAmmount = Number(this.dashboardForm.controls.passengersAmmount.value);
        calculateCommissionRequest.TripDuration = Number(this.dashboardForm.controls.tripDuration.value);
        calculateCommissionRequest.TravelPackages = [];

        this.selectedTravelPackageList.forEach(travelPackage => {
            calculateCommissionRequest.TravelPackages.push(travelPackage.travelPackageId);
        });
        
        this.dashboardService.calculateCommission(calculateCommissionRequest)
            .subscribe(result => {this.createNotificationMessage("success", "My commission is $" + result.toString())},
                    error => { this.createNotificationMessage("danger", error.error.title)})
    }

    private createNotificationMessage(type : string, message : string)
    {
        this.alerts.push({
            id: 1,
            type: type,
            message: message
        });
    }
}
