import { Component, Input, OnInit } from '@angular/core';
import { CreatePatientRequest, CreatePaymentRequest, PatientDto, PatientsService, PaymentsService, UpdatePatientRequest } from '../../../services/patient-management-service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-create-payment',
  templateUrl: './create-payment.component.html',
  styleUrls: ['./create-payment.component.css']
})
export class CreatePaymentComponent implements OnInit {
  @Input() public patient!: PatientDto;
  form!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private _paymentsService : PaymentsService,
    private spinner: NgxSpinnerService,
    public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
    this.initForm();
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.form.getRawValue();
  }

  initForm() {
    this.form = this.fb.group({
      amount: [
        '',
        Validators.compose([
          Validators.required,
          Validators.min(0)
        ]),
      ],
      paymentDate: [
        new Date(),
        Validators.compose([
          Validators.required
        ]),
      ]
    });
  }

  
  submit() {
    this.spinner.show();
    let paymentRequest: CreatePaymentRequest = {
      patientId: this.patient.id,
      amount: this.f.amount,
      paymentDate: new Date(this.f.paymentDate)
    }
    this._paymentsService.apiPaymentsCreatePost(paymentRequest).subscribe(result => {
      this.closeModal(result.entity);
    });
  }

  closeModal(saved: boolean = false) {
    this.spinner.hide();
    this.activeModal.close(saved);
  }
}
