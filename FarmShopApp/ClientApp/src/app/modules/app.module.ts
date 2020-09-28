import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { MatNativeDateModule } from '@angular/material/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from '../components/app.component';
import { HomeComponent } from '../components/home/home.component';
import { CategoryComponent } from '../components/category/category.component';
import { MainMenuComponent } from '../components/main-menu/main-menu.component';
import { PreloaderComponent } from '../components/preloader/preloader.component';
import { MedicamentComponent } from '../components/medicament/medicament.component';

import { StorageService } from '../services/services';
import { RemoteStorageService } from '../services/remote-storage.service';

import { MatModule } from './mat.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CategoryComponent,
    PreloaderComponent,
    MainMenuComponent,
    MedicamentComponent,
  ],
  imports: [
    //BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MatModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: '**', redirectTo: '' },
    ]),
  ],
  providers: [
    { provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'fill' } },
    { provide: StorageService, useClass: RemoteStorageService },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
