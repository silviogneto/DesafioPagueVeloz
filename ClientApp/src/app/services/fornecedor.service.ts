import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { IFornecedor } from "../models/fornecedor.model";

@Injectable({ providedIn: 'root' })
export class FornecedorService {
  private url: string;

  constructor(
    private httpClient: HttpClient,
    @Inject('BASE_URL') apiUrl: string
  ) {
    this.url = `${apiUrl}/api/fornecedores`;
  }

  getAll(): Observable<IFornecedor[]> {
    return this.httpClient.get<IFornecedor[]>(this.url);
  }

  add(fornecedor: IFornecedor): Observable<Object> {
    return this.httpClient.post(this.url, fornecedor);
  }
}
