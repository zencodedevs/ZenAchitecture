/** core imports */
import { NgModule } from '@angular/core';

/** external imports */
import { UtilitiesModule } from 'zencode-utilities';

/** internal imports */
import { IntroductionComponent } from './introduction/introduction.component';
import { WelcomeRoutingModule } from './welcome-routing.module';
import { SharedModule } from '../shared/shared.module';


@NgModule({
    imports: [
        UtilitiesModule,
        SharedModule,
        WelcomeRoutingModule,
    ],
    declarations: [
        IntroductionComponent
    ],
    entryComponents: [],
    providers: [],
})
export class WelcomeModule { }
