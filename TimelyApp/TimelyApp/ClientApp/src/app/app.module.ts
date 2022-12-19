import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AddModalComponent } from './modals/add-modal/add-modal.component';
import { EditModalComponent } from './modals/edit-modal/edit-modal.component';
import { DeleteModalComponent } from './modals/delete-modal/delete-modal.component';
import { APIcallsService } from './services/apicalls.service';

@NgModule({
  declarations: [
    AppComponent,
    AddModalComponent,
    EditModalComponent,
    DeleteModalComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
  ],
  providers: [APIcallsService],
  bootstrap: [AppComponent],
})
export class AppModule {}
