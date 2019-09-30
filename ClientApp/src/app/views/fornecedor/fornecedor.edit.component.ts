import { Component, OnInit } from "@angular/core";
import { FornecedorService } from "../../services/fornecedor.service";
import { EmpresaService } from "../../services/empresa.service";
import { IEmpresa } from "../../models/empresa.model";
import { IFornecedor } from "../../models/fornecedor.model";
import { Router } from "@angular/router";
import { ITelefone } from "../../models/telefone.model";

@Component({
  selector: 'fornecedor-edit',
  templateUrl: './fornecedor.edit.component.html',
  providers: [FornecedorService, EmpresaService]
})
export class FornecedorEditComponent implements OnInit {
  empresas: IEmpresa[];
  empresaCNPJ: string;
  nome: string;
  documento: string;
  tipoDocumento: string = 'CNPJ';
  rg: string;
  dataNascimento: string;
  telefones: ITelefone[] = [];
  telefone: string = '';
  mensagemErro: string;

  constructor(
    private fornacedorService: FornecedorService,
    private empresaService: EmpresaService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.empresaService.getAll().subscribe(empresas => this.empresas = empresas);
  }

  save() {
    let empresa: IEmpresa = this.empresas.filter(x => x.cnpj == this.empresaCNPJ)[0];
    let fornecedor: IFornecedor = {
      id: 0,
      empresa: empresa,
      nome: this.nome,
      documento: this.documento,
      dataCadastro: new Date(),
      telefones: this.telefones
    };

    if (this.tipoDocumento == 'CPF') {
      fornecedor.rg = this.rg;
      const partesData = this.dataNascimento.split('/');
      fornecedor.dataNascimento = new Date(`${partesData[2]}-${partesData[1]}-${partesData[0]}`);
    }

    this.fornacedorService.add(fornecedor).subscribe(
      () => this.router.navigate(['']),
      (err) => {
        this.mensagemErro = err.error;
      }
    )
  }

  addTelefone(telefone: string) {
    if (telefone == null || telefone === '') {
      return;
    }

    this.telefones.push({ id: 0, numeroTelefone: telefone });
    this.telefone = '';
  }
}
