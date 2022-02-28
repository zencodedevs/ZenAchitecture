/** core imports */
import { Component, OnInit } from "@angular/core";

/** external imports */
import { ToastrService } from "ngx-toastr";
import { CityClient } from "src/app/shared/web-api-client";



@Component({
    selector: 'app-introduction-setup',
    templateUrl: './introduction.component.html',
    styleUrls: ['./introduction.component.sass']
})
export class IntroductionComponent implements OnInit {

    title = 'Zencode ng template';

    constructor(private toastrService: ToastrService, private cityClient: CityClient) { }

    ngOnInit(): void {

        this.toastrService.info("WELCOME TO ZENCODE");
        this.toastrService.error("WELCOME TO ZENCODE");
        this.toastrService.warning("WELCOME TO ZENCODE");
        this.toastrService.success("WELCOME TO ZENCODE");

        this.cityClient.getCities().subscribe(response => {
            console.log(response);
            this.toastrService.success('Data loaded.see browser console for more details');
        });

    }

}
