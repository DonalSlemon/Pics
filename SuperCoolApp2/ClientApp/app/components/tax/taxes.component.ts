import { Component, Inject, OnInit } from '@angular/core';
import { ITaxes, IMedical } from '../shared/index';
import { TaxesService } from '../shared/taxes.service';
import { ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { FormControl, Validators, FormGroup } from '@angular/forms';


@Component({
    selector:'taxes',
    templateUrl: './taxes.component.html',
    styleUrls: ['./taxes.component.css'],
    providers: [TaxesService]
})

export class TaxesComponent implements OnInit {
    taxes: any;
    errorMessage: string;
    yourincome: number
    yourraamount: number
    yourage: number
    youhavemedical: boolean
    yourdependants: number
    calculateannual: boolean

    taxForm: FormGroup
    income: FormControl
    raamount: FormControl
    ageinyrs: FormControl
    havemedical: FormControl
    nomedical: FormControl
    dependants: FormControl
    monthly: FormControl
    annual: FormControl

    ngOnInit() {
        this.income = new FormControl('', Validators.required)
        this.raamount = new FormControl('', Validators.required)
        this.ageinyrs = new FormControl('', Validators.required)
        this.havemedical = new FormControl('')
        this.nomedical = new FormControl('')
        this.dependants = new FormControl('', Validators.required)
        this.monthly = new FormControl('')
        this.annual = new FormControl('')

        this.taxForm = new FormGroup({
            income: this.income,
            raamount: this.raamount,
            ageinyrs: this.ageinyrs,
            havemedical: this.havemedical,
            nomedical: this.nomedical,
            dependants: this.dependants,
            monthly: this.monthly,
            annual: this.annual
        })
        this.calculateannual = true
    }
    public calcTaxes(formValues: any) {
        this.yourincome = formValues.income
        this.yourraamount = formValues.raamount
        this.yourage = formValues.ageinyrs
        this.youhavemedical = this.getHasMedical(this.taxForm.controls['havemedical'].value)
        this.yourdependants = +formValues.dependants
        this.calculateannual = this.getIsMonthly(this.taxForm.controls['monthly'].value)

        this.getTaxes(this.yourincome, this.yourraamount, this.yourage, this.youhavemedical, this.yourdependants, this.calculateannual)
    }

    public getHasMedical(whichisit : boolean) {
        if (this.taxForm.controls['havemedical'].value == true) return true
        else
            return false
    }

    public setRadio(trueorfalse: boolean) {
        if (trueorfalse == true) {
            this.taxForm.controls['havemedical'].value == true
            this.taxForm.controls['nomedical'].reset('checked', false)
        }

        if (trueorfalse == false) {
            this.taxForm.controls['nomedical'].value == true
            this.taxForm.controls['havemedical'].reset('checked', false)
        }
    }

    public getIsMonthly(annualormonthly: boolean) {
        if (this.taxForm.controls['monthly'].value == true) return true
        else
            return false
    }

    public setmonthlyRadio(trueorfalse2: boolean) {
        if (trueorfalse2 == true) {
            this.taxForm.controls['monthly'].value == true//.setValue(true)
            //this.taxForm.controls['annual'].reset('checked', false)
        }

        if (trueorfalse2 == false) {
            this.taxForm.controls['annual'].value == true//.setValue(true)
            //this.taxForm.controls['monthly'].reset('checked', false)
        }
    }

    constructor(private taxesService: TaxesService, http: Http, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute) {
    }


    getTaxes(tincome: number, traamount: number, tage: number, med: boolean, dependants: number, isannual: boolean) {
        this.taxesService.calculateTaxes(tincome, traamount, tage, med, dependants, isannual)
            .subscribe(
            taxes => this.taxes = taxes, //JSON.stringify(taxes),
            error => this.errorMessage = error),
            () => console.log("Finished getting taxes");
    }
    
}
