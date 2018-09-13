import { Injectable } from '@angular/core'
import { Http, RequestOptionsArgs, RequestOptions, Response, Headers } from '@angular/http'
import { Observable } from 'rxjs/RX'

@Injectable()
export class UploadFileService {
    constructor(private http: Http) {
    }

    upload(fileToUpload: any) {
        let input = new FormData();
        input.append("fileForController", fileToUpload);
        //input.append("fileTitle", fileTitle);

        //let headers = new Headers();
        //headers.append('Accept', 'application/json');

        //let options = new RequestOptions({ headers: headers });
        //this.http.post(this.baseUrl + "upload/", formData, options)
        //    .subscribe(r => console.log(r));
        return this.http.post("/api/upload", input );//{ input, Title: fileTitle });
    }
}