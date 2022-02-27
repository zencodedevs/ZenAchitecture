/** core imports */
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

/** external imports */

/** internal imports */
import { IntroductionComponent } from './introduction/introduction.component';

export const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        component: IntroductionComponent,
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class WelcomeRoutingModule { }
