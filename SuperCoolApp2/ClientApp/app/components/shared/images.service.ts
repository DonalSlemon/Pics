import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptionsArgs, RequestOptions, Response, Headers, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/RX';
import 'rxjs/add/operator/toPromise';
import { Router } from '@angular/router';
import { IimagesGallery, Header } from './images.model'

@Injectable()
export class ImagesService {
    headers: Headers;
    options: RequestOptions;
    bseURL: any

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, private router: Router) {
        this.bseURL = baseUrl
    }

    getImage(id: number): Observable<IimagesGallery[]> {
        return this.http.get(this.bseURL + 'api/Images/GetImage/' + id)
            .map(this.extractImages)
            .catch(this.handleError);
    }

    deleteImage(url: string, id: number) {

        let svcUrl = `${url}/${id}`;

        return this.http.delete(svcUrl)
            .subscribe((ok) => { console.log(ok) });
    } 

    protected handleErrorPromise(error: any): Promise<void> {
        try {
            error = JSON.parse(error._body);
        } catch (e) {
        }

        let errMsg = error.errorMessage
            ? error.errorMessage
            : error.message
                ? error.message
                : error._body
                    ? error._body
                    : error.status
                        ? `${error.status} - ${error.statusText}`
                        : 'unknown server error';

        console.error(errMsg);
        return Promise.reject(errMsg);
    }

    public getImages(): Observable<IimagesGallery[]> {
        return this.http.get(this.bseURL + 'api/Images/GetImages')
            .map(this.extractImages)
            .catch(this.handleError);
    }

    private extractImages(res: Response) {
        let body = res.json()
        return body || {};
    }

    private handleError(error: any) {
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}

