import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-user",
  templateUrl: "user.component.html",
})
export class UserComponent implements OnInit {
  profile: any = { email: "" };

  constructor() {}

  ngOnInit() {
    console.log(localStorage.getItem("p"));
    this.profile = JSON.parse(localStorage.getItem("p"));
  }
}
