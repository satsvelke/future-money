import { GAPIService } from "./../Services/LoginService/gapi.service";
import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import * as firebase from "firebase";
import { AngularFireAuth } from "@angular/fire/auth";
import { JwtHelper, tokenNotExpired } from "angular2-jwt";
import { combineAll } from "rxjs/operators";
@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent implements OnInit {
  constructor(
    private gapiService: GAPIService,
    public router: Router,
    public afAuth: AngularFireAuth
  ) {}
  ngOnInit(): void {
    var route = this.router;
    this.afAuth
      .getRedirectResult()
      .then(function (result) {
        if (result.credential) {
          localStorage.setItem(
            "p",
            JSON.stringify(result.additionalUserInfo.profile)
          );
          firebase
            .auth()
            .currentUser.getIdToken()
            .then((idToken) => {
              localStorage.setItem("idtoken", idToken);
              route.navigateByUrl("dashboard");
            });
        }
        // The signed-in user info.
        // var user = result.user;
      })
      .catch(function (error) {
        // Handle Errors here.
        var errorCode = error.code;
        var errorMessage = error.message;
        // The email of the user's account used.
        var email = error.email;
        // The firebase.auth.AuthCredential type that was used.
        var credential = error.credential;
        // ...
      });
  }
  loginWithGoogle() {
    this.gapiService.login();
  }
}
