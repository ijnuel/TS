/**
 * API
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { PaymentDto } from './paymentDto';

export interface PaymentDtoListResult { 
    succeeded?: boolean;
    entity?: Array<PaymentDto>;
    exceptionError?: string;
    message?: string;
}