import { Component, Input, Inject, ViewChild, OnInit } from '@angular/core'
import { Http } from '@angular/http'
import { ActivatedRoute, Router } from '@angular/router'
import { ImagesService } from '../shared/images.service';
import { UploadFileService } from '../shared/uploadfile.service'
import { IimagesGallery, Header } from '../shared/index'
import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
    selector: 'gallery',
    templateUrl: './gallery.component.html',
    styleUrls: ['./gallery.component.css'],
    host: { '(window:keydown)': 'hotkeys($event)' },
    providers: [ImagesService]
})

export class GalleryComponent implements OnInit {
    images: IimagesGallery[]
    image: any
    id: number

    uploadForm: FormGroup
    imagetitle: FormControl
    //get ID of html inout field:
    @ViewChild("fileInput") fileInput: any
    @ViewChild("fileTitle") fileTitle: any

    pagetitle = "Photos"
    selectedImage: any;
    errorMessage: string
    
    setSelectedImage(image: any) {
        this.selectedImage = image;
    }

    navigate(forward:any) {
        var index = this.images.indexOf(this.selectedImage) + (forward ? 1 : -1);
        if (index >= 0 && index < this.images.length) {
            this.selectedImage = this.images[index];
        }
    }
// inject images service and upload service as dependencies
    constructor(private imagesService: ImagesService, private uploadService: UploadFileService, http: Http, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute) {
        //http.get(baseUrl + 'api/Images/GetImages').subscribe(result => {
        //    this.images = result.json() as IimagesGallery[];
        //}, error => console.error(error));
    }

    ngOnInit() {
        this.getImages()

        this.fileTitle = new FormControl('', Validators.required)

        this.uploadForm = new FormGroup({
            imgtitle: this.fileTitle
        })
    }

    getImages() {
        this.imagesService.getImages()
            .subscribe(
            images => this.images = images,
            error => this.errorMessage = error);
    }
    getImage(id:number): any {
        this.image = this.imagesService.getImage(+this.route.snapshot.params[id])
    }

    deleteImage(image: any) {
        this.imagesService.deleteImage('api/Images', image.imageId)       
    }

//UPLOAD SERVICE CALL
    addFile(): void {
        let fi = this.fileInput.nativeElement;
        if (fi.files && fi.files[0]) {
            let fileToUpload = fi.files[0];

            if (fileToUpload) {
                this.uploadService.upload(fileToUpload)
                .subscribe(res => {
                    console.log(res);
                    //reload
                    this.getImages()
                });
            }
            else
                console.log("FileToUpload was null or undefined.");
        }
    }

    //hotkeys for keyboard navigatiion with arrows
    hotkeys(event:any) {
        if (this.selectedImage) {
            if (event.keyCode == 37) {
                this.navigate(false);
            } else if (event.keyCode == 39) {
                this.navigate(true);
            }
        }
    }

}