import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { ClientPageComponent } from './client-page/client-page.component';
import { LoanAddComponent } from './loan-add/loan-add.component';
import { LoanItemComponent } from './loan-item/loan-item.component';
import { LoanListComponent } from './loan-list/loan-list.component';
import { LoanFooterComponent } from './loan-footer/loan-footer.component';
import { LoanService } from './services/loan.service';
import { ClientService } from './services/client.service';

@NgModule({
  declarations: [
    AppComponent,
    ClientPageComponent,
    LoanAddComponent,
    LoanItemComponent,
    LoanListComponent,
    LoanFooterComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule
  ],
  providers: [
    ClientService,
    LoanService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
