export class AtualizarRegiao {
  id: string;
  nome: string;
  ativo: boolean;
  cidades: String[];

  constructor(id: string, nome: string, ativo: boolean, cidades: String[]) {
    this.id = id;
    this.nome = nome;
    this.ativo = ativo;
    this.cidades = cidades;
  }
}