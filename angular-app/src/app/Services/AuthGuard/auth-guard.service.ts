import { first } from "rxjs-compat/operator/first";
import { GAPIService } from "./../LoginService/gapi.service";
import { Injectable } from "@angular/core";
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router,
} from "@angular/router";
import { Observable } from "rxjs";
import { AngularFireAuth } from "@angular/fire/auth";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: "root",
})
export class AuthGuardService implements CanActivate {
  constructor(
    private authService: GAPIService,
    private router: Router,
    private afAuth: AngularFireAuth
  ) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    return this.afAuth.authState.pipe(
      map((res) => {
        if (res && res.uid) return true;
        return false;
      })
    );
  }
}
