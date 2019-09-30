import { Pipe, PipeTransform } from "@angular/core";
import { IFornecedor } from "../models/fornecedor.model";

@Pipe({
  name: 'filtro'
})
export class FiltroPipe implements PipeTransform {
  transform(items: IFornecedor[], nome: string, doc: string, dataCadastro: string) {
    if (!items) {
      return [];
    }

    if (!nome && !doc && !dataCadastro) {
      return items;
    }

    let retorno = items;

    if (nome) {
      retorno = retorno.filter(x => x.nome.toLowerCase().includes(nome));
    }

    if (doc) {
      retorno = retorno.filter(x => x.documento.includes(doc));
    }

    if (dataCadastro && dataCadastro.split('/').length === 3) {
      const partes = dataCadastro.split('/');
      retorno = retorno.filter(x => x.dataCadastro == new Date(`${partes[2]}-${partes[1]}-${partes[0]}`));
    }

    return retorno;
  }
}
