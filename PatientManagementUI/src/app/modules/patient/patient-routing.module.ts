import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PatientComponent } from './patient.component';
import { PaymentComponent } from '../payment/payment.component';

const routes: Routes = [
  { path: '', component: PatientComponent },
  { path: 'patient/:id', component: PaymentComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PatientRoutingModule { }
