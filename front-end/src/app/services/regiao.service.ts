import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Regiao } from '../models/regiao';
import { AtualizarRegiao } from '../models/atualizarRegiao';

@Injectable({
  providedIn: 'root'
})
export class RegiaoService {

  private apiUrl = `${environment.baseApiUrl}/regiao`;

  constructor(private http: HttpClient) { }

  listarTodos(): Observable<Regiao[]> {
    return this.http.get<Regiao[]>(this.apiUrl);
  }

  listarPorId(id: string): Observable<Regiao> {
    return this.http.get<Regiao>(`${this.apiUrl}/${id}`)
  }

  salvar(regiao: Regiao): Observable<boolean> {
    return this.http.post<boolean>(this.apiUrl, regiao)
  }

  atualizar(regiao: AtualizarRegiao): Observable<boolean> {
    return this.http.put<boolean>(`${this.apiUrl}/${regiao.id}`, regiao)
  }

  ativar(id: string): Observable<boolean> {
    return this.http
      .put<boolean>(`${this.apiUrl}/SetActive/${id}`, {})
  }

  desativar(id: string): Observable<boolean> {
    return this.http
    .put<boolean>(`${this.apiUrl}/TurnOff/${id}`, {})
  }

  exportar(): Observable<any> {
    return this.http
  .get<boolean>(`${this.apiUrl}/Export`)
  }
}
