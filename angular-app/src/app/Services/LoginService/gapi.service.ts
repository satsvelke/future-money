import { DashboardComponent } from "./../../pages/dashboard/dashboard.component";
import { Router } from "@angular/router";
import { Injectable } from "@angular/core";
import { AngularFireAuth } from "@angular/fire/auth";
import { AngularFireAuthGuard } from "@angular/fire/auth-guard";
import { auth } from "firebase";
import { JwtHelper, tokenNotExpired } from "angular2-jwt";
import { Observable } from "rxjs";
import "rxjs/add/observable/of";
import { Http } from "@angular/http";
import * as firebase from "firebase";

@Injectable({
  providedIn: "root",
})
export class GAPIService {
  private user: Observable<firebase.User>;
  private userDetails: firebase.User = null;

  constructor(
    public afAuth: AngularFireAuth,
    public router: Router //private http: Http
  ) {}

  // Sign in with Google
  login() {
    // return this.afAuth
    //   .signInWithRedirect(new auth.GoogleAuthProvider())
    //   .then((r) => {
    //     localStorage.setItem("oatn", (<any>r).credential.accessToken);
    //     localStorage.setItem("token", (<any>r).credential.idToken);
    //     firebase
    //       .auth()
    //       .currentUser.getIdToken()
    //       .then((idToken) => {
    //         localStorage.setItem("idtoken", idToken);
    //       });
    //     this.router.navigateByUrl("dashboard");
    //   })
    //   .catch((error) => {
    //     console.log(error);
    //   });
    this.afAuth.signInWithRedirect(new auth.GoogleAuthProvider());
  }
  isLoggedIn() {
    return tokenNotExpired();
  }
  logout() {
    localStorage.removeItem("oatn");
    localStorage.removeItem("token");
    this.afAuth.signOut().then((res) => this.router.navigate(["/"]));
  }
}
