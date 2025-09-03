export class CriarRegiao {
  nome: string;
  cidades: String[];

  constructor(name: string, cidades: String[])
  {
    this.nome = name;
    this.cidades = cidades;
  }
}