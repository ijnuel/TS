import { AfterViewInit, Component, OnDestroy, OnInit, Renderer2, ViewChild } from '@angular/core';
import { PatientDto, PatientsService } from '../../services/patient-management-service';
import { Observable, Subject, of } from 'rxjs';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CreateEditPatientComponent } from './create-edit-patient/create-edit-patient.component';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements AfterViewInit, OnDestroy, OnInit {
  @ViewChild(DataTableDirective, {static: false})
  dtElement!: DataTableDirective;

  dtTrigger: any = new Subject();

  dtOptions: DataTables.Settings = {};
  data: PatientDto[] = [];
  
  constructor(
    private _dialog: NgbModal,
    private renderer: Renderer2,
     private router: Router,
    private _patientsService : PatientsService
  ) {
   }

  ngOnInit(): void {
    this.getDtOptions();
  }


  getDtOptions(): void {
    this.dtOptions =  {
      ajax: (dataTablesParameters: any, callback) => {
        this._patientsService.apiPatientsGetAllGet().subscribe(resp => {
          this.data = resp.entity ?? [];
            callback({
              recordsTotal: this.data.length,
              recordsFiltered: this.data.length,
              data: this.data
            });
          });
      },
      columns: [{
        title: 'Patient Id',
        data: 'patientId'
      }, {
        title: 'First name',
        data: 'firstName'
      }, {
        title: 'Last name',
        data: 'lastName'
      }, {
        title: 'Action',
        render: function (data: any, type: any, full: PatientDto) {
          return `
          <i view-patient-id="${full.id}" class="fa-solid fa-eye cursor-pointer"></i>
          <i edit-patient-id="${full.id}" class="fa-solid fa-pen cursor-pointer"></i>
          `;
        }
      }]
    }; 
  }



  ngAfterViewInit(): void {
    this.dtTrigger.next();
    this.renderer.listen('document', 'click', (event) => {
      if (event.target.hasAttribute("view-patient-id")) {
        this.router.navigate(["/patient/" + event.target.getAttribute("view-patient-id")]);
      }
      if (event.target.hasAttribute("edit-patient-id")) {
        this.createEditPatient(event.target.getAttribute("edit-patient-id"), false);
      }
    });
  }

  rerender(): void {
    this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
      dtInstance.destroy();
      this.dtTrigger.next();
    });
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  createEditPatient(id: string = "", isNew: boolean = true) {
    const dialogRef = this._dialog.open(CreateEditPatientComponent, {
      windowClass: 'myCustomModalClass',
      size: 'l',
      backdrop: 'static',
      keyboard: false,
      scrollable: true,
      centered: true
    });
    dialogRef.componentInstance.patient = this.data.find(x => x.id == id) ?? {};
    dialogRef.componentInstance.isNew = isNew;

    dialogRef.result.then(async (result) => {
      console.log(result)
      if (result) {
        this.rerender();
      }
    }, (reason) => {
    });
  }
}
