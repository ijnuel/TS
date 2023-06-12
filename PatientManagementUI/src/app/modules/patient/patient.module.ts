import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatientComponent } from './patient.component';
import { PaymentComponent } from '../payment/payment.component';
import { ApiModule, BASE_PATH } from '../../services/patient-management-service';
import { PatientRoutingModule } from './patient-routing.module';
import { environment } from 'src/environments/environment';
import {MatIconModule} from '@angular/material/icon';
import { NgxSpinnerModule } from 'ngx-spinner';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataTablesModule } from "angular-datatables";
import { CreateEditPatientComponent } from './create-edit-patient/create-edit-patient.component';
import { CreatePaymentComponent } from '../payment/create-payment/create-payment.component';



@NgModule({
  declarations: [
    PatientComponent,
    PaymentComponent,
    CreateEditPatientComponent,
    CreatePaymentComponent
  ],
  imports: [
    CommonModule,
    ApiModule,
    DataTablesModule,
    PatientRoutingModule,
    MatIconModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    NgxSpinnerModule.forRoot({ type: 'ball-scale-multiple' })
  ],
  providers: [
    { provide: BASE_PATH, useValue: environment.apiUrl }
  ]
})
export class PatientModule { }
