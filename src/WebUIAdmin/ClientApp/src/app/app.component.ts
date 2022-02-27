import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { CONFIGURATION } from 'zencode-configuration-manager';
import { KA_GE } from './shared/constant';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  private language: string = CONFIGURATION.get<string>("constants.language") || KA_GE;

  title = 'Workspace';

  constructor(private translateService: TranslateService) {
    this.translateService.use(this.language);
  }


  onStartedProgressBar() { }


  onCompletedProgressBar() { }
}
