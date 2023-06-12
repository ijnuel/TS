export * from './patients.service';
import { PatientsService } from './patients.service';
export * from './payments.service';
import { PaymentsService } from './payments.service';
export const APIS = [PatientsService, PaymentsService];
