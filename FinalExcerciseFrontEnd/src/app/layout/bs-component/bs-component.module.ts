import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {
    AlertComponent
} from './components';
import { PageHeaderModule } from '../../shared';

@NgModule({
    imports: [
        CommonModule,        
        FormsModule,
        ReactiveFormsModule,
        NgbModule,
        PageHeaderModule
    ],
    declarations: [
        AlertComponent
    ]
})
export class BsComponentModule {}
