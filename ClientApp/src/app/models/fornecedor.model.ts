import { IEmpresa } from "./empresa.model";
import { ITelefone } from "./telefone.model";

export interface IFornecedor {
  id: number;
  nome: string;
  documento: string;
  rg?: string;
  dataNascimento?: Date;
  dataCadastro: Date;

  empresa?: IEmpresa;
  telefones?: ITelefone[];
}
