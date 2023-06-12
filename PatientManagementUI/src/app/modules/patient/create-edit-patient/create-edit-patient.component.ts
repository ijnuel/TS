import { Component, Input, OnInit } from '@angular/core';
import { CreatePatientRequest, PatientDto, PatientsService, UpdatePatientRequest } from '../../../services/patient-management-service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-create-edit-patient',
  templateUrl: './create-edit-patient.component.html',
  styleUrls: ['./create-edit-patient.component.css']
})
export class CreateEditPatientComponent implements OnInit {
  @Input() public patient!: PatientDto;
  @Input() public isNew!: boolean;
  form!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private _patientsService : PatientsService,
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
      patientId: [
        this.patient.patientId,
        Validators.compose([
          Validators.required
        ]),
      ],
      firstName: [
        this.patient.firstName,
        Validators.compose([
          Validators.required
        ]),
      ],
      lastName: [
        this.patient.lastName,
        Validators.compose([
          Validators.required
        ]),
      ]
    });
  }

  
  submit() {
    this.spinner.show();
    if (this.isNew) {
      let patientRequest: CreatePatientRequest = {
        patientId: this.f.patientId,
        firstName: this.f.firstName,
        lastName: this.f.lastName
      }
      this._patientsService.apiPatientsCreatePost(patientRequest).subscribe(result => {
        this.closeModal(result.entity);
      });
    }
    else {
      let patientRequest: UpdatePatientRequest = {
        id: this.patient.id,
        patientId: this.f.patientId,
        firstName: this.f.firstName,
        lastName: this.f.lastName
      }
      this._patientsService.apiPatientsUpdatePost(patientRequest).subscribe(result => {
        this.closeModal(result.entity);
      });
    }
  }

  closeModal(saved: boolean = false) {
    this.spinner.hide();
    this.activeModal.close(saved);
  }
}
