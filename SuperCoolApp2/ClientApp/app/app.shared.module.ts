import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ImageUploadModule } from 'angular2-image-upload';
import { ModuleWithProviders } from '@angular/core';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { GalleryComponent } from './components/gallery/gallery.component';
//import { FileDropDirective } from './components/file-drop.directive';
//import { ImageUploadComponent } from './components/imageupload/image-upload.component';
//import { ImageService } from './components/image.service';
import { UploadFileService } from './components/shared/uploadfile.service';
import { TaxesComponent } from './components/tax/taxes.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        GalleryComponent,
        TaxesComponent
        //ImageUploadComponent,
        //FileDropDirective
    ],
    //exports: [ImageUploadComponent],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'gallery', component: GalleryComponent },
            { path: 'backdrops', component: GalleryComponent },
            { path: 'taxes', component: TaxesComponent },
            //{ path: 'image-upload', component: ImageUploadComponent },
            { path: '**', redirectTo: 'home' }
        ]),
        ImageUploadModule.forRoot()
    ],
    providers: [UploadFileService]
})
export class AppModuleShared {
    
}
