import { Component, OnInit } from "@angular/core";
import {
  NgbModal,
  ModalDismissReasons,
  NgbModalOptions,
} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: "app-banks",
  templateUrl: "banks.component.html",
  styleUrls: ["banks.component.scss"],
})
export class BanksComponent implements OnInit {
  closeResult: string;
  modalOptions: NgbModalOptions;
  constructor(private modalService: NgbModal) {
    this.modalOptions = {
      backdrop: "static",
      backdropClass: "customBackdrop",
      size: "lg",
    };
  }

  ngOnInit(): void {}

  ShowAddBankPopUp(content) {
    this.modalService.open(content, this.modalOptions).result.then(
      (result) => {
        this.closeResult = `Closed with: ${result}`;
      },
      (reason) => {}
    );
  }
}
