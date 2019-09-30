import { Component } from "@angular/core";
import { Router } from '@angular/router';
import { EmpresaService } from "../../services/empresa.service";
import { IEmpresa } from "../../models/empresa.model";

@Component({
  selector: 'empresa-edit',
  templateUrl: './empresa.edit.component.html',
  providers: [EmpresaService]
})
export class EmpresaEditComponent {
  empresa: IEmpresa = { cnpj: '', nomeFantasia: '', uf: '' };

  constructor(
    private empresaService: EmpresaService,
    private router: Router
  ) {
  }

  save(empresa: IEmpresa) {
    this.empresaService.add(empresa).subscribe(
      () => this.router.navigate(['fornecedores/new'])
    );
  }
}
