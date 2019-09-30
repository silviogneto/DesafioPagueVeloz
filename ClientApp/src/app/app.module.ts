import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { MainComponent } from './views/main/main.component';
import { EmpresaEditComponent } from './views/empresa/empresa.edit.component';
import { FornecedorEditComponent } from './views/fornecedor/fornecedor.edit.component';
import { FiltroPipe } from './pipes/filter.pipe';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    EmpresaEditComponent,
    FornecedorEditComponent,
    FiltroPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: MainComponent, pathMatch: 'full' },
      { path: 'fornecedores/new', component: FornecedorEditComponent },
      { path: 'empresas/new', component: EmpresaEditComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
