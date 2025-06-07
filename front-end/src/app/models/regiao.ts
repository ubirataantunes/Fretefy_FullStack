import { Cidade } from "./cidade";

export class Regiao {
  id: string;
  nome: string;
  ativo: boolean;
  cidades: Cidade[];
}