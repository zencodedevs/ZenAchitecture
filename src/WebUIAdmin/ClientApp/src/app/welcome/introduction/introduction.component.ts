/** core imports */
import { Component, OnInit } from "@angular/core";

/** external imports */
import { ToastrService } from "ngx-toastr";



@Component({
    selector: 'app-introduction-setup',
    templateUrl: './introduction.component.html',
    styleUrls: ['./introduction.component.sass']
})
export class IntroductionComponent implements OnInit {

    title = 'Zencode ng template';

    constructor(private toastrService: ToastrService) { }

    ngOnInit(): void {

        this.toastrService.info("WELCOME TO ZENCODE");
        this.toastrService.error("WELCOME TO ZENCODE");
        this.toastrService.warning("WELCOME TO ZENCODE");
        this.toastrService.success("WELCOME TO ZENCODE");

    }

}
