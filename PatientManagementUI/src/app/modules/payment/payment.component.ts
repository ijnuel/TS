import { AfterViewInit, Component, OnDestroy, OnInit, Renderer2, ViewChild, Input } from '@angular/core';
import { PatientDto, PatientsService, PaymentsService, PaymentDto } from '../../services/patient-management-service';
import { Subject } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CreatePaymentComponent } from './create-payment/create-payment.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  @ViewChild(DataTableDirective, {static: false})
  dtElement!: DataTableDirective;

  dtTrigger: any = new Subject();

  dtOptions: DataTables.Settings = {};
  data: PaymentDto[] = [];
  totalAmount: number = 0;
  patientData: PatientDto = {};
  patientId: string = "";
  startDate: Date = new Date();
  endDate: Date = new Date();
  form!: FormGroup;
  
  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private _dialog: NgbModal,
    private renderer: Renderer2,
    private _patientsService : PatientsService,
    private _paymentsService : PaymentsService
  ) {
    this.patientId = this.route.snapshot.paramMap.get('id')!;
   }

  ngOnInit(): void {
    this.initForm();
    this.getPatient();
    this.getDtOptions();
  }
// convenience getter for easy access to form fields
get f() {
  return this.form.getRawValue();
}

initForm() {
  this.form = this.fb.group({
    startDate: [
      this.startDate.toISOString(),
      Validators.compose([
        Validators.required
      ]),
    ]
  });

  this.form.addControl('endDate', this.fb.control(
    this.endDate,
    [
      Validators.required,
      // Validators.min(this.f.startDate)
    ]));
    // this.form.controls['startDate'].addValidators(Validators.max(this.f.endDate))
}

refresh() {
  this.startDate = new Date(this.f.startDate);
  this.endDate = new Date(this.f.endDate);
  this.rerender();
}


async getPatient(): Promise<void> {
  this.patientData = (await this._patientsService.apiPatientsGetByIdGet(this.patientId).toPromise())?.entity ?? {};
}

async getTotalAmount(): Promise<void> {
  this.totalAmount = (await this._paymentsService.apiPaymentsGetPatientTotalPaymentGet(this.patientId,this.startDate,this.endDate).toPromise())?.entity ?? 0;
}

  getDtOptions(): void {
    this.dtOptions =  {
      ajax: (dataTablesParameters: any, callback) => {
        this._paymentsService.apiPaymentsGetByPatientIdGet(this.patientId,this.startDate,this.endDate).subscribe(resp => {
          this.data = resp.entity ?? [];
            callback({
              recordsTotal: this.data.length,
              recordsFiltered: this.data.length,
              data: this.data
            });
          });
      },
      columns: [{
        title: 'Amount',
        data: 'amount'
      }, {
        title: 'Payment Date',
        data: 'paymentDate'
      }]
    }; 
  }



  ngAfterViewInit(): void {
    this.dtTrigger.next();
    this.renderer.listen('document', 'click', (event) => {
    });
  }

  rerender(): void {
    this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
      dtInstance.destroy();
      this.dtTrigger.next();
    });
    this.getTotalAmount();
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  createPayment() {
    const dialogRef = this._dialog.open(CreatePaymentComponent, {
      windowClass: 'myCustomModalClass',
      size: 'l',
      backdrop: 'static',
      keyboard: false,
      scrollable: true,
      centered: true
    });
    dialogRef.componentInstance.patient = this.patientData;

    dialogRef.result.then(async (result) => {
      console.log(result)
      if (result) {
        this.rerender();
      }
    }, (reason) => {
    });
  }
}
