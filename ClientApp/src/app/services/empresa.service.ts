import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { IEmpresa } from "../models/empresa.model";

@Injectable({ providedIn: 'root' })
export class EmpresaService {
  private url: string;

  constructor(
    private httpClient: HttpClient,
    @Inject('BASE_URL') apiUrl: string
  ) {
    this.url = `${apiUrl}/api/empresas`;
  }

  getAll(): Observable<IEmpresa[]> {
    return this.httpClient.get<IEmpresa[]>(this.url);
  }

  add(empresa: IEmpresa): Observable<Object> {
    return this.httpClient.post(this.url, empresa);
  }
}
