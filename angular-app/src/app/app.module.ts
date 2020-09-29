import { GAPIService } from "./Services/LoginService/gapi.service";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { ToastrModule } from "ngx-toastr";
import { AngularFireAuthGuard } from "@angular/fire/auth-guard";
import { AppComponent } from "./app.component";
import { AdminLayoutComponent } from "./layouts/admin-layout/admin-layout.component";
import { AuthLayoutComponent } from "./layouts/auth-layout/auth-layout.component";

import { NgbModule } from "@ng-bootstrap/ng-bootstrap";

import { AppRoutingModule } from "./app-routing.module";
import { ComponentsModule } from "./components/components.module";
import { BanksComponent } from "./pages/banks/banks.component";
import { SpentComponent } from "./pages/spent/spent.component";
import { InvestmentComponent } from "./pages/investment/investment.component";
import { SavingsComponent } from "./pages/savings/savings.component";
import { LoansComponent } from "./pages/loans/loans.component";
import { LoginComponent } from "./login/login.component";
import { HomeComponent } from "./pages/home/home.component";
import { environment } from "./../environments/environment";
// 1. Import the libs you need
import { AngularFireModule } from "@angular/fire";
import { AngularFirestoreModule } from "@angular/fire/firestore";
// import { AngularFireStorageModule } from "@angular/fire/storage";
import { AngularFireAuthModule } from "@angular/fire/auth";
import { AuthGuardService } from "./Services/AuthGuard/auth-guard.service";
import * as firebase from "firebase";
firebase.initializeApp(environment.firebaseConfig);
@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ComponentsModule,
    NgbModule,
    RouterModule,
    AppRoutingModule,
    ToastrModule.forRoot(),
    AngularFireModule.initializeApp(environment.firebaseConfig),
    AngularFirestoreModule, // firestore
    AngularFireAuthModule, // auth
    // AngularFireStorageModule, // storage,
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    AuthLayoutComponent,
    BanksComponent,
    SpentComponent,
    InvestmentComponent,
    SavingsComponent,
    LoansComponent,
    LoginComponent,
    HomeComponent,
  ],
  providers: [GAPIService, AngularFireAuthGuard, AuthGuardService],
  bootstrap: [AppComponent],
})
export class AppModule {}
