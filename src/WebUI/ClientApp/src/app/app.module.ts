/** core imports */
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

/** external imports */
import { TranslateModule } from "@ngx-translate/core";
import { ToastrModule } from 'ngx-toastr';
import { NgProgressModule } from "ngx-progressbar";
import { NgProgressHttpModule } from "ngx-progressbar/http";
import { ConfigurationModule } from "zencode-configuration-manager";

/** internal imports */
import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app-routing.module";
import {
  API_BASE_URL_PROVIDER,
  CONFIGURATION_PATH_PROVIDER, ERROR_HALDER_PROVDER, HTTP_AUTH_INTERCEPTORS_PROVIDER, HTTP_SERVER_SIDE_VALIDATION_INTERCEPTORS_PROVIDER,
  HTTP_SYS_LANG_INTERCEPTORS_PROVIDER, NG_PROGRESS_HTTP_CONFIG_PROVIDER, TRANSLATE_PROVIDER
} from "./app.config";

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NgProgressModule,
    NgProgressHttpModule,
    ToastrModule.forRoot(),
    TranslateModule.forRoot(TRANSLATE_PROVIDER),
    ConfigurationModule.forRoot(CONFIGURATION_PATH_PROVIDER),
  ],
  providers: [
    API_BASE_URL_PROVIDER,
    ERROR_HALDER_PROVDER,
    HTTP_AUTH_INTERCEPTORS_PROVIDER,
    HTTP_SYS_LANG_INTERCEPTORS_PROVIDER,
    NG_PROGRESS_HTTP_CONFIG_PROVIDER,
    HTTP_SERVER_SIDE_VALIDATION_INTERCEPTORS_PROVIDER
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
