import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptionsArgs, RequestOptions, Response, Headers, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/RX';
//import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';
import { ITaxes, IMedical } from './taxes.model'

@Injectable()
export class TaxesService {
    headers: Headers;
    options: RequestOptions;
    bseURL: any

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, private router: Router) {
        this.bseURL = baseUrl
    }

    calculateTaxes(earningsamount: number
        , racontribamount: number
        , ageinyrs: number
        , hasmedical: boolean
        , numdependants: number
        , isannual: boolean): Observable<ITaxes> {
        return this.http.get(this.bseURL + 'api/Taxes/GetTaxCalculation/' + '?earnings=' + earningsamount + '&racontribamount=' + racontribamount + '&ageinyears=' + ageinyrs + '&med=' + hasmedical + '&dep=' + numdependants + '&isannual=' + isannual)
            .map(this.getTaxCalcResponse)
            .catch(this.handleError);
    }

    private getTaxCalcResponse(res: Response) {
        let body = res.json()
        return body || [];
    }

    private handleError(error: any) {
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
        return Observable.throw(errMsg);
    }

}