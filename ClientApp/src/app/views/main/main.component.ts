import { Component, OnInit } from "@angular/core";
import { FornecedorService } from "../../services/fornecedor.service";
import { IFornecedor } from "../../models/fornecedor.model";

@Component({
  selector: 'main-root',
  templateUrl: './main.component.html',
  providers: [FornecedorService]
})
export class MainComponent implements OnInit {
  fornecedores: IFornecedor[] = [];
  filtroNome: string = '';
  filtroDoc: string = '';
  filtroDataCadastro: string = '';

  constructor(
    private fornecedorService: FornecedorService
  ) {
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.fornecedorService.getAll().subscribe(fornecedores => {
      this.fornecedores = fornecedores;
    });
  }
}
