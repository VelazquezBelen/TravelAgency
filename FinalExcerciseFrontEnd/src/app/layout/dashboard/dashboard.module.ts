import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { PageHeaderModule } from '../../shared';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
    imports: [
        CommonModule,
        NgbAlertModule,
        DashboardRoutingModule,
        PageHeaderModule,
        ReactiveFormsModule
    ],
    declarations: [
        DashboardComponent
    ]
})
export class DashboardModule {}
